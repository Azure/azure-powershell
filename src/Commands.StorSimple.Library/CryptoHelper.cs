using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library
{
    public class CryptoHelper
    {
        #region public methods
        // Salt for generating encryption keys
        private static byte[] salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
        /// <summary>
        /// this algorithm uses the AES algorithm to decrypt the given cipherText
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="sharedSecret"></param>
        /// <returns></returns>
        public static string DecryptCipherAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            AesManaged aesAlg = null;
            string plaintext = null;
            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, salt);

            // Create the streams used for decryption.
            byte[] bytes = Convert.FromBase64String(cipherText);
            using (MemoryStream memoryDecrypt = new MemoryStream(bytes))
            {
                aesAlg = new AesManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                // Get the initialization vector from the encrypted stream
                aesAlg.IV = ReadByteArray(memoryDecrypt);
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (CryptoStream cryptoDecrypt =
                    new CryptoStream(memoryDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamDecrypt = new StreamReader(cryptoDecrypt))
                    {
                        plaintext = streamDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }


        /// <summary>
        /// This method encrypts a given secret using the public cert
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicCertificate"></param>
        /// <returns></returns>
        public static string EncryptSecretRSAPKCS(string plainText, string publicCertificate)
        {
            string encryptedSecret = null;
            encryptedSecret = EncryptStringRsaPkcs1v15(plainText, publicCertificate);
            return encryptedSecret;
        }
        #endregion public methods

        #region private methods
        private static string EncryptStringRsaPkcs1v15(string plaintext, string encodedCertificate)
        {
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(encodedCertificate));
            if (string.IsNullOrEmpty(plaintext) || cert == null)
            {
                return null;
            }

            byte[] textBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedTextBytes;

            //// Create a new instance of RSACryptoServiceProvider. 
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
            //// Encrypt the passed byte array and specify OAEP padding false to use PKCS#1 V1.5 padding.
            encryptedTextBytes = rsa.Encrypt(textBytes, false);

            return Convert.ToBase64String(encryptedTextBytes);
        }

        /// <summary>
        /// Helper method to read byte array from a stream
        /// </summary>
        /// <param name="s">the stream</param>
        /// <returns>byte array</returns>
        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
        #endregion private methods
    }
}
