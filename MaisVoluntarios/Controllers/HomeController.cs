using MaisVoluntarios.Core;
using MaisVoluntarios.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MaisVoluntarios.Controllers
{
    public class HomeController : Controller
    {
        //instanciar repositorio Voluntario.
        //instanciar repositorio empresa.
        AcessoRepositorio acessorepositorio = new AcessoRepositorio();
        MensagemRepositorio mensagemRepositorio = new MensagemRepositorio();
        AtividadeRepositorio atividadeRepositorio = new AtividadeRepositorio();
        EmpresaRepositorio empresaRepositorio = new EmpresaRepositorio();
        VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cadastrovoluntario()
        {
            IEnumerable<Atividade> atividades = atividadeRepositorio.getAll();
            return View(atividades);
        }
        [HttpPost]
        public ActionResult cadastrovoluntario(Voluntario vol)
        {
            voluntarioRepositorio.Create(vol);
            return RedirectToAction("login");
        }
        public ActionResult cadastroempresa()
        {
            IEnumerable<Atividade> atividades = atividadeRepositorio.getAll();
            return View(atividades);
        }
        [HttpPost]
        public ActionResult cadastroempresa(Empresa emp)
        {
            empresaRepositorio.Create(emp);
            return RedirectToAction("login");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Acesso ac)
        {
            Acesso usuario;
            if (ac.log == 1)
            {
                usuario = acessorepositorio.getPass(ac);
                if(usuario != null)
                {
                    TempData["identificador"] = usuario.voluntario.idVoluntario;
                    TempData.Keep("identificador");
                    VoluntarioController.usuariologado = usuario.voluntario.nomeVoluntario;
                    
                    IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllVoluntarioPreview(usuario.voluntario.idVoluntario);
                    TempData["msgs"] = msgs;
                    TempData.Keep("msgs");
                    VoluntarioController.logou = true;
                    return RedirectToAction("Index", "Voluntario");
                }
                else
                {
                    return View();
                }
                
            }
            if (ac.log == 2)
            {
                usuario = acessorepositorio.getPass(ac);
                if (usuario != null)
                {
                    TempData["identificador"] = usuario.empresa.idEmpresa;
                    TempData.Keep("identificador");
                    InstituicaoController.usuariologado = usuario.empresa.nomeEmpresa;

                    IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllEmpresa(usuario.empresa.idEmpresa);
                    TempData["msgs"] = msgs;
                    TempData.Keep("msgs");
                    InstituicaoController.logou = true;
                    return RedirectToAction("Index", "Instituicao");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}