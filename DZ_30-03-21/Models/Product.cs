using System.ComponentModel.DataAnnotations.Schema;
namespace DZ_30_03_21.Models
{
	public class Product
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
	}
}