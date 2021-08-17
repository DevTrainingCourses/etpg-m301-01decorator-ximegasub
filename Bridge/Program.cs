using Bridge.Encript;
using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            AESEncryptAlgorithm aesImpl = new AESEncryptAlgorithm();
            DESEncryptAlgorithm desImpl = new DESEncryptAlgorithm();
            NoEncryptAlgorithm noImpl = new NoEncryptAlgorithm();

            try
            {
                string message = "<Person><Name>Jose Ecos</Name></Person>";

                string messageAES = aesImpl.Encrypt(message, "HG58YZ3CR9123456");
                Console.WriteLine("messageAES > " + messageAES + "\n");

                string messageDES = desImpl.Encrypt(message, "XMzDdG4D03CKm2Ix");
                Console.WriteLine("messageDES > " + messageDES + "\n");

                string messageNO = noImpl.NoEncrypt(message, null);
                Console.WriteLine("messageNO > " + messageNO + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
