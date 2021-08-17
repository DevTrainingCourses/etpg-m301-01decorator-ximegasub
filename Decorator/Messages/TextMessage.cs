namespace Decorator.Messages
{
    public class TextMessage
    {
        private string Content;

        public TextMessage()
        {
        }

        public TextMessage(string message)
        {
            this.Content = message;
        }

        public string GetMessage()
        {
            return Content;
        }

        public void SetMessage(string message)
        {
            this.Content = message;
        }

        public string GetContent()
        {
            return Content;
        }

        public void SetContent(string content)
        {
            this.Content = content;
        }
    }
}
