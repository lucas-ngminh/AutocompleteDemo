using AutoCompleteAngularJSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AutoCompleteAngularJSDemo.Controllers.WebAPI
{
    [RoutePrefix("api/AutoComplete")]
    public class AutoCompleteController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("SearchUsersByFilter/{filter?}")]
        public HttpResponseMessage SearchUsersByFilter(string filter = null)
        {
            HttpResponseMessage response = null;

            if (!string.IsNullOrEmpty(filter))
            {
                byte[] data = Convert.FromBase64String(filter);
                filter = Encoding.UTF8.GetString(data);
            }

            List<SearchItemVM> searchItems = SearchItemsByFilter(filter);

            HttpRequestMessage request = new HttpRequestMessage();
            var configuration = new HttpConfiguration();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            response = request.CreateResponse(HttpStatusCode.OK, searchItems);

            return response;
        }

        private List<SearchItemVM> SearchItemsByFilter(string filter)
        {
            List<SearchItemVM> users = new List<SearchItemVM>();
            users.Add(new SearchItemVM() { ID = 1, Name = "Lucas Nguyen", Sub = "lucas@lucasology.com", Type = "User" });
            users.Add(new SearchItemVM() { ID = 2, Name = "Eric Lu", Sub = "eric@lucasology.com", Type = "User" });
            users.Add(new SearchItemVM() { ID = 3, Name = "Rachel Horseman", Sub = "rachel@lucasology.com", Type = "User" });
            return users.Where(u => u.Name.ToLower().Contains(filter.ToLower())).ToList();
        }
    }
}
