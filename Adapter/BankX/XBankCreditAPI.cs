namespace SoftDesign.Patterns.Structural.Adapter.BankX
{
    public class XBankCreditAPI
    {
        public XBankCreditResponse SendCreditRequest(XBankCreditRequest request)
        {
            XBankCreditResponse response = new XBankCreditResponse();
            if (request.RequestAmount <= 5000)
            {
                response.Aproval = true;
            }
            else
            {
                response.Aproval = false;
            }
            return response;
        }
    }
}
