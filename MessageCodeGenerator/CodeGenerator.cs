namespace MessageCodeGenerator
{
    public interface ICodeGenerator
    {
        void GeneratorCode(IDefinitions definitions);
    }

    public class CodeGenerator : ICodeGenerator
    {
        public void GeneratorCode(IDefinitions definitions)
        {
        }
    }
}