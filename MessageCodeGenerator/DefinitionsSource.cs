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
            Namespaces = new[]
            {
                new Namespace
                {
                    Name = "Namespace1.Namespace2",
                    Messages = new[]
                    {
                        new Message
                        {
                            Name = "Message1"
                        }
                    }
                }
            }
        };
    }
}