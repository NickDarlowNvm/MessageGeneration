using MessageCodeGenerator.Model;

namespace MessageCodeGenerator
{
    public interface IDefinitionsSource
    {
        Definitions Definitions { get; }
    }

    public class TestDefinitionsSource : IDefinitionsSource
    {
        public Definitions Definitions
        {
            get
            {
                var messageWithBasicProperties = new Message
                {
                    Name = "MessageWithBasicProperties",
                    Properties = new[]
                    {
                        new Property
                        {
                            Name = "IntProperty",
                            Type = new PropertyType {Type = PropertyTypeEnum.Integer}
                        },
                        new Property
                        {
                            Name = "StringProperty",
                            Type = new PropertyType {Type = PropertyTypeEnum.String}
                        }
                    }
                };

                return new Definitions
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
                                    Name = "MessageWithNoProperties"
                                },
                                messageWithBasicProperties,
                                new Message
                                {
                                    Name = "MessageWithMessageProperty",
                                    Properties = new[]
                                    {
                                        new Property
                                        {
                                            Name = "MessageProperty",
                                            Type = new PropertyType {Message = messageWithBasicProperties}
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    }
}