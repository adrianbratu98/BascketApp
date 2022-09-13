using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BascketApp.Api.Controllers
{
    /// <summary>
    ///	Base API controller
    /// </summary>
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// Mediator instance to use to emit queries and commands in API controllers
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}

