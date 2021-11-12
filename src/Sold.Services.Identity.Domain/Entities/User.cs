using Sold.Services.Core.DomainObjects;

namespace Sold.Services.Identity.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Mail { get; private set; }
        public string Phone { get; private set; }

        public User(string name, string mail, string phone)
        {
            Name = name;
            Mail = mail;
            Phone = phone;
        }
        protected User() { }

        public void ChangeMail(string mail)
        {
            Mail = mail;
        }

        public void ChangePhone(string phone)
        {
            Phone = phone;
        }
    }
}