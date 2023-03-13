

using WebApi.Domain.DataModels;

namespace WebApi.Repository.RepositoryActions
{
    public interface IContactRepository
    {
        public IEnumerable<ContactDetails> GetContactList();
        public ContactDetails GetSelectedContact(int id);
        public void AddContact(ContactDetails employee);
        public void UpdateContact(ContactDetails employee);
        public bool DeleteContact(int id);
        public bool FindContact(int id);
    }
}
