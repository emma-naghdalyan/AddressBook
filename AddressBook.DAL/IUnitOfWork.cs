using AddressBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public interface IUnitOfWork
    {
        public IAddressRepository Addresses { get; }
        public IContactRepository Contacts { get; }
        public Task Commit();
    }
}
