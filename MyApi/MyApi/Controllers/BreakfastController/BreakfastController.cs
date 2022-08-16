using System;
using Microsoft.AspNetCore.Mvc;
using MyApi.Contracts.Breakfast;
using MyApi.Models;

namespace MyApi.Controllers.BreakfastController;

[ApiController]
[Route("api/[controller]")]
public class BreakfastController: ControllerBase
{
    [HttpPost("/create")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){

        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //TODO: Save In The DataBase .
        var response = new BreakfastResponse(
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
            value: response
        );
    }

    [HttpGet("/read/{id:guid}")]
    public IActionResult GetBreakfast(Guid Id) => Ok(Id);

    [HttpPut("/update/{id:guid}")]
    public IActionResult UpsertBreakfast(Guid Id, UpsertBreakfastRequest request) => Ok(request);

    [HttpDelete("/delete/{id:guid}")]
    public IActionResult DeleteBreakfast(Guid Id) => Ok(Id);
}