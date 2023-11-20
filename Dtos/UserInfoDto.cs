using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forest.Dtos;

public class UserInfoDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhotoUrl { get; set; }
}