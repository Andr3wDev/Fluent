using FluentValidation.Results;
using FluentWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Developer developer)
        {
            DeveloperValidator validator = new DeveloperValidator();
            List<string> ValidationMessages = new List<string>();

            var dev = new Developer
            {
                FirstName = "",
                Email = "bob@bob.bob"
            };

            var validationResult = validator.Validate(dev);
            var response = new ResponseModel();

            if (!validationResult.IsValid)
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.ValidationMessages = ValidationMessages;
            }

            return Ok(response);
        }
    }
}
