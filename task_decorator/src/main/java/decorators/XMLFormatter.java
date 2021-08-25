package decorators;

import messages.IMessage;

import javax.xml.namespace.QName;
import java.io.ByteArrayOutputStream;

public class XMLFormatter extends MessageDecorator {

    public XMLFormatter(IMessage message) {
        super(message);
    }

    public IMessage processMessage() {
        message = message.processMessage();
        message = xmlMessage();
        return message;
    }

    private IMessage xmlMessage() {
        try {
            JAXBContext jc = JAXBContext.newInstance(message.getClass());
            JAXBElement<IMessage> je2 = new JAXBElement<IMessage>(new QName(message.getClass().getName()), (Class<IMessage>) message.getClass(), message);
            Marshaller marshaller = jc.createMarshaller();
            marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
            ByteArrayOutputStream output = new ByteArrayOutputStream();
            marshaller.marshal(je2, output);
            return new TextMessage(new String(output.toByteArray()));
        } catch (Exception e) {
            e.printStackTrace();
            throw new RuntimeException("XML error converting");
        }
    }
}
