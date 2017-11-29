using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("")]
    public IActionResult Get() => Ok("This is an updated controller asdfa");

    [HttpGet("{value}")]
    public IActionResult GetValue(string value) => Ok($"You sent {value}");

    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        return Ok("Secret is: " + _configuration.GetValue("a-secret", "defaultValue"));
    }

    [HttpGet("config")]
    public IActionResult GetConfig()
    {
        return Ok("Config is: " + _configuration.GetValue("a-config", "defaultValue"));
    }

    [HttpGet("override")]
    public IActionResult GetOverrided()
    {
        return Ok("Config is: " + _configuration.GetValue("overridable", "defaultValue"));
    }

}