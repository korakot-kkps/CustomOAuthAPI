using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomOAuthAPI.OAuth.Models
{
    public class UserResponse
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}