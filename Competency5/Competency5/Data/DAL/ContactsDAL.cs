using Entities.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Competency5.Data.DAL
{
    public class ContactsDAL : IContactsDAL
    {
        private readonly ApplicationDbContext _context;
        public ContactsDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        // Read
        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.OrderBy(c=>c.SubmittedDate).ToListAsync();
        }

        public async Task<List<Contact>> GetAllOpenAsync()
        {
            return await _context.Contacts.Where(c=>c.RespondedTo == false).ToListAsync();
        }

		public async Task<Contact> GetByIdAsync(Guid id)
		{
			return await _context.Contacts.Where(c => c.ID == id).FirstOrDefaultAsync();
		}

		// Create
		public async Task AddAsync(Contact toAdd)
        {
            _context.Contacts.Add(toAdd);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Contact updated)
        {
            _context.Contacts.Update(updated);
            await _context.SaveChangesAsync();
        }
	}
}
