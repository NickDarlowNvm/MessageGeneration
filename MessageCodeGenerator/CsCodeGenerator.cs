using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HandlebarsDotNet;
using MessageCodeGenerator.Model;

namespace MessageCodeGenerator
{
    public class CsCodeGenerator : ILanguageCodeGenerator
    {
        private Func<object, string> MessageTemplate { get; } =
            Handlebars.Compile(File.ReadAllText("CsTemplates/Message.template"));

        public void GenerateCode(IEnumerable<Definitions> definitions) =>
            definitions?.ToList().ForEach(GenerateDefinitions);

        private void GenerateDefinitions(Definitions definitions) =>
            definitions.Namespaces?.ToList().ForEach(GenerateNamespace);

        private void GenerateNamespace(Namespace nspace)
        {
            nspace.Messages?.ToList().ForEach(GenerateMessage);
            nspace.Namespaces?.ToList().ForEach(GenerateNamespace);
        }

        private void GenerateMessage(Message message)
        {
            File.WriteAllText($"{message.Name}.cs", MessageTemplate(new CsMessage(message)));
        }
    }

    public class CsMessage
    {
        public CsMessage(Message message)
        {
            Name = message.Name;
            Properties = message.Properties?.Select(property => new CsProperty(property));
        }

        public string Name { get; set; }

        public IEnumerable<CsProperty> Properties { get; set; }
    }

    public class CsProperty
    {
        public CsProperty(Property property)
        {
            Name = property.Name;
            Type = PropertyTypeToString(property.Type);
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public static string PropertyTypeToString(PropertyType propertyType)
        {
            switch (propertyType.Type)
            {
                case PropertyTypeEnum.Message:
                    return propertyType.Message.Name;

                case PropertyTypeEnum.Integer:
                    return "int";

                case PropertyTypeEnum.String:
                    return "string";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}