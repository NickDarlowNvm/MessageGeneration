using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface IDefinitions
    {
        IEnumerable<INamespace> Namespaces { get; set; }
    }

    public class Definitions : IDefinitions
    {
        public IEnumerable<INamespace> Namespaces { get; set; }
    }
}