using Microsoft.AspNetCore.Mvc;
using PrinterCaller.Models;
using System;
using System.Diagnostics;

namespace PrinterCaller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult Caller()
        {
            string pipeExe = @"C:\Users\avelicoglo\Desktop\internProjects\asp6Denemeler\masterSlavePrinter\MasterPrinter\bin\Debug\net6.0\MasterPrinter.exe";
            Process proc = new Process();
            proc.StartInfo.FileName = pipeExe;
            proc.StartInfo.Arguments = "sapec";
            proc.Start();
            proc.WaitForExit();
            
            // 2. way
            //Process.Start(pipeExe, "abc");

            return RedirectToAction("Index");
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