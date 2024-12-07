using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Competency5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Dal
        private readonly IContactsDAL _dal;
        // Constructor
        public ContactsController(IContactsDAL dal)
        {
            _dal = dal;
        }

        // Create 
        [HttpPost]
        [Authorize]
        public async Task PostAsync(Contact contact)
        {
            await _dal.AddAsync(contact);
        }

        // Read
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dal.GetAllAsync());
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(Guid id)
		{
			return Ok(await _dal.GetByIdAsync(id));
		}

		[HttpGet("open")]
        public async Task<IActionResult> GetOpenAsync()
        {
            return Ok(await _dal.GetAllOpenAsync());
        }

        // Update
        [HttpPatch]
        [Authorize]
        public async Task PatchAsync(Contact contact)
        {
            await _dal.UpdateAsync(contact);
        }
    }
}
