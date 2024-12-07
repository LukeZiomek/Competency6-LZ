using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IContactsDAL
    {
        // Read
        public Task<List<Contact>> GetAllAsync();
        public Task<List<Contact>> GetAllOpenAsync();
        public Task<Contact> GetByIdAsync(Guid id);
        // Create
        public Task AddAsync(Contact toAdd);
        // Update
        public Task UpdateAsync(Contact toUpdate);
    }
}
