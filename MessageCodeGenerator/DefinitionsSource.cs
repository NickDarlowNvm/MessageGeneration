namespace MessageCodeGenerator
{
    public interface IDefinitionsSource
    {
        Definitions Definitions { get; }
    }

    public class DefinitionsSource : IDefinitionsSource
    {
        public Definitions Definitions { get; }
    }
}