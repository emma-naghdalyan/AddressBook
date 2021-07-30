using AddressBook.DAL.Entities;
using AddressBook.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Infrastructure.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<IEnumerable<Contact>, List<ContactViewModel>>();
            CreateMap<ContactViewModel, Contact>();
        }
    }
}
