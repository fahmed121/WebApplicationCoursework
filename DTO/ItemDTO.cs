using System.ComponentModel.DataAnnotations;
namespace WebApplicationCourseWork.DTO
{
    public class ItemDTO
    {

        [Required]
        [StringLength(25)]
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}