namespace Decorator.Decorators
{
    using Decorator.Messages;

    public class SOAPEnvelopMessage
    {
        TextMessage message;
        public SOAPEnvelopMessage(TextMessage message)
        {
            this.message = message;
        }

        public TextMessage EnvelopMessage()
        {
            string soap = "<soapenv:Envelope xmlns:soapenv="
                    + "\n\"http://schemas.xmlsoap.org/soap/envelope/\" "
                    + "\nxmlns:ser=\"http://service.dishweb.cl.com/\">\n"
                    + "   <soapenv:Header/>\n"
                    + "   <soapenv:Body>\n"
                    + message.GetContent()
                    + "\n"
                    + "   </soapenv:Body>\n"
                    + "</soapenv:Envelope>";
            message.SetContent(soap);
            return message;
        }

    }
}
