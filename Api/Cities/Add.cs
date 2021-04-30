using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nouran.Countries.Add
{
    [ApiController]
    public class Controller : ControllerBase, IContract
    {
        readonly IMediator mediator;
    
        public Controller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(IContract.ROUTE_URL)]
        public async Task Execute(Command command)
        {
            await mediator.Send(new Request(command));
        }
    }
    
    public record Request(Command Command) : IRequest;
    
    public class RequestHandler : IRequestHandler<Request>
    {
        public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}