public class DecoratorMain {

    public static void main(String[] args) {

        CustomerMessage customerMessage = new CustomerMessage(
                "Ximena Subieta", "ximegasub@gmail.com", "5540038");
        System.out.println("Original Message ==> " + customerMessage);

        IMessage message1 = new EncryptMessage("user", "HG58YZ3CR9123456",
                new SOAPEnvelopMessage(
                        new XMLFormatterDecorate(customerMessage))).processMessage();
        System.out.println("message1 =====================================>\n"
                + message1.getContent() + "\n\n");

        IMessage message2 = new SOAPEnvelopMessage(
                new EncryptMessage("user", "HG58YZ3CR9123456",
                        new XMLFormatterDecorate(customerMessage))).processMessage();
        System.out.println("message2 =====================================>\n"
                + message2.getContent());
    }

}
