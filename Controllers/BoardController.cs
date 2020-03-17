using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello2020.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            var model = new BoardView();
            var column = new BoardView.Column { Title = "ToDo" };

            var card = new BoardView.Card
            {
                Content = "Here's a card"
            };

            var card2 = new BoardView.Card
            {
                Content = "Here's another card"
            };

            column.Cards.Add(card);
            column.Cards.Add(card2);

            model.Columns.Add(column);

            return View(model);
        }
    }
}