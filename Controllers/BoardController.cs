using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello2020.Services;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello2020.Controllers
{
    //[AutoValidateAntiforgeryToken]
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

        [HttpGet]
        public IActionResult Notifications(int boardId, int columnId)
        {
            var settings = boardService.GetNotificationPreferences(boardId, columnId);
            return View(settings);
        }


        //[HttpPost]
        //public IActionResult Notifications(int boardId, int columnId)
        //{
        //    return RedirectToAction(nameof(Index), new { id = boardId });
        //}

        //[HttpPost]
        //public IActionResult Notifications(int boardId, int columnId, string EmailAddress)
        //{
        //    return RedirectToAction(nameof(Index), new { id = boardId });
        //}

        [HttpPost]
        public IActionResult Notifications(NotificationSettings viewModel)
        {
            boardService.SaveNotificationPreferences(viewModel);
            return RedirectToAction(nameof(Index), new { id = viewModel.BoardId });
        }
    }
}