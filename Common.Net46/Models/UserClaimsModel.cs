using Common.Net46.Interfaces;
using System.Collections.Generic;

namespace Common.Net46.Models
{
    public class UserClaimsModel : IUserClaims
    {
        public UserClaimsModel()
        {
            Claims = new Dictionary<string, string>();
            Claims.Add("FullName", "Test Test");
            Claims.Add("Email", "talkingaddress@gmail.com");
        }
        public string UserId { get; set; } = "test";
        public Dictionary<string, string> Claims { get; set; }
    }
}
