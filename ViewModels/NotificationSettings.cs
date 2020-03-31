using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello2020.ViewModels
{
    public class NotificationSettings
    {
        // [Required]
        public int BoardId { get; set; }

        // [Required]
        public int ColumnId { get; set; }

        // [Required] 
        // [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
