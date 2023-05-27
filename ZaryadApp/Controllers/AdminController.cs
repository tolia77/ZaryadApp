using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZaryadApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }
    }
}
