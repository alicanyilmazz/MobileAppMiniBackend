using CoreBackend.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBackend.Shared.Filter
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.AddRange(errors);
                errorDto.Status = 400;
                errorDto.IsShow = true;

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
