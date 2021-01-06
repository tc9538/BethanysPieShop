using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class PieFeedbackController : Controller
    {
        // GET: /<controller>/
        public IActionResult SubmitFeedback()
        {
            return View();
        }

        //pieFeedback object is null. Need to fix this later.add a logic to handle it
        [HttpPost]
        public IActionResult SubmitFeedback(PieFeedback pieFeedback)
        {
            if(ModelState.IsValid)
            {

                return RedirectToAction("SubmitFeedbackComplete");
            }
            else
            {
                ModelState.AddModelError("", "Please add some feedback");
            }

            return View(pieFeedback);
            

        }

        public IActionResult SubmitFeedbackComplete()
        {
            ViewBag.SubmitFeedbackCompleteMessage = "Thank you for your feedback!";
            return View();
        }
    }
}
