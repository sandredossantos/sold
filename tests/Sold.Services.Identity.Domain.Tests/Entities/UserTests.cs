using Xunit;
using System;
using Sold.Services.Identity.Domain.Entities;

namespace Sold.Services.Identity.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        [Trait(nameof(User), nameof(User.ChangeMail))]
        public void User_Change_Name()
        {
            //arrange
            var user = new User("Uncle Bob", "unclebob@mail.com", "+5511999-9999");

            var mail = "bob@mail.com";

            //act
            user.ChangeMail(mail);

            //assert
            Assert.Equal(mail, user.Mail);
        }
    }
}