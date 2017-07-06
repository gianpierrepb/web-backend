using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Moments.Models.DataModels
{
    public class Photo
    {

        [Key]
        public int id { get; set; }

        public int MomentId { get; set; }

        public string url { get; set; }
        
        public string path { get; set; }

        [ForeignKey("MomentId")]
        public virtual Moment moment { get; set; }
    }
}