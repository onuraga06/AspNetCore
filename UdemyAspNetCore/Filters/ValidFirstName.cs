﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAspNetCore.Models;

namespace UdemyAspNetCore.Filters
{
    public class ValidFirstName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary= context.ActionArguments.FirstOrDefault(I => I.Key == "customer");

            var customer = dictionary.Value as Customer;
            if (customer.FirstName == "onur")
            {
                context.Result = new RedirectResult("/Home/Index");
            }
           
         
        }
    }
}
