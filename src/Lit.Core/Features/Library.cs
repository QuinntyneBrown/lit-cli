using CommandLine;
using Lit.Core.Scaffolds;
using Lit.Core.Services;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Library
    {
        [Verb("lib")]
        internal class Request : IRequest<Unit>
        {
            [Value(0)]
            public string Name { get; set; } = "Lib";

            [Option('d', Required = false)]
            public string Directory { get; set; } = System.Environment.CurrentDirectory;
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ICommandService _commandService;
            private readonly IFileSystem _fileSystem;
            private readonly ITemplateLocator _templateLocator;

            public Handler(ICommandService commandService, IFileSystem fileSystem, ITemplateLocator templateLocator)
            {
                _commandService = commandService;
                _fileSystem = fileSystem;
                _templateLocator = templateLocator;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var libDirectory = $"{request.Directory}{Path.DirectorySeparatorChar}{request.Name}";

                _commandService.Start($"mkdir {libDirectory}", request.Directory);

                _commandService.Start($"mkdir src", libDirectory);

                _fileSystem.WriteAllLines($"{libDirectory}{Path.DirectorySeparatorChar}tsconfig.json", new LibTSConfigBuilder().Build(_templateLocator));

                _fileSystem.WriteAllLines($"{libDirectory}{Path.DirectorySeparatorChar}package.json", new PackageBuilder().Build(_templateLocator));

                _fileSystem.WriteAllLines($"{libDirectory}{Path.DirectorySeparatorChar}src{Path.DirectorySeparatorChar}index.ts", Array.Empty<string>());

                _commandService.Start("tsc", libDirectory);

                _commandService.Start("code .", libDirectory);

                return new();
            }
        }
    }
}
