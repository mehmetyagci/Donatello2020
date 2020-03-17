using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.ViewModels
{
    public class BoardView
    {
        public List<Column> Columns { get; set; } = new List<Column>();
        public class Column
        {
            public string Title { get; set; }
            public List<Card> Cards { get; set; } = new List<Card>();
        }

        public class Card
        {
            public string Content { get; set; }
        }
    }
}
