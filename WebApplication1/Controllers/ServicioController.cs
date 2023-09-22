using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ServiceReference1;

namespace WebApplication1.Controllers
{
    public class ServicioController : Controller
    {
        private ServiceReference1.WsFactClient objWorkManager = new ServiceReference1.WsFactClient();

        // GET: Servicio
        public ActionResult Index()
        {
            try
            {
                MessageRequest request = new MessageRequest();

                request.rfcEmisor = "zzz";
                request.tipoEmisor = TipoEmisor.Direct;
                request.operacion = Operacion.Cancelacion;

               MessageResponse resp = objWorkManager.ProcessDocument(request);

                Console.WriteLine(resp.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
            }

            return View();
        }
    }
}