using Entities.Interfaces;
using Entities.Models;

namespace Competency5.Data.Mock
{
    public class ContactsMockDAL : IContactsDAL
    {
        // Our "Database" :)
        private List<Contact> _contacts = new List<Contact>()
        {
            new Contact
            {
                ID = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                CompanyName = "Company1 LTD",
                FinancialInterest = true,
                ShippingInterest = false,
                InvAccountingInterest = false,
                EmailAddress = "john@example.com",
                PhoneNumber = "(808) 123-4567",
                Website = "www.example.com",
                SubmittedDate = new DateTime((DateTime.Today.Year - 1), DateTime.Today.Month, DateTime.Today.Day),
                RespondedTo = false,
                Remarks = null,
                respondedDate = null
            },
            new Contact
            {
                ID = Guid.NewGuid(),
                FirstName = "Jack",
                LastName = "Doe",
                CompanyName = "Company2 LLC",
                FinancialInterest = false,
                ShippingInterest = true,
                InvAccountingInterest = false,
                EmailAddress = "jack@example.com",
                PhoneNumber = "(808) 321-7654",
                Website = "www.example.com",
                SubmittedDate = new DateTime((DateTime.Today.Year - 1), DateTime.Today.Month, DateTime.Today.Day),
                RespondedTo = false,
                Remarks = null,
                respondedDate = null
            },
            new Contact
            {
                ID = Guid.NewGuid(),
                FirstName = "Mark",
                LastName = "Smith",
                CompanyName = "Company3 GmbH",
                FinancialInterest = true,
                ShippingInterest = false,
                InvAccountingInterest = true,
                EmailAddress = "mark@example.com",
                PhoneNumber = "(808) 987-6543",
                Website = "www.example.com",
                SubmittedDate = DateTime.Today,
                RespondedTo = false,
                Remarks = null,
                respondedDate = null
            }
        };

        // Create
        public async Task AddAsync(Contact toAdd)
        {
            _contacts.Add(toAdd);
            await Task.CompletedTask;
        }

        // Read
        public async Task<List<Contact>> GetAllAsync()
        {
            return await Task.FromResult(_contacts.OrderBy(c => c.SubmittedDate).ToList());
        }

        public async Task<List<Contact>> GetAllOpenAsync()
        {
            return await Task.FromResult(_contacts.Where(c => c.RespondedTo == false).ToList());
        }

		public Task<Contact> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		// Update
		public async Task UpdateAsync(Contact updated)
        {
            await Task.FromResult(_contacts[_contacts.IndexOf(updated)] = updated);
            
        }
        
    }
}
