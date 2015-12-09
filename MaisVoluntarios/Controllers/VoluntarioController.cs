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
    public class VoluntarioController : Controller
    {
        EmpresaRepositorio empresaRepositorio = new EmpresaRepositorio();
        MensagemRepositorio mensagemRepositorio = new MensagemRepositorio();
        VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio();
        AtividadeRepositorio atividadeRepositorio = new AtividadeRepositorio();

        public static int ident;
        public static string usuariologado;
        public static bool logou;
        // GET: Voluntario
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

            IEnumerable<Empresa> empresas = empresaRepositorio.getSete();
            
            return View(empresas);
        }
        public ActionResult Vagas()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Empresa> empresas = empresaRepositorio.getAll();
            return View(empresas);
        }
        public ActionResult Caixadeentrada()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllVoluntario(ident);
            return View(msgs);
        }
        public ActionResult Caixadesaida()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            IEnumerable<Mensagem> msgs = mensagemRepositorio.getAllVoluntarioSaida(ident);
            return View(msgs);
        }
        public ActionResult Perfil()
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Voluntario vol = voluntarioRepositorio.getOne(ident);

            ViewBag.atividades = atividadeRepositorio.getAll();

            return View(vol);
        }
        [HttpPost]
        public ActionResult Perfil(Voluntario vol)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            voluntarioRepositorio.Update(vol);

            return RedirectToAction("Index");
        }
        public ActionResult PerfilInstituicao(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;
            ViewBag.nomeusuario = TempData.Peek("nomeusuario");
            ViewBag.identificador = TempData.Peek("identificador");
            Empresa emp = empresaRepositorio.getOneView(id);
            return View(emp);
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

            var filePathOriginal = Server.MapPath("/img/perfilv/");
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
            Empresa emp = empresaRepositorio.getOneView(id);

            return View(emp);
        }
        [HttpPost]
        public ActionResult Escrevermensagem(Mensagem msg)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.CreateMsg(msg);
            return RedirectToAction("Caixadesaida");
        }
        public ActionResult Status(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            string troca = id.ToString();
            voluntarioRepositorio.TrocaStatus(ident, troca);
            return RedirectToAction("Index");
        }
        public ActionResult DeletarMsgE(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.DeleteMensagemEntrada(id);
            return RedirectToAction("Caixadeentrada");
        }
        public ActionResult Ler(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Mensagem msg = mensagemRepositorio.getOne(id);

            return View(msg);
        }
        public ActionResult LerSaida(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            Mensagem msg = mensagemRepositorio.getOneSaida(id);

            return View(msg);
        }
        public ActionResult DeletarMsgS(int id)
        {
            ViewBag.nomeusuario = usuariologado;
            ViewBag.identificador = ident;

            mensagemRepositorio.DeleteMensagemSaida(id);
            return RedirectToAction("Caixadesaida");
        }
    }
}