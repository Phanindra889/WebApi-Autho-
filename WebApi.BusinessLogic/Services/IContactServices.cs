
using WebApi.Domain.DataModels;

namespace WebApi.BusinessLogic.Services
{
    public interface IContactServices
    {
        public IEnumerable<ContactDetails> GetContactList();
        public ContactDetails GetSelectedContact(int id);
        public bool FindContact(int id);
        public void AddContact(ContactDetails contact);
        public void UpdateContact(ContactDetails contact);
        public bool DeleteContact(int id);
    }
}
