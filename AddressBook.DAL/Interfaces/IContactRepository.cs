using AddressBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL.Interfaces
{
    public interface IContactRepository : IDisposable
    {
        public IEnumerable<Contact> GetAllContacts();
        public Task<Contact> GetContactAsync(Guid id);
        public Task CreateContactAsync(Contact contact);
        public void UpdateContact(Contact contact);
        public void RemoveContact(Contact contact);
    }
}
