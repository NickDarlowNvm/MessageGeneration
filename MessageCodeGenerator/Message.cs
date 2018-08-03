namespace MessageCodeGenerator
{
    public interface IMessage
    {
        string Name { get; set; }
    }

    public class Message : IMessage
    {
        public string Name { get; set; }
    }
}