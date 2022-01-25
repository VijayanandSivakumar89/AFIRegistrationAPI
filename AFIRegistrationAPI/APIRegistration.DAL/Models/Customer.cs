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

            [Required]
            [StringLength(50, MinimumLength =3)]
            public String Firstname { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public String Surname { get; set; }

            [Required]
            [RegularExpression(RegularExpressions.PolicyNumberRegex, ErrorMessage = ErrorMessages.InvalidPolicyNumber)]
            public string PolicyNumber { get; set; }

            [Required]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [RegularExpression(RegularExpressions.EmailRegex, ErrorMessage = ErrorMessages.InvalidEmailAddress)]
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

