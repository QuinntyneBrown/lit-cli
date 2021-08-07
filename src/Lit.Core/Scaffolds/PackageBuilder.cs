using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class PackageBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(PackageBuilder));
    }
}
