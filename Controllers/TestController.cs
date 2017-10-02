using Microsoft.AspNetCore.Mvc;

[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Ok("This is a controller");
}