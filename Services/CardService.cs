using Donatello2020.Infrastructure;
using Donatello2020.ViewModels;
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
            var card = dbContext.Cards.SingleOrDefault(x => x.Id == id);
            if (card == null)
                return new CardDetails();

            return new CardDetails
            {
                Id = card.Id,
                Contents = card.Contents,
                Notes = card.Notes
            };
        }

        public void Update(CardDetails cardDetails)
        {
            var card = dbContext.Cards.SingleOrDefault(x => x.Id == cardDetails.Id);
            card.Contents = cardDetails.Contents;
            card.Notes = cardDetails.Notes;

            dbContext.SaveChanges();
        }
    }
}
