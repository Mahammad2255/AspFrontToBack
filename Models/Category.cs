using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Teleb olunur"), MaxLength(50, ErrorMessage ="50den cox ola bilmez")]
        public string Name { get; set; }
        public string Description{ get; set; }
        public virtual ICollection<Product> Products{ get; set; }
    }
}
