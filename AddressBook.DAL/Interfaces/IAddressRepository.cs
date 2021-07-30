using AddressBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL.Interfaces
{
    public interface IAddressRepository : IDisposable
    {
        public Task<Address> GetAddressAsync(int id);
        public IEnumerable<Address> GetAllAddresses();
        public void UpdateAddress(Address address);
    }
}
