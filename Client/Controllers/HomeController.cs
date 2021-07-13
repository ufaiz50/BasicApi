using API.Models;
using API.ViewModel;
using Client.Base;
using Client.Models;
using Client.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : BaseController<Account, HomeRepository, string>
    {
        private readonly HomeRepository repository;
       /* private readonly ILogger<HomeController> _logger;*/

        public HomeController(HomeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> GetLoginView(string nik, string password)
        {
            var login = new LoginVM();
            login.NIK = nik;
            login.password = password;
            var result = await repository.GetLoginView(login);

            if (result == null)
            {
                return RedirectToAction("login");
            }
            HttpContext.Session.SetString("JwToken", result.Result);
            return RedirectToAction("index", "Employee");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
