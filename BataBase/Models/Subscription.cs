using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Subscription : BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
    }
}
