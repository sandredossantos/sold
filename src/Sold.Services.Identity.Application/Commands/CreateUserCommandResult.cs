using Sold.Services.Identity.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Application.Commands
{
    public class CreateUserCommandResult
    {
        public UserDTO User { get; set; }
    }
}