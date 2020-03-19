using Donatello2020.Infrastructure;
using Donatello2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.Services
{
    public class BoardService
    {
        private readonly Donatello2020Context dbContext;
        public BoardService(Donatello2020Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public BoardList ListBoard()
        {
            var model = new BoardList();

            //var board = new BoardList.Board();
            //board.Title = "Mehmet's Board";

            //model.Boards.Add(board);

            //var anotherBoard = new BoardList.Board();
            //anotherBoard.Title = "Another Board";

            //model.Boards.Add(anotherBoard);

            foreach (var board in dbContext.Boards)
            {
                model.Boards.Add(new BoardList.Board
                {
                    Title = board.Title
                });
            }
            return model;
        }

        internal int AddBoard(NewBoard viewModel)
        {
            dbContext.Boards.Add(new Models.Board
            {
                Title = viewModel.Title
            });

            int effectedResultCount = dbContext.SaveChanges();
            return effectedResultCount;
        }

        public BoardView GetBoard()
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
            return model;
        }
    }
}
