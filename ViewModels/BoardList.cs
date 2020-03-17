﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.ViewModels
{
    public class BoardList
    {
        public List<Board> Boards { get; set; } = new List<Board>();
        public class Board
        {
            public string Title { get; set; }
        }

    }
}
