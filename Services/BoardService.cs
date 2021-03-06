﻿using Donatello2020.Helpers;
using Donatello2020.Infrastructure;
using Donatello2020.Models;
using Donatello2020.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Donatello2020.Services
{
    public class BoardService
    {
        private readonly Donatello2020Context dbContext;
        private readonly Emails emails;
        public BoardService(Donatello2020Context dbContext, Emails emails)
        {
            this.dbContext = dbContext;
            this.emails = emails;
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
                    Id = board.Id,
                    Title = board.Title,
                    BackgroundColor = board.Color,
                });
            }
            return model;
        }

        public void SetTitle(SetTitleCommand command)
        {
            var board = dbContext.Boards.SingleOrDefault(x => x.Id == command.BoardId);
            board.Title = command.Title;
            dbContext.SaveChanges(); 
        }

        public void AddCard(AddCard viewModel)
        {
            var board = dbContext.Boards
                .Include(b => b.Columns)
                .SingleOrDefault(x => x.Id == viewModel.Id);

            var firstColumn = board.Columns.FirstOrDefault();
            if (firstColumn == null)
            {
                firstColumn = new Models.Column { Title = "Todo" };
                board.Columns.Add(firstColumn);
            }


            firstColumn.Cards.Add(new Models.Card
            {
                Contents = viewModel.Contents
            });

            dbContext.SaveChanges();
        }

        public NotificationSettings GetNotificationPreferences(int boardId, int columnId)
        {
            var column = dbContext.Columns.SingleOrDefault(x => x.Id == columnId);
            return new NotificationSettings
            {
                BoardId = boardId,
                ColumnId = columnId,
                EmailAddress = column.NotificationEmail
            };
        }

        public void SaveNotificationPreferences(NotificationSettings viewModel)
        {
            var column = dbContext.Columns.SingleOrDefault(x => x.Id == viewModel.ColumnId);
            column.NotificationEmail = viewModel.EmailAddress;
            dbContext.SaveChanges();
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

        public BoardView GetBoard(int id)
        {
            var model = new BoardView();

            var board = dbContext.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .SingleOrDefault(x => x.Id == id);

            model.Id = board.Id;
            model.Title = board.Title;
            model.Color = board.Color;

            foreach (var column in board.Columns)
            {
                var modelColumn = new BoardView.Column();

                modelColumn.Id = column.Id;
                modelColumn.Title = column.Title;

                foreach (var card in column.Cards)
                {
                    var modelCard = new BoardView.Card();
                    modelCard.Id = card.Id;
                    modelCard.Content = card.Contents;
                    modelColumn.Cards.Add(modelCard);
                }
                model.Columns.Add(modelColumn);
            }
            return model;
        }

        public void Move(MoveCardCommand command)
        {
            var card = dbContext.Cards.SingleOrDefault(x => x.Id == command.CardId);
            card.ColumnId = command.ColumnId;
            dbContext.SaveChanges();

            var column = dbContext.Columns.SingleOrDefault(x => x.Id == command.ColumnId);

            emails.SendCardMovedNotification(card, column);
        }

      

        public void SetColor(SetColorCommand command)
        {
            var board = dbContext.Boards.SingleOrDefault(x => x.Id == command.BoardId);
            board.Color = command.Color;
            dbContext.SaveChanges();
        }
    }
}
