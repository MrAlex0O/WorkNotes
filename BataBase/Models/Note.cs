using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Note : BaseModel
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}
