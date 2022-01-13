using Microsoft.AspNetCore.Mvc;
using LabWork_5.Models;
using LibraryForLab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LabWork_5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        public IActionResult PR1() 
        {
            return View();
        }

        public IActionResult PR2()
        {
            return View();
        }

        public IActionResult PR3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PR1(Lab1Model model)
        {
            Lab1 lab1 = new Lab1();
            try
            {
                model.Response = lab1.OnExecute(model.Data);
                model.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                model.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                model.ErrorValue = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult PR2(Lab2Model model)
        {
            Lab2 lab2 = new Lab2();
            try
            {
                model.Response = lab2.OnExecute(model.Data);
                model.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                model.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                model.ErrorValue = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult PR3(Lab3Model model)
        {
            Lab3 lab3 = new Lab3();
            try
            {
                model.Response = lab3.OnExecute(model.Data);
                model.Calculated = true;
            }
            catch (ArgumentException aex)
            {
                model.ErrorValue = aex.Message;
            }
            catch (Exception ex)
            {
                model.ErrorValue = ex.Message;
            }

            return View(model);
        }
    }
}
