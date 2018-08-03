using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HandlebarsDotNet;

namespace MessageCodeGenerator
{
    public class CsCodeGenerator : ILanguageCodeGenerator
    {
        private Func<object, string> MessageTemplate { get; } = Handlebars.Compile(File.ReadAllText("Templates/Message.template"));

        public void GenerateCode(IEnumerable<IDefinitions> definitions) =>
            definitions?.ToList().ForEach(GenerateDefinitions);

        private void GenerateDefinitions(IDefinitions definitions) =>
            definitions.Namespaces?.ToList().ForEach(GenerateNamespace);

        private void GenerateNamespace(INamespace nspace)
        {
            nspace.Messages?.ToList().ForEach(GenerateMessage);
            nspace.Namespaces?.ToList().ForEach(GenerateNamespace);
        }

        private void GenerateMessage(IMessage message)
        {
            File.WriteAllText($"{message.Name}.cs", MessageTemplate(message));
        }
    }
}