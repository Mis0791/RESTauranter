using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Rest 
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Reviewer Name")]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        [MinLength(2)]
        public string RestName { get; set; }

        [Required]
        [Display(Name = "Review")]
        [MinLength(8)]
        public string Review { get; set; }

        [Required]
        [Display(Name = "Date of Visit")]
        [MyDate(ErrorMessage = "Invalid Date")]
        public DateTime DateofVisit { get; set; }

        [Required]
        [Display(Name = "Stars")]
        public int Rating { get; set; }
    }

    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d <= DateTime.Now;
        }
    }
}