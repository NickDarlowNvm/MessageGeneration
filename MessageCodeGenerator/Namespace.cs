using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface INamespace
    {
        string Name { get; set; }
        IEnumerable<IMessage> Messages { get; set; }
        IEnumerable<INamespace> Namespaces { get; set; }
    }

    public class Namespace : INamespace
    {
        public string Name { get; set; }
        public IEnumerable<IMessage> Messages { get; set; }
        public IEnumerable<INamespace> Namespaces { get; set; }
    }
}