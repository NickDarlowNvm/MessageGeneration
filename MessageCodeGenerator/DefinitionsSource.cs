using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface IDefinitionsSource
    {
        IDefinitions Definitions { get; }
    }

    public class TestDefinitionsSource : IDefinitionsSource
    {
        public IDefinitions Definitions => new Definitions
        {
            Namespaces =
            {
                new Namespace
                {
                    Name = "Namespace1.Namespace2",
                    Messages = new List<IMessage>
                    {
                        new Message
                        {
                            Name = "Message1"
                        },
                        new Message
                        {
                            Name = "Message2"
                        }
                    },
                    Namespaces = new List<INamespace>
                    {
                        new Namespace
                        {
                            Name = "Namespace3"
                        }
                    }
                }
            }
        };
    }
}