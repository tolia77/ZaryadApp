using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZaryadApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
