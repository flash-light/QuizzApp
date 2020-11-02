using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizzes.Application;
using Quizzes.Common.Models;

namespace QuizzesApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public HomeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpPost("Index")]
        public ActionResult<ServiceResult<TestModelDTO>> Index([FromBody]TestModelDTO model)
        {            
            return new ServiceResult<TestModelDTO> { Success = true, Data = model };
        }

        

    }
}
