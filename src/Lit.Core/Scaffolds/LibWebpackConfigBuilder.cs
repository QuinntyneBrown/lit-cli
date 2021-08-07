using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class LibWebpackConfigBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(LibWebpackConfigBuilder));
    }
}
