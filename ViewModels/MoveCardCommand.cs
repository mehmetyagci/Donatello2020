using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Donatello2020.ViewModels
{
    public class MoveCardCommand
    {
        [JsonConverter(typeof(IntToStringConverter))]
        public int CardId { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public int ColumnId { get; set; }
    }
}
