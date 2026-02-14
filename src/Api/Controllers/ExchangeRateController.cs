using Application.ExchangeRate.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/exchange-rate")]
public class ExchangeRateController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExchangeRateController(IMediator mediator) => _mediator = mediator;

    [HttpGet("usd-pen")]
    public async Task<IActionResult> GetUsdPen(CancellationToken cancellationToken) =>
        Ok(await _mediator.Send(new GetUsdPenExchangeRateQuery(), cancellationToken));
}
