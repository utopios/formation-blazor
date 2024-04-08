using demo_aspnet.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace demo_aspnet.Controllers;


[Route("[controller]")]
public class ApiController : ControllerBase
{
    [HttpGet("[action]")]
    public IActionResult Index()
    {
        return Ok(new {Message = "Result from ou API"});
    }

    [HttpPost("post")]
    public IActionResult Post([FromBody] PersonRecord person)
    {
        return Ok(new { Message = "Repsponse", Data = person });
    }
}

public record PersonRecord(string Firstname, string Lastname);