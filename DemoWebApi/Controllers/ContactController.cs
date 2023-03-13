using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.BusinessLogic.Services;
using WebApi.Domain.DataModels;

namespace DemoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _actions;
        private IMapper _mapper;
        public ContactController(IContactServices actions,IMapper mapper)
        {
            _actions = actions;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User,user,admin")]
        public IActionResult GetContactDetails()
        {
           var ContactList = _actions.GetContactList();
            return Ok(_mapper.Map<List<ContactDTO>>(ContactList));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,user,admin")]
        public IActionResult GetSelectedContact(int id)
        {
            var contact = _actions.GetSelectedContact(id);
            if(contact == null)
            {
                return NotFound("Contact Not found");
            }
            return Ok(_mapper.Map<ContactDTO>(contact));
        }
        [HttpPost]
        [Authorize(Roles  ="User,user")]
        public IActionResult AddContact([FromBody] ContactInformation contactDetails)
        {
           
           var contact = _mapper.Map<ContactDetails>(contactDetails);
            _actions.AddContact(contact);
            return Ok(_mapper.Map<ContactDTO>(contact));
        }
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin,admin")]
        public IActionResult UpdateContact([FromBody] ContactDTO contactDetails, int id)
        {
            if (_actions.FindContact(id))
            {
                var contact = _mapper.Map<ContactDetails>(contactDetails);
                _actions.UpdateContact(contact);
                return Ok(_mapper.Map<ContactDTO>(contact));
            }
            return NotFound("Contact Not found");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin,admin")]
        public IActionResult DeleteContact([FromBody] int id) 
        {
            var contact = _mapper.Map<ContactDTO>(_actions.GetSelectedContact(id));
            if (_actions.DeleteContact(id))
            {
                return Ok(contact);
            }
            return NotFound("Contact Not Found");
        }

    }
}
