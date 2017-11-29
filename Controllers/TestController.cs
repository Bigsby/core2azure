using System.Collections.Generic;
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

    [HttpGet("config/{key}")]
    public IActionResult GetConfig(string key)
    {
        if (key == "all")
        {
            return Ok(_configuration.AsEnumerable());

        }
        return Ok("Config is: " + _configuration.GetValue(key, "defaultValue"));
    }
}