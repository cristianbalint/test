using Common.Net46.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Interfaces
{
    public interface IUserClaims
    {
        string UserId { get; set; }
        Dictionary<string, string> Claims { get; set; }
    }
}
