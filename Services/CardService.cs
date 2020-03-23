using Donatello2020.Infrastructure;
using Donatello2020.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.Services
{
    public class CardService
    {
        private readonly Donatello2020Context dbContext;
        public CardService(Donatello2020Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public CardDetails GetDetails(int id)
        {
            var card = dbContext
                .Cards
                .Include(c => c.Column)
                .SingleOrDefault(x => x.Id == id);
            if (card == null)
                return new CardDetails();

            // 2. retrieve the board
            var board = dbContext
                .Boards
                .Include(b => b.Columns)
                .SingleOrDefault(b => b.Id == card.Column.BoardId);

            // 3. map the boards columns
            var availableColumns = board
                .Columns
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                });

            return new CardDetails
            {
                Id = card.Id,
                Contents = card.Contents,
                Notes = card.Notes,
                Columns = availableColumns.ToList(),
                Column = card.ColumnId
            };
        }

        public void Update(CardDetails cardDetails)
        {
            var card = dbContext.Cards.SingleOrDefault(x => x.Id == cardDetails.Id);
            card.Contents = cardDetails.Contents;
            card.Notes = cardDetails.Notes;
            card.ColumnId = cardDetails.Column;

            dbContext.SaveChanges();
        }
    }
}
