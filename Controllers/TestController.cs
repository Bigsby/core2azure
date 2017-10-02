using Microsoft.AspNetCore.Mvc;

[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Ok("This is an updated controller");

    [HttpGet("{value}")]
    public IActionResult GetValue(string value) => Ok($"You sent {value}");
}