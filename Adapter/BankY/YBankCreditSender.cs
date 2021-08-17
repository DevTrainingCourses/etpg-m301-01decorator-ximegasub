namespace SoftDesign.Patterns.Structural.Adapter.BankY
{
    using System;
    using System.Threading;
    
    public class YBankCreditSender
    {
        YBankCreditApprove request;
        YBankCreditSenderListener listener;

        public void StartThread()
        {
            Console.WriteLine("yBank received your request in a moment you will have the answer, be patient please");
            YBankCreditApproveResult response = new YBankCreditApproveResult();
            if (request.Credit <= 1500)
            {
                response.Approved = "Y";
            }
            else
            {
                response.Approved = "N";
            }
            try
            {
                Thread.Sleep(1000 * 30);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            listener.NotifyCreditResult(response);
        }

        public void SendCreditForValidate(YBankCreditApprove request, YBankCreditSenderListener listener)
        {
            this.request = request;
            this.listener = listener;

            Thread thread = new Thread(StartThread);
            thread.Start();
        }
    }
}
