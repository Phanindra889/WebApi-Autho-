
using Dapper.Contrib.Extensions;
using System.Data;
using WebApi.Domain.DataModels;
using WebApi.Repository.Context;

namespace WebApi.Repository.RepositoryActions
{
    public class ContactRepository: IContactRepository
    {
        private readonly IDapperContext _context;
        public ContactRepository(IDapperContext context)
        {
            _context = context;
        }
        public IEnumerable<ContactDetails> GetContactList()
        {
            var contactList =  _context.Connection.GetAll<ContactDetails>().ToList();
            return  contactList;
        }
        public void AddContact(ContactDetails contact)
        {
            _context.Connection.Insert(contact);
        }
        public ContactDetails GetSelectedContact(int id)
        {
            return _context.Connection.Get<ContactDetails>(id);
        }
        public void UpdateContact(ContactDetails contact )
        {
           _context.Connection.Update(contact);
        }
        public bool DeleteContact(int id)
        {
            var contact = _context.Connection.Get<ContactDetails>(id);
            if (contact != null)
            {
                return _context.Connection.Delete(contact);
            }
            return false;
        }
        public bool FindContact(int id)
        {
            if(_context.Connection.Get<ContactDetails>(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
