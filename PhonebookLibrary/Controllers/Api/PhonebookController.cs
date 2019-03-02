using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhonebookLibrary.Models;
using PhonebookLibrary.Models.DataModels;
using PhonebookLibrary.Services;

namespace PhonebookLibrary.Controllers.Api
{
    [ApiController, Route("api/[controller]")]
    public class PhonebookController : Controller
    {
        private readonly IDataService<PhoneBook> _dataService;
        private readonly ILogger<PhonebookController> _logger;

        public PhonebookController(IDataService<PhoneBook> dataService, ILogger<PhonebookController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var phonebooks = await _dataService.GetAll();

                var phonebooksVm = phonebooks.OrderBy(p => p.Name).GroupBy(p => p.Name.ToUpper()[0], (index, items) => new PhoneBookViewModel
                {
                    Index = index,
                    PhoneBooks = items
                }).ToList();

                return Ok(phonebooksVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failure.");
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _dataService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failure.");
                throw;
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(PhoneBook phonebook)
        {
            try
            {
                await _dataService.Add(phonebook);
                return await Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add data");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
