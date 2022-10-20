using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class NoteCategory : BaseModel
    {
        public Note Note { get; set; }
        public Guid NoteId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
