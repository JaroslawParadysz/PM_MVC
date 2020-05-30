using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM_MVC.ViewModels
{
    public class UserErrorViewModel
    {
        public Guid UserErrorId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Notes { get; set; }
    }
}
