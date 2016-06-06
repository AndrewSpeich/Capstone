using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Youshare.Models
{
    public class Songs
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Genrelist { get; set; }

        public string VideoID { get; set; }
    }
}