using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain.Enums;

namespace TaskManagementApplication.Interfaces
{
    public  interface ICurrentUserService
    {

        int UserId { get; }
        UserRole Role { get; }
    }
}
