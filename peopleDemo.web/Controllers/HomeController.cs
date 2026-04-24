using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using peopleData;
using peopleDemo.web.Models;

namespace peopleDemo.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source =.\sqlexpress;Initial Catalog=people;Integrated Security=True;TrustServerCertificate=true;";
        public IActionResult Index()
        {
           var manager = new ManagerClass(_connectionString);
            PviewModel pvm = new PviewModel();
            pvm.people = manager.GetPeople();
            if (TempData["message"]!=null)
            {
                pvm.Message=(string)TempData["message"];
            }
            return View(pvm);
        }
        [HttpPost]
        public IActionResult MultiDelete(List<int>ids)
        {
            var manager = new ManagerClass(_connectionString);
            manager.DeleteMUltiPeople(ids);
            TempData["message"] = $"{ids.Count} people where deleted!!!";
            return Redirect("/home");
        }
        public IActionResult AddPeople()
        {

            return View();
                }
        [HttpPost]
        public IActionResult MultiAdd(List<Person> people)
        {
            List<Person> p = people.Where(p => p.FirstName != null && p.LastName != null && p.Age != null).ToList();
                var manager = new ManagerClass(_connectionString);
                manager.AddMultiPeople(p);
            TempData["message"] = $"{p.Count} people where added!!!!";
            
                
            

            return Redirect("/home");

        }
       
    }
}
