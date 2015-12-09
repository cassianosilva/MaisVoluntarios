using MaisVoluntarios.Core;
using MaisVoluntarios.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisVoluntarios.Controllers
{
    public class InstituicaoController : Controller
    {
        EmpresaRepositorio empresaRepositorio = new EmpresaRepositorio();
        MensagemRepositorio mensagemRepositorio = new MensagemRepositorio();
        VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio();
        AtividadeRepositorio atividadeRepositorio = new AtividadeRepositorio();

        public static int ident;
        public static string usuariologado;
        public static bool logou;
        // GET: Instituicao
        public ActionResult Index()
        {
            if (logou)
            {
                ident = (int)TempData.Peek("identificador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.nomeusuario = usuariologado;

            IEnumerable<Voluntario> voluntarios = voluntarioRepositorio.getSete();

            return View(voluntarios);
        }
        public ActionResult Vagas()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Voluntario> voluntarios = voluntarioRepositorio.getAll();
            return View(voluntarios);
        }
        public ActionResult Caixadeentrada()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllEmpresa(ident);
            return View(msgs);
        }
        public ActionResult Caixadesaida()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllEmpresaSaida(ident);
            return View(msgs);
        }
        public ActionResult Perfil()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Empresa emp = empresaRepositorio.getOneView(ident);

            ViewBag.atividades = atividadeRepositorio.getAll();

            return View(emp);
        }
        [HttpPost]
        public ActionResult Perfil(Empresa emp)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            empresaRepositorio.Update(emp);

            return RedirectToAction("Index");
        }
        public ActionResult PerfilVoluntario(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            ViewBag.nomeusuario = TempData.Peek("nomeusuario");
            ViewBag.identificador = TempData.Peek("identificador");
            Voluntario vol = voluntarioRepositorio.getOne(id);
            return View(vol);
        }
        public ActionResult Foto()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            return View();
        }
        [HttpPost]
        public ActionResult Foto(HttpPostedFileBase image)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            var filename = ident;
            var desmonta = image.FileName.Split('.');
            var filetype = desmonta.Last().Split('.');

            var arquivo = filename + "." + filetype[0];

            var filePathOriginal = Server.MapPath("/img/perfili/");
            string savedFileName = Path.Combine(filePathOriginal, arquivo.ToString());
            image.SaveAs(savedFileName);

            return RedirectToAction("Foto");
        }
        public ActionResult Logout()
        {
            TempData.Keep("identificador");
            TempData.Keep("msgs");
            ident = 0;
            usuariologado = null;
            logou = false;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Escrevermensagem(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            ViewBag.idV = ident;
            Voluntario vol = voluntarioRepositorio.getOne(id);

            return View(vol);
        }
        [HttpPost]
        public ActionResult Escrevermensagem(Mensagem msg)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.CreateMsgSaida(msg);
            return RedirectToAction("Caixadesaida");
        }
       
        public ActionResult Ler(int id)
        {
   
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Mensagem msg = mensagemRepositorio.getOneSaida(id);

            return View(msg);
        }
        public ActionResult LerT(int id)
        {

            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Mensagem msg = mensagemRepositorio.getOneSaida(id);
            mensagemRepositorio.TrocaStatusMensagemEmp(id);
            return View("Ler",msg);
        }
        public ActionResult LerSaida(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Mensagem msg = mensagemRepositorio.getOne(id);

            return View(msg);
        }
        public ActionResult DeletarMsgS(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.DeleteMensagemEntrada(id);
            return RedirectToAction("Caixadesaida");
        }
        public ActionResult DeletarMsgE(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.DeleteMensagemSaida(id);
            return RedirectToAction("Caixadeentrada");
        }

    }
}