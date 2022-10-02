using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Context;

namespace WebApplication4.Controllers
{
    public class DBController : Controller
    {
        DataContext result = new DataContext();
        #region
        // GET: DB
        public ActionResult Index()
        {
            return View();
        }

        // GET: DB/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DB/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DB/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DB/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DB/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DB/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region показать всё
        public IActionResult dbResult()
        {



            List<Number> numbers = new List<Number>();
           

            foreach (var item in result.Numbers)
            {
                numbers.Add(item);
            }

            return View(numbers);
        }
        #endregion

        #region добавить
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNumber(long Phone, string Name)
        {
            Number number = new Number(Name, Phone);
           
            result.Numbers.Add(number);
            result.SaveChanges();

            return Redirect("~/DB/dbResult");
        }
        #endregion

        #region показать
        [HttpGet]
        public IActionResult DbShowNumber(int ajaxResult)
        {
            Redirect("~/DB/dbShowNumber");
            List<Number> numbers = new List<Number>();
            var number = result.Numbers.Where(e=> e.Id == ajaxResult);
             
            foreach (var item in number)
            {
                numbers.Add(item);
            }

            
            
            return View(numbers[0]);
        }
        #endregion

        #region удалить
        public IActionResult DbRemoveNumber(int Id)
        {



            var number = result.Numbers.Where(e => e.Id == Id);
            List<Number> numbers = new List<Number>();
            foreach (var item in number)
            {
                numbers.Add(item);
            }
            result.Numbers.Remove(numbers[0]);
            result.SaveChanges();

            return Redirect("~/DB/dbResult");
        }
        #endregion

        #region изменить
        public IActionResult changeNumer(int ajaxResult)
        {
            List<Number> numbers = new List<Number>();
            var number = result.Numbers.Where(e => e.Id == ajaxResult);

            foreach (var item in number)
            {
                numbers.Add(item);
            }



            return View(numbers[0]);
        }
        
        public IActionResult DbChangeNumber( int Id, string Surname, string Name, string LastName, long PhoneNumber, string Address, string Description)
        {
 
            foreach (Number item in result.Numbers)
            {
                if (item.Id == Id)
                {
                    item.Surname = Surname;
                    item.Name = Name;
                    item.LastName = LastName;
                    item.PhoneNumber = PhoneNumber;
                    item.Address = Address;
                    item.Description = Description;
                    break;
                }
            }
            result.SaveChanges();
            return Redirect("~/");
        }
        #endregion


    }
}