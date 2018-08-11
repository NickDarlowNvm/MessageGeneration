namespace MessageCodeGenerator
{
    public interface IDefinitionsSource
    {
        Definitions Definitions { get; }
    }

    public class TestDefinitionsSource : IDefinitionsSource
    {
        public Definitions Definitions => new Definitions
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