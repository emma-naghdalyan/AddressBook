using AddressBook.BLL.Interfaces;
using AddressBook.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.BLL.Injections
{
    public static class Extensions
    {
        public static void AddServiceInjections(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
