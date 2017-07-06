using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moments.Models.DataModels
{
    public class Plan
    {

        public Plan() {
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int id { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public virtual ICollection<ApplicationUser> users { get; set; }
    }
}