
using WebApi.Domain.DataModels;
using WebApi.Repository.RepositoryActions;

namespace WebApi.BusinessLogic.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository  _actions;
        public ContactServices(IContactRepository actions)
        {
            _actions = actions;
        }
        public IEnumerable<ContactDetails> GetContactList()
        {
            var contact=_actions.GetContactList();
            return contact;
        }
        public ContactDetails GetSelectedContact(int id)
        {
            return _actions.GetSelectedContact(id);
        }
        public void AddContact(ContactDetails contact)
        {
            _actions.AddContact(contact);
        }
        public bool FindContact(int id) 
        {
            return(_actions.FindContact(id));
        }
        public void UpdateContact(ContactDetails contact)
        {
            _actions.UpdateContact(contact);
        }
        public bool DeleteContact(int id)
        {
            return _actions.DeleteContact(id);
        }
    }
}
