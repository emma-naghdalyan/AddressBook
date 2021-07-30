using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Where is your name ? ")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public AddressViewModel Address { get; set; }
        public int AddressId { get; set; }
    }
}
