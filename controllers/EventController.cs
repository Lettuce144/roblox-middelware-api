using CartRideApi;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    // Eughh only roblox only allows bodies with post methods smh
    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] EventRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid data.");
        }
    
        PromptSender sender = new PromptSender();
    
        //$"Event created: {request.Prompt} with ID {request.ServerId}"
        return Ok(await sender.SendPromptAsync(request.Prompt));
    }
}

public class EventRequest
{
    public required string Prompt { get; set; }
    public required int ServerId { get; set; }
}