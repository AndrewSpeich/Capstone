using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Youshare.Models
{
    public class Rooms
    {
        [Key]
        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]
        public string AdminID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("ApplicationUser")]
        public List<string> ModIDs { get; set; }

        public virtual List<ApplicationUser> ApplicationUsers { get; set; }

        [ForeignKey("Songs")]
        public Queue<string> SongIDs { get; set; }

        public virtual Queue<Songs> Songs { get; set; }

    }
}