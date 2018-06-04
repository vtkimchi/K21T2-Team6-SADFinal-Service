using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace HR.Security
{
    public class EncryptMd5
    {
        //public string Encrypt(string encrypt)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = Encoding.UTF8.GetBytes(encrypt);

        //    var hashmd5 = new MD5CryptoServiceProvider();
        //    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("hoidapit.com.vn"));

        //    var tdes = new TripleDESCryptoServiceProvider
        //    {
        //        Key = keyArray,
        //        Mode = CipherMode.ECB,
        //        Padding = PaddingMode.PKCS7
        //    };
        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}

        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //
        public const string passPhrase = "p@SSword";
        //Encrypt
        public string Encrypt(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
    }
}