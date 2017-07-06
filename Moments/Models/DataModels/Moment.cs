using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Moments.Models.DataModels
{
    public class Moment
    {
        public Moment()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int id { get; set; }
        public string UserId { get; set; }
        public string latitud { get; set; }
        public string altitud { get; set; }
        public string description { get; set; }
        public bool deleted { get; set; }
        public int duration { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> comments { get; set; }
    }
}