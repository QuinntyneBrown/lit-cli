using CommandLine;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Version
    {
        [Verb("version")]
        internal class Request : IRequest<Unit> {

        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Version (TODO)");
                return new();
            }
        }
    }
}
