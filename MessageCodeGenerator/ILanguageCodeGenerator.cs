using System.Collections.Generic;

namespace MessageCodeGenerator
{
    public interface ILanguageCodeGenerator
    {
        void GenerateCode(IEnumerable<IDefinitions> definitions);
    }
}