﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello2020.Services;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello2020.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly BoardService boardService;
        public HomeController(BoardService boardService)
        {
            this.boardService = boardService;
        }
        public IActionResult Index()
        {
            BoardList model = boardService.ListBoard();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new NewBoard() ;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(NewBoard viewModel)
        {
            var effectedResultCount = boardService.AddBoard(viewModel);
            return RedirectToAction(nameof(Index));
        }


    }
}