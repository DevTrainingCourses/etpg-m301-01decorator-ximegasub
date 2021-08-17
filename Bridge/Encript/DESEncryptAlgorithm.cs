namespace Bridge.Encript
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class DESEncryptAlgorithm
    {
        public string Encrypt(string message, string password)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(message);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(password);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
