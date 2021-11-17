using AutoMapper;
using FluentValidation;
using MediatR;
using Sold.Services.Core.Data;
using Sold.Services.Identity.Application.Commands;
using Sold.Services.Identity.Application.DTOs;
using Sold.Services.Identity.Data.Repositories;
using Sold.Services.Identity.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Application.Handlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserCommand> _validator;

        public UserCommandHandler(
            IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository, IValidator<CreateUserCommand> validator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<CreateUserCommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            var user = _mapper.Map<User>(command.User);

            await _userRepository.AddAsync(user);

            await _unitOfWork.Commit().ConfigureAwait(false);

            var result = new CreateUserCommandResult
            {
                User = _mapper.Map<UserDTO>(user)
            };

            return result;
        }
    }
}