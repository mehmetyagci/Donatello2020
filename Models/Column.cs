using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }
}
