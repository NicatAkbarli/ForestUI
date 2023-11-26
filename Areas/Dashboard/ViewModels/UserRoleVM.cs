using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forest.Models;
using Microsoft.AspNetCore.Identity;

namespace Forest.Areas.Dashboard.ViewModels
{
   public class UserRoleVM
{
    public User User { get; set; }
    public List<IdentityRole> Roles { get; set; }
}
}