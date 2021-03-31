
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DZ_30_03_21.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}