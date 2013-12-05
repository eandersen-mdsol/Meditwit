using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MediTwit.Services
{
    public class IdentityService : IIdentityService
    {
        public string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }

}