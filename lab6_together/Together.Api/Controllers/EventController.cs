using Microsoft.AspNetCore.Mvc;
using Together.Application.Services;
using Together.Contract.Controller;

namespace Together.Api.Controllers;

[ApiController]
[Route("api")]
public class EventController : ControllerBase
{
  private readonly IEventService eventService;

    public EventController(IEventService eventService)
    {
        this.eventService = eventService;
    }


    [HttpPost("add-event")]
    public IActionResult AddEvent(AddEventRequest request)
    {
        //return Ok(request);

        // AddEventResponse response = new AddEventResponse(
        //     Guid.NewGuid(), request.name, request.coordinator,
        //     request.place, request.lat, request.lng, request.fee
        // );

          AddEventResponse response = new AddEventResponse(
            Guid.NewGuid(), request.name, request.coordinator,
            request.place, request.lat, request.lng, request.fee
        );
     
        return Ok(response);

    }
    [HttpPost("query-event")]
    public IActionResult QueryEvent(QueryEventRequest request)
    {
        //return Ok(request);
       // QueryEventResponse res = new QueryEventResponse("nane", "mark", "tpe", 20.4f, 121.3f, 1000);
       // QueryEventResponse[] events = new QueryEventResponse[] { res, res, res, res };
       // return Ok(events);

        var result = eventService.query(request.lat, request.lng, request.length);
        List<QueryEventResponse> events = new();
        foreach (var r in result)
        {
            QueryEventResponse response = new QueryEventResponse(r.name, r.coordinator, r.place,
            r.lat, r.lng, r.fee);
            events.Add(response);
        }
        return Ok(events);


    }

}