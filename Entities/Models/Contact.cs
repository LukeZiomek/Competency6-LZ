using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Contact
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The name of your company is required"), MinLength(3, ErrorMessage = "Company name must be 3 or more characters")]
        public string CompanyName { get; set; }
        public bool FinancialInterest { get; set; }
        public bool ShippingInterest { get; set; }
        public bool InvAccountingInterest { get; set; }
        [Required(ErrorMessage = "An E-Mail address is required"), RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,63}\b", ErrorMessage = "Email must match format of 'you@example.com'")]
        public string EmailAddress {  get; set; }
        [Required(ErrorMessage = "A phone number is a required"), RegularExpression(@"[(]?\d{3}[)]?\s?-?\s?\d{3}\s?-?\s?\d{4}", ErrorMessage = "Phone Number must match format of '(808) 123-4567'")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Your website URL is required"), RegularExpression(@"(https?:\/\/)?([\da-z\.-]+\.[a-z\.]{2,63}|[\d\.]+)([\/:?=&#]{1}[\da-z\.-]+)*[\/\?]?", ErrorMessage = "Must be a valid URL")]
        public string Website {  get; set; }
        public DateTime SubmittedDate { get; set; } // Auto submitted
        public string? Remarks { get; set; }
        public bool RespondedTo { get; set; }
        public DateTime? respondedDate { get; set; }
    }
}
