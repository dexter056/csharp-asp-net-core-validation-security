using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (EmailAddress == null)
            {
                validationResults.Add(new ValidationResult("Email address is required", new[] { "EmailAddress" }));
                return validationResults;
            }

            if (EmailAddress.EndsWith("TechnologyLiveConference.com", StringComparison.InvariantCultureIgnoreCase))
                validationResults.Add(new ValidationResult("Technology Live Conference staff should not use their conference email addresses.",
                    new[] { "EmailAddress" }));

            return validationResults;
        }
    }
}