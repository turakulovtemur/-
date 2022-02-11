using ExchangeRates.Models;
using ExchangeRates.Services;
using ExchangeRates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModernDev.InTouch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ExchangeRates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRatesService _ratesService;
        private readonly IGifsService _gifsService;

        public HomeController(ILogger<HomeController> logger, IRatesService ratesService, IGifsService gifsService)
        {
            _logger = logger;
            _ratesService = ratesService;
            _gifsService = gifsService;
        }

        //[HttpGet]
        //[Route("rate")]
        //public IActionResult ExchangeRate()
        //{
        //    //3qoY9i4HFXTbdsjOKQ9oHJ6PSWNOnSXM
        //    var firstValue = _ratesService.GetRateByDate(DateTime.Parse("2021.12.03"), "RUB").ToString();
        //    var secondValue = _ratesService.GetRateByDate(DateTime.Parse("2021.04.04"), "RUB").ToString();
        //    if (Convert.ToDouble(secondValue) > Convert.ToDouble(firstValue))
        //    {
        //        return _gifsService.GetGifs("l1AsxS5F4Au3gelck");
        //    }
        //    return null;
        //}

        [HttpGet]
        public IActionResult Gify()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Gify(GifyDates gifyDates)
        {
            RateViewModel rateViewModel = new RateViewModel();
            
            var firstValue = _ratesService.GetRateByDate(DateTime.Parse(gifyDates.FistDate), "RUB");
            var secondValue = _ratesService.GetRateByDate(DateTime.Parse(gifyDates.SecondDate), "RUB");

            if (secondValue > firstValue)
            {
                rateViewModel.IsBigger = true;
                rateViewModel.Url = _gifsService.GetGifs("l1AsxS5F4Au3gelck");

            }
            else
            {
                rateViewModel.IsBigger = false;
                rateViewModel.Url = _gifsService.GetGifs("7x90dc0KEjRNC");

            }

            return View(rateViewModel);
        }

    


        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
