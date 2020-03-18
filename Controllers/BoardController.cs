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
        public IActionResult Index()
        {
            BoardView model = boardService.GetBoard();

            return View(model);
        }

     
    }
}