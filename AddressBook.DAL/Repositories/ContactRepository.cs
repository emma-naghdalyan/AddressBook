using AddressBook.DAL.Interfaces;
using AddressBook.DAL.Entities;
using AddressBook.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private ApplicationDbContext _dbContext;
        private bool disposed = false;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public async Task<Contact> GetContactAsync(Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            return contact;
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _dbContext.AddAsync(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _dbContext.Remove(contact);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
