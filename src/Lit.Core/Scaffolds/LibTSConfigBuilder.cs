using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class LibTSConfigBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(LibTSConfigBuilder));
    }
}
