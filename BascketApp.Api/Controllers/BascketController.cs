using BascketApp.Api.Controllers;
using BascketApp.Application.Commands;
using BascketApp.Application.Models;
using BascketApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BascketApp.Api;

[ApiController]
[Route("api/basckets")]
public class BascketController : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<int>> Add(AddBascketDTO model)
        => Ok(await Mediator.Send(new AddBascketCommand(model)));

    [HttpPut("/{id}/article-line")]
    public async Task<ActionResult<int>> PutArticle(int id, PutBascketArticleDTO model)
        => Ok(await Mediator.Send(new PutBascketArticleCommand(id, model)));

    [HttpGet("/{id}")]
    public async Task<ActionResult<int>> Get(int id)
        => Ok(await Mediator.Send(new GetBascketQuery(id)));

    [HttpPatch("/{id}")]
    public async Task<ActionResult<int>> Update(int id, UpdateBascketDTO model)
        => Ok(await Mediator.Send(new UpdateBascketCommand(id, model)));
}

