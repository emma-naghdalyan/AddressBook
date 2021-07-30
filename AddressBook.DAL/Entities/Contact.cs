using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
