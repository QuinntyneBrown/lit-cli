using CommandLine;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Help
    {
        [Verb("help")]
        internal class Request : IRequest<Unit> {

        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Help (TODO)");
                return new();
            }
        }
    }
}
