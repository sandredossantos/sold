using MediatR;
using Sold.Services.Identity.Application.DTOs;

namespace Sold.Services.Identity.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserCommandResult>
    {
        public UserDTO User { get; set; }
    }
}