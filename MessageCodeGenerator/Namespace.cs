using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface INamespace
    {
        string Name { get; set; }
        List<IMessage> Messages { get; set; }
        List<INamespace> Namespaces { get; set; }
    }

    public class Namespace : INamespace
    {
        public string Name { get; set; }
        public List<IMessage> Messages { get; set; }
        public List<INamespace> Namespaces { get; set; }
    }
}