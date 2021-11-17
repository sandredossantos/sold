using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sold.Services.Core.Data;
using Sold.Services.Identity.Application.Commands;
using Sold.Services.Identity.Application.Handlers;
using Sold.Services.Identity.Application.Mappers;
using Sold.Services.Identity.Application.Validators;
using Sold.Services.Identity.Data;
using Sold.Services.Identity.Data.Repositories;

namespace Sold.Services.Identity.Api
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<UserContext>());
            services.AddScoped<UserContext>();

            services.AddMappers();
            services.AddMediatR();
        }

        private static void AddMappers(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(mcf =>
            {
                mcf.AddProfile(new UserProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }

        private static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserCommandResult>, UserCommandHandler>();
        }
    }
}