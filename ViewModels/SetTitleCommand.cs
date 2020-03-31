using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Donatello2020.ViewModels
{
    public class SetTitleCommand
    {
        public string Title { get; set; }

        [JsonConverter(typeof(IntToStringConverter))]
        public int BoardId { get; set; }
    }
}
