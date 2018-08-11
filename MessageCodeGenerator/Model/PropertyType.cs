namespace MessageCodeGenerator.Model
{
    public enum PropertyTypeEnum
    {
        Message,
        Integer,
        String
    }

    public class PropertyType
    {
        private Message _message;

        public Message Message
        {
            get => _message;
            set
            {
                Type = PropertyTypeEnum.Message;
                _message = value;
            }
        }

        public PropertyTypeEnum Type { get; set; }
    }
}