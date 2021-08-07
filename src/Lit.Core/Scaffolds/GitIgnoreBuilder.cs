using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class GitIgnoreBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(GitIgnoreBuilder));
    }
}
