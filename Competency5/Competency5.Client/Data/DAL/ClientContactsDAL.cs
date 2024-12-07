using Entities.Interfaces;
using Entities.Models;
using System.Net.Http.Json;

namespace Competency5.Client.Data.DAL
{
    public class ClientContactsDAL : IContactsDAL
    {
        // Http Client
        private HttpClient _http;

        public ClientContactsDAL(HttpClient http) 
        {
            _http = http;
        }

        // Create
        public async Task AddAsync(Contact toAdd)
        {
            await _http.PostAsJsonAsync<Contact>("api/contacts", toAdd);
        }

        // Read
        public async Task<List<Contact>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Contact>>("api/contacts") ?? new List<Contact>();
        }

        public async Task<List<Contact>> GetAllOpenAsync()
        {
            return await _http.GetFromJsonAsync<List<Contact>>("api/contacts/open") ?? new List<Contact>();
        }

		public async Task<Contact> GetByIdAsync(Guid id)
		{
			return await _http.GetFromJsonAsync<Contact>($"api/contacts/{id}") ?? new Contact();
		}

		// Update
		public async Task UpdateAsync(Contact toUpdate)
        {
            await _http.PatchAsJsonAsync<Contact>("api/contacts", toUpdate);
        }
	}
}
