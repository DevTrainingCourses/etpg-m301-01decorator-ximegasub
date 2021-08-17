namespace Decorator.Decorators
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Decorator.Messages;

    public class XMLFormatterDecorate
    {
        private CustomerMessage message;
        public XMLFormatterDecorate(CustomerMessage message)
        {
            this.message = message;
        }

        public TextMessage XmlMessage()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(message.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, message);
                    return new TextMessage(textWriter.ToString());
                }

                throw new SystemException();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new SystemException("XML error converting");
            }
        }
    }
}
