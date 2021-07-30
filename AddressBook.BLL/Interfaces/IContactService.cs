using AddressBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.BLL.Interfaces
{
    public interface IContactService
    {
        public IEnumerable<Contact> GetAllContacts();
        public Task<Contact> GetSingleContactAsync(Guid id);
        public Task<Guid> CreateContactAsync(Contact contact);
        public Task<Guid> UpdateContactAsync(Contact contact);
        public Task<Guid> DeleteContactAsync(Guid id);
    }
}
