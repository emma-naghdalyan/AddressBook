using AddressBook.Domain.Exceptions;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.BLL.Interfaces;
using AutoMapper;
using AddressBook.DAL.Entities;

// Database added using Code first method.

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var allContacts = _contactService.GetAllContacts();

            var contactViewModels = _mapper.Map<IEnumerable<ContactViewModel>>(allContacts);

            return View(contactViewModels);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var contact = await _contactService.GetSingleContactAsync(id);
                var contactViewModel = _mapper.Map<ContactViewModel>(contact);
                return View(contactViewModel);
            }
            catch (NotFoundException)
            {
                //return NotFound();
                return RedirectToAction("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var destination = _mapper.Map<Contact>(contact);
                    await _contactService.CreateContactAsync(destination);
                    return RedirectToAction("Index");
                }
                catch (NullReferenceException)
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var contact = await _contactService.GetSingleContactAsync(id);
                var contactViewModel = _mapper.Map<ContactViewModel>(contact);
                return View(contactViewModel);
            }
            catch (NotFoundException)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactViewModel contactViewModel)
        {
            try
            {
                var contact = _mapper.Map<Contact>(contactViewModel);
                await _contactService.UpdateContactAsync(contact);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _contactService.DeleteContactAsync(id);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
