using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourseWork.DTO
{
    public class CustomerDTO
    {
        public int CustID {get; set;}
        [Required]
        [StringLength(25)]
        public string CustFirstName {get; set;}
        [Required]
        [StringLength(25)]
        public string CustLastName {get; set;}
        [Required]
        [StringLength(13)] // 13 and string for international numbers
        public string Telephone {get; set;}
        [Required]
        [StringLength(50)]
        public string CustEmail {get; set;}
    }
}