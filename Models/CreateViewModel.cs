using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class MyDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime d = Convert.ToDateTime(value);
                Console.WriteLine("Working on Date Validation in MODELS CreateViewModel");
                return d <= DateTime.Now;

            }
        } 
    public class CreateViewModel: BaseEntity
    {
        [Required(ErrorMessage="Reviewer Name is required...")]
        [StringLength(255, ErrorMessage="Review Name requires 2 to 255 characters...", MinimumLength=2)]
        public string reviewer { get; set; }

        [Required(ErrorMessage="Restaurant Name is required...")]
        [StringLength(255, ErrorMessage="Restaurant Name requires 2 to 255 characters...", MinimumLength=2)]
        public string restaurant { get; set; }
        
        [Required(ErrorMessage="A Review is required...")]
        [StringLength(5000, ErrorMessage="A review requires 25 to 5000 characters...", MinimumLength=25)]
        public string review { get; set; }
        
        [Required]
        [MyDate(ErrorMessage="Date of Visit must be in the past...")]
        public DateTime dateofvisit { get; set; }
        public string stars { get; set; }
    }
}