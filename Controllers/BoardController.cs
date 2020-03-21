using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello2020.Services;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello2020.Controllers
{
    public class BoardController : Controller
    {
        private readonly BoardService boardService;

        public BoardController(BoardService boardService)
        {
            this.boardService = boardService;

        }
        public IActionResult Index(int id)
        {
            BoardView model = boardService.GetBoard(id);

            return View(model);
        }

        public IActionResult AddCard(int id)
        {
            return View("AddCard");
        }

        [HttpPost]
        public IActionResult AddCard(AddCard viewModel)
        {
            if (ModelState.IsValid)
            {
                boardService.AddCard(viewModel);
                return RedirectToAction(nameof(Index), new { id = viewModel.Id });
            }
            return View(viewModel);
        }
    }
}