using CommandLine;
using Lit.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Serve
    {
        [Verb("serve")]
        internal class Request : IRequest<Unit> {
            [Option('d', Required = false)]
            public string Directory { get; set; } = System.Environment.CurrentDirectory;
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ICommandService _commandService;
            public Handler(ICommandService commandService)
            {
                _commandService = commandService;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _commandService.Start("npm run serve", request.Directory);

                return new();
            }
        }
    }
}
