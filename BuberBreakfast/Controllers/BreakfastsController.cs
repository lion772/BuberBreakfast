using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

namespace BuberBreakfast.Controllers;
[ApiController]
[Route("[controller]")]
public class BreakfastsController: ControllerBase 
{
     private readonly IBreakfastService _breakfastService;

     public BreakfastsController(IBreakfastService breakfastService)
     {
          _breakfastService = breakfastService;
     }
     
     [HttpPost()]
     public IActionResult CreateBreakfast([FromBody] CreateBreakfastRequest request)
     {
               var breakfast = new Breakfast (
                    Guid.NewGuid(),
                    request.Name,
                    request.Description,
                    request.StartDateTime,
                    request.EndDateTime,
                    DateTime.UtcNow,
                    request.Savory,
                    request.Sweet
               ); 
          //TODO: save breakfast to database
          _breakfastService.CreateBreakfast(breakfast);

          var respose = new BreakfastResponse(
               breakfast.Id,
               breakfast.Name,
               breakfast.Description,
               breakfast.StartDateTime,
               breakfast.EndDateTime,
               breakfast.LastModifiedDateTime,
               breakfast.Savory,
               breakfast.Sweet
          );

          return CreatedAtAction(
               actionName: nameof(GetBreakfast),
               routeValues: new { id = breakfast.Id },
               respose);           


     }

     [HttpGet("{id:guid}")]
     public IActionResult GetBreakfast(Guid id)
     {
          _breakfastService.GetBreakfast(id);
          return Ok(id);           
     }
     
     [HttpPut("{id:guid}")]
     public IActionResult UpsertBreakfast(Guid id, [FromBody] UpsertBreakfastRequest request)
     {
          return Ok(request);           
     }

     [HttpDelete("{id:guid}")]
     public IActionResult DeleteBreakfast(Guid id)
     {
          return Ok(id);           
     }
}