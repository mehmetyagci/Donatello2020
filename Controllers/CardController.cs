using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello2020.Services;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello2020.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService cardService;

        public CardController(CardService cardService)
        {
            this.cardService = cardService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            CardDetails viewModel = this.cardService.GetDetails(id);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CardDetails cardDetails)
        {
            cardService.Update(cardDetails);

            TempData["Message"] = "Saved Card Details";

            return RedirectToAction(nameof(Details), new { id = cardDetails.Id });
        }



    }
}