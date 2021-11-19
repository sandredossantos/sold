using Sold.Services.Identity.Domain.Entities;
using Xunit;

namespace Sold.Services.Identity.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        [Trait(nameof(User), nameof(User.ChangeMail))]
        public void User_Change_Mail()
        {
            //arrange
            var user = new User("Uncle Bob", "unclebob@mail.com", "+551199998888");

            var mail = "bob@mail.com";

            //act
            user.ChangeMail(mail);

            //assert
            Assert.Equal(mail, user.Mail);
        }

        [Fact]
        [Trait(nameof(User), nameof(User.ChangePhone))]
        public void User_Change_Phone()
        {
            //arrange
            var user = new User("Uncle Bob", "unclebob@mail.com", "+551199998888");

            var phone = "+551199997777";

            //act
            user.ChangePhone(phone);

            //assert
            Assert.Equal(phone, user.Phone);
        }
    }
}