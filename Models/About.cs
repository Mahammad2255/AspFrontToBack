using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFrontToBack.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
