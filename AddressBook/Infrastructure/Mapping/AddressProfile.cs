using AddressBook.DAL.Entities;
using AddressBook.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.UI.Infrastructure.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressViewModel, Address>();
            CreateMap<Address, AddressViewModel>();
        }
    }
}
