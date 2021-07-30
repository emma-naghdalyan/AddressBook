using AddressBook.DAL.Interfaces;
using AddressBook.DAL.Repositories;
using AddressBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAddressRepository Addresses
        {
            get
            {
                return new AddressRepository(_dbContext);
            }
            private set { }
        }

        public IContactRepository Contacts 
        {
            get
            {
                return new ContactRepository(_dbContext);
            }
            private set { }
        }
        
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
