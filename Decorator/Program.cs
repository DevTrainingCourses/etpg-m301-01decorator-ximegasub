namespace Decorator
{
    using System;
    using Decorator.Decorators;
    using Decorator.Messages;

    class Program
    {
        static void Main(string[] args)
        {
            CustomerMessage customerMessage = new CustomerMessage("Jose Ecos", "jose.ecos@gmail.com", "55512345");
            Console.WriteLine("Original Message ==> " + customerMessage);
                        
            TextMessage xmlMessage = new XMLFormatterDecorate(customerMessage).XmlMessage();
            Console.WriteLine("SOAP Encrypt Message ==>\n{0}", xmlMessage.GetContent() + "\n\n");

            TextMessage soapXmlMessage = new SOAPEnvelopMessage(xmlMessage).EnvelopMessage();
            Console.WriteLine("SOAP Encrypt Message ==> " + soapXmlMessage);

            TextMessage encryptsoapXmlMessage = new EncryptMessage("user", "HG58YZ3CR9123456", soapXmlMessage).Encript();
            Console.WriteLine("Encrypt Message ==> " + encryptsoapXmlMessage);
        }
    }
}
