using System.ComponentModel.DataAnnotations;
namespace DZ_30_03_21.ViewModels
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Ошибка в названии")]
		[MinLength(3)]
		[MaxLength(50)]
        [Display(Name = "Название категории")]
		public string Name { get; set; }
	}
}