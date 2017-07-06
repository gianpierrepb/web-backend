using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Moments.Models.DataModels
{
    public partial class Comment
    {
        [Key]
        public int id { get; set; }
        public string UserId { get; set; }
        public int MomentId { get; set; }
        public string description { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("MomentId")]
        public virtual Moment Moment { get; set; }

        public virtual ICollection<Comment> comments { get; set; }
    }


}