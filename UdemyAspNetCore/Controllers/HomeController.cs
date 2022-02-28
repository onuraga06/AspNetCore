using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using UdemyAspNetCore.Filters;
using UdemyAspNetCore.Models;


namespace UdemyAspNetCore.Controllers
{

    public class HomeController : Controller
    {
        // ysk.com.tr/Home/Index


        [HttpGet]
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
          
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidFirstName]
        // Model Binding
        public IActionResult Create(Customer customer)
        {
            //var firstName = HttpContext.Request.Form["firstName"].ToString();
            //var lastName = HttpContext.Request.Form["lastName"].ToString();
            //var age = int.Parse(HttpContext.Request.Form["age"].ToString());

            //var control = ModelState.IsValid;
            //var errors = ModelState.Values.SelectMany(I => I.Errors.Select(I=>I.ErrorMessage));

            ModelState.Remove("Id");
            if (customer.FirstName == "Onur")
            {
                ModelState.AddModelError("", "Firstname Onur olamaz");
            }
            if (ModelState.IsValid)
            {
                Customer lastCustomer = null;
                if (CustomerContext.Customers.Count > 0)
                {
                    lastCustomer = CustomerContext.Customers.Last();

                }

                customer.Id = 1;

                if (lastCustomer != null)
                {
                    customer.Id = lastCustomer.Id + 1;
                }


                CustomerContext.Customers.Add(customer);

                return RedirectToAction("Index");
            }

            return View();

       
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
           
            //var id = int.Parse(RouteData.Values["id"].ToString());

            var removedCustomer = CustomerContext.Customers.Find(I => I.Id == id);
            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            //var id = int.Parse(RouteData.Values["id"].ToString());
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(a => a.Id == id);
            return View(updatedCustomer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {

            //var id = int.Parse(HttpContext.Request.Form["id"].ToString());

            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(I => I.Id == customer.Id);
            //updatedCustomer.FirstName = HttpContext.Request.Form["firstName"].ToString();
            //updatedCustomer.LastName = HttpContext.Request.Form["lastName"].ToString();
            //updatedCustomer.Age = int.Parse(HttpContext.Request.Form["age"].ToString());

            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.Age = customer.Age;


            return RedirectToAction("Index");
        }


        public IActionResult Status(int? code)
        {
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature= HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // serilog nlog
            // 11-02-2020_15-02


            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            // 11/02/2020 15:30:12
            var logFileName = DateTime.Now.ToString();

            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace(":", "-");
            logFileName = logFileName.Replace("/", "-");

            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath,logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            FileInfo fileInfo = new FileInfo(logFilePath);
            var writer = fileInfo.CreateText();
            writer.WriteLine("Hatanın gerçekleştiği yer :" + exceptionHandlerPathFeature.Path);

            writer.WriteLine("Hata mesajı :" + exceptionHandlerPathFeature.Error.Message);

            writer.Close();
            return View();
        }

        public IActionResult Hata()
        {
            throw new System.Exception("Sistemsel hata oluştu");
        }
    

    }
}
