using System.Collections.Generic;
using System.Linq;

namespace MessageCodeGenerator
{
    public class CsCodeGenerator : ILanguageCodeGenerator
    {
        public void GenerateCode(IEnumerable<IDefinitions> definitions) => definitions.ToList().ForEach(GenerateDefinitions);

        private void GenerateDefinitions(IDefinitions definitions) => definitions.Namespaces.ForEach(GenerateNamespace);

        private void GenerateNamespace(INamespace nspace)
        {
            nspace.Messages.ForEach(GenerateMessage);
            nspace.Namespaces.ForEach(GenerateNamespace);
        }

        private void GenerateMessage(IMessage message)
        {

        }
    }
}