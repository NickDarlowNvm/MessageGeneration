using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface IDefinitions
    {
        List<INamespace> Namespaces { get; }
    }

    public class Definitions : IDefinitions
    {
        public List<INamespace> Namespaces { get; }
    }
}