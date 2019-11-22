using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AssetManagement.Inftrastructure.FIlters
{
    public class ValidateModelActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            object value = null;
            if (context.ActionArguments.Keys.Contains("value"))
            {
                value = context.ActionArguments["value"];
            }
            if (value == null)
            {
                context.Response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                context.Response.ReasonPhrase = "Invalid or no object was sent";
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Response = new System.Net.Http.HttpResponseMessage() {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent(JsonConvert.SerializeObject(context.ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray()))
                };
                
                return;
            }
        }
    }
}