using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetMVC_EF_TPT.DB;
using NetMVC_EF_TPT.Models;

namespace NetMVC_EF_TPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static IConfiguration _iconfiguration;

        public HomeController(ILogger<HomeController> logger, IConfiguration iconfiguration)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDetail order)
        {
            System.Diagnostics.Debug.WriteLine("Controller KargoEkle - " + order.orderedItem);
            using (var db = new OrderContext(_iconfiguration))
            {
                db.Add(order);
                db.SaveChanges();
                Console.WriteLine("DB isert completed: " +
                                    order.orderId + "," +
                                    order.orderedItem + "," +
                                    order.destAdress);
            }

            return View("DisplayOrders", RetrieveOrders());
        }

        public IActionResult DisplayOrders()
        {
            return View(RetrieveOrders());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<OrderDetail> RetrieveOrders()
        {
            List<OrderDetail> lst = null;
            using (var db = new OrderContext(_iconfiguration))
            {
                lst = db.siparisler.ToList();
            }
            return lst;
        }
    }
}
