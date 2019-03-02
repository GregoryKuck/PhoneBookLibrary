using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhonebookLibrary.Models;
using PhonebookLibrary.Models.DataModels;
using PhonebookLibrary.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhonebookLibrary.Controllers.Api
{
    [ApiController, Route("api/[controller]")]
    public class EntryController : Controller
    {
        private readonly IDataService<Entry> _dataService;
        private readonly ILogger<EntryController> _logger;

        public EntryController(IDataService<Entry> dataService, ILogger<EntryController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _dataService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failed");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entries = await _dataService.FindAll(e => e.PhoneBookId == id);

                var entriesVm = entries.OrderBy(p => p.Name).GroupBy(p => p.Name.ToUpper()[0], (index, items) => new EntriesViewModel
                {
                    Index = index,
                    Contacts = items
                }).ToList();

                return Ok(entriesVm);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failed");
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Entry entry)
        {
            try
            {
                await _dataService.Add(entry);
                return await Get(entry.PhoneBookId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add data");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SearchModel search)
        {
            try
            {
                IEnumerable<Entry> searchResults = new List<Entry>();

                if (search.PhoneBookId > 0)
                   searchResults = await _dataService.FindAll(e => e.PhoneBookId == search.PhoneBookId && (e.Name.Contains(search.SearchText) || e.PhoneNumber.Contains(search.SearchText)));
                else
                    searchResults = await _dataService.FindAll(e => e.Name.Contains(search.SearchText) || e.PhoneNumber.Contains(search.SearchText));

                var entriesVm = searchResults.OrderBy(p => p.Name).GroupBy(p => p.Name.ToUpper()[0], (index, items) => new EntriesViewModel
                {
                    Index = index,
                    Contacts = items
                }).ToList();

                return Ok(entriesVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to find data");
                throw;
            }
        }
    }
}
