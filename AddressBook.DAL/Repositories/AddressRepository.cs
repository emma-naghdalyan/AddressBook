using AddressBook.DAL.Interfaces;
using AddressBook.DAL.Entities;
using AddressBook.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories
{
    public class AddressRepository : IAddressRepository, IDisposable
    {
        private ApplicationDbContext _dbContext;

        private bool disposed = false;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            return address;
        }

        public void UpdateAddress(Address address)
        {
            _dbContext.Addresses.Update(address);
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

        public IEnumerable<Address> GetAllAddresses()
        {
            return _dbContext.Addresses.ToList();
        }
    }
}
