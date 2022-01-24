using AFIRegistrationAPI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AFIRegistrationAPI.Models
{
    [Table("Cust")]
    public class Customer :IValidatableObject
    {
                

            [Key]
            public int Id { get; set; }

            [StringLength(50, MinimumLength =3)]
            public String Firstname { get; set; }


            [StringLength(50, MinimumLength = 3)]
            public String Surname { get; set; }

            [Required]
            [RegularExpression(@"^([A-Z]){2}([\-]){1}([0-9]){6}$",ErrorMessage = "Please enter a valid Policy Number")]
            public string PolicyNumber { get; set; }

            [Required]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage = "Please enter a valid Email")]
            public string Email { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {

                var currentAge = DateTime.Now.Year - DateOfBirth.Year; 

                if (currentAge<Constants.PolicyHolderAge )
                {
                yield return new ValidationResult(
                    ErrorMessages.UserNotAllowed,
                    new[] { nameof(DateOfBirth) });
                }
            }

    }
}

