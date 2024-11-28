using DynamicConfigurationManagement.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DynamicConfigurationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {            
            CustomSettingsResponse? response = _configuration.GetSection("CustomSettings").Get<CustomSettingsResponse>();
            return Ok(response);

        }
    }
}
