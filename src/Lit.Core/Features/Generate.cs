using CommandLine;
using Lit.Core.Models;
using Lit.Core.Scaffolds;
using Lit.Core.Services;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Generate
    {
        [Verb("g")]
        internal class Request : IRequest<Unit> {
            [Value(0)]
            public string scaffold { get; set; }

            [Value(1)]
            public string Name { get; set; }

            [Option('d', Required = false)]
            public string Directory { get; set; } = System.Environment.CurrentDirectory;

            [Option("flat", Required = false)]
            public bool Flat { get; set; }
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IFileSystem _fileSystem;
            private readonly ITemplateLocator _templateLocator;
            private readonly ITemplateProcessor _templateProcessor;
            private readonly ICommandService _commandService;

            public Handler(IFileSystem fileSystem, ITemplateLocator templateLocator, ITemplateProcessor templateProcessor, ICommandService commandService)
            {
                _fileSystem = fileSystem;
                _templateLocator = templateLocator;
                _templateProcessor = templateProcessor;
                _commandService = commandService;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var directory = request.Directory;

                if (request.Flat == false)
                {
                    _commandService.Start($"mkdir {((Token)request.Name).SnakeCase}", directory);

                    directory = $"{directory}{Path.DirectorySeparatorChar}{((Token)request.Name).SnakeCase}";
                }

                _fileSystem.WriteAllLines($"{directory}{Path.DirectorySeparatorChar}{((Token)request.Name).SnakeCase}.component.scss", Array.Empty<string>());

                _fileSystem.WriteAllLines($"{directory}{Path.DirectorySeparatorChar}{((Token)request.Name).SnakeCase}.component.ts", new ComponentBuilder(request.Name).Build(_templateLocator, _templateProcessor));

                _commandService.Start("lit .", directory);

                _commandService.Start("lit .", request.Directory);

                return new();
            }
        }
    }
}
