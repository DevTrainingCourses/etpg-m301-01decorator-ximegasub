namespace SoftDesign.Patterns.Structural
{
    using System;
    using System.Threading;    
    using SoftDesign.Patterns.Structural.Adapter.BankX;
    using SoftDesign.Patterns.Structural.Adapter.BankY;

    class Program
    {
        private static YBankCreditApproveResult yresponse;

        static void Main(string[] args)
        {            
            string customer = "Jose Ecos";
            double amount = 1000;

            XBankCreditRequest xrequest = new XBankCreditRequest();
            xrequest.CustomerNam = customer;
            xrequest.RequestAmount = amount;

            XBankCreditAPI api = new XBankCreditAPI();
            XBankCreditResponse xresponse = api.SendCreditRequest(xrequest);

            Console.WriteLine("xBank approved > " + xresponse.Aproval + "\n");
            
            YBankCreditApprove yrequest = new YBankCreditApprove();
            yrequest.Credit = (float)amount;
            yrequest.Name = customer;

            YBankCreditSender sender = new YBankCreditSender();
            sender.SendCreditForValidate(yrequest, new YBankCreditSenderListenerAux());

            do
            {
                try
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("yBank request on hold....");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            } while (yresponse == null);

            Console.WriteLine("yBank approved > " + yresponse.Approved + "\n");

            if (xresponse.Aproval)
            {
                Console.WriteLine("xBank approved your credit, congratulations!!");
            }
            else if (yresponse.Approved == "Y")
            {
                Console.WriteLine("yBank approved your credit, congratulations!!");
            }
            else
            {
                Console.WriteLine("Sorry your credit has not been approved");
            }
        }

        public class YBankCreditSenderListenerAux : YBankCreditSenderListener
        {
            public void NotifyCreditResult(YBankCreditApproveResult result)
            {
                yresponse = result;                
            }
        }
    }    
}
