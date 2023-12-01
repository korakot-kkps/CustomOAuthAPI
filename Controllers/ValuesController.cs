using CustomOAuthAPI.OAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomOAuthAPI.Controllers
{
    [Authorize]
    //[EnableCors(origins: "http://localhost:3000/", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/userinfo
        [Route("api/otp-get")]
        [HttpGet]
        public async Task<HttpResponseMessage> OtpGet()
        {
            var user = User.Identity as ClaimsIdentity;
            var userJson = new UserResponse() { username = user.FindFirst("UserName").Value, fullname = user.Name, role = user.FindFirst(ClaimTypes.Role).Value, email = user.FindFirst(ClaimTypes.Email).Value };
            var resp = Request.CreateResponse<dynamic>(HttpStatusCode.OK, userJson);
            return resp;
        }

        // GET api/userinfo
        [Route("api/otp-submit")]
        [HttpPost]
        public async Task<HttpResponseMessage> OtpSubmit(string otp)
        {
            var user = User.Identity as ClaimsIdentity;
            var userJson = new UserResponse() { username = user.FindFirst("UserName").Value, fullname = user.Name, role = user.FindFirst(ClaimTypes.Role).Value, email = user.FindFirst(ClaimTypes.Email).Value };
            var resp = Request.CreateResponse<dynamic>(HttpStatusCode.OK, userJson);
            return resp;
        }

        // GET api/userinfo
        [Route("api/logout")]
        [HttpPost]
        public async Task<HttpResponseMessage> Logout(string otp)
        {
            var user = User.Identity as ClaimsIdentity;
            var userJson = new UserResponse() { username = user.FindFirst("UserName").Value, fullname = user.Name, role = user.FindFirst(ClaimTypes.Role).Value, email = user.FindFirst(ClaimTypes.Email).Value };
            var resp = Request.CreateResponse<dynamic>(HttpStatusCode.OK, userJson);
            return resp;
            //await HttpContext.SignOutAsync();
            //return Redirect(Url.Content("~/"));

        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
