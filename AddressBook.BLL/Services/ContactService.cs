using AddressBook.BLL.Interfaces;
using AddressBook.DAL.Entities;
using AddressBook.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.DAL;

namespace AddressBook.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var query = from contact in _unitOfWork.Contacts.GetAllContacts()
                        join address in _unitOfWork.Addresses.GetAllAddresses() on contact.AddressId equals address.Id
                        select new Contact
                        {
                            Id = contact.Id,
                            FullName = contact.FullName,
                            Email = contact.Email,
                            PhoneNumber = contact.PhoneNumber,
                            AddressId = contact.AddressId,
                            Address = new Address
                            {
                                Country = address.Country,
                                City = address.City,
                                Street = address.Street,
                                ZIP = address.ZIP
                            }
                        };

            return query.ToList();
        }

        public async Task<Contact> GetSingleContactAsync(Guid id)
        {
            var contact = await _unitOfWork.Contacts.GetContactAsync(id);
            if (contact == null)
            {
                throw new NotFoundException($"There is no contact with id {id}");
            }
            var address = await _unitOfWork.Addresses.GetAddressAsync(contact.AddressId);
            if (address == null)
            {
                throw new NotFoundException($"There is no address with id {id}");
            }
            contact.Address = address;
            return contact;
        }

        public async Task<Guid> CreateContactAsync(Contact contact)
        {
            if (contact == null)
            {
                throw new NullReferenceException();
            }
            await _unitOfWork.Contacts.CreateContactAsync(contact);
            await _unitOfWork.Commit();
            return contact.Id;
        }

        public async Task<Guid> UpdateContactAsync(Contact contact)
        {
            var contactIn = await _unitOfWork.Contacts.GetContactAsync(contact.Id);
            if (contact == null)
            {
                throw new NotFoundException($"There is no contact with id {contact.Id}");
            }
            contactIn.FullName = contact.FullName;
            contactIn.Email = contact.Email;
            contactIn.PhoneNumber = contact.PhoneNumber;
            var addressIn = await _unitOfWork.Addresses.GetAddressAsync(contact.AddressId);
            if (addressIn == null)
            {
                throw new NotFoundException($"There is no address with id {contact.AddressId}");
            }
            addressIn.Country = contact.Address.Country;
            addressIn.City = contact.Address.City;
            addressIn.Street = contact.Address.Street;
            addressIn.ZIP = contact.Address.ZIP;
            _unitOfWork.Addresses.UpdateAddress(addressIn);
            _unitOfWork.Contacts.UpdateContact(contactIn);
            await _unitOfWork.Commit();
            return contactIn.Id;
        }

        public async Task<Guid> DeleteContactAsync(Guid id)
        {
            var contact = await _unitOfWork.Contacts.GetContactAsync(id);
            if (contact == null)
            {
                throw new NotFoundException($"There is no contact with id {id}");
            }
            _unitOfWork.Contacts.RemoveContact(contact);
            await _unitOfWork.Commit();
            return id;
        }
    }
}
