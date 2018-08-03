using System.Collections.Generic;
using System.Linq;

namespace MessageCodeGenerator
{
    public interface ICodeGenerator
    {
        void GenerateCode(IEnumerable<IDefinitionsSource> definitionsSources);
    }

    public class CodeGenerator : ICodeGenerator
    {
        public CodeGenerator(IEnumerable<ILanguageCodeGenerator> languageCodeGenerators)
        {
            LanguageCodeGenerators = languageCodeGenerators;
        }

        private IEnumerable<ILanguageCodeGenerator> LanguageCodeGenerators { get; }

        public void GenerateCode(IEnumerable<IDefinitionsSource> definitionsSources)
        {
            var definitions = definitionsSources.Select(x => x.Definitions);
            LanguageCodeGenerators.ToList().ForEach(x => x.GenerateCode(definitions));
        }
    }
}