using System.Collections.Generic;

namespace MessageCodeGenerator.Model
{
    public class Message
    {
        public string Name { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}