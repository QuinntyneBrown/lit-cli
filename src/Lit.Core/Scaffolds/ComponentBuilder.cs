
using Lit.Core.Models;
using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class ComponentBuilder
    {
        public string Name { get; private set; }
        public ComponentBuilder(string name)
        {
            Name = name;
        }

        public string[] Build(ITemplateLocator templateLocator, ITemplateProcessor templateProcessor)
        {
            var template = templateLocator.Get(nameof(ComponentBuilder));

            var tokens = new TokensBuilder()
                .With(nameof(Name), (Token)Name)
                .Build();

            return templateProcessor.Process(template, tokens);
        }
    }
}
