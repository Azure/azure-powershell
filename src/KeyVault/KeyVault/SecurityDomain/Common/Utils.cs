using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common
{
    class Utils
    {
        static public UInt16[] ConvertToUint16(byte[] b)
        {
            UInt16[] ret = new UInt16[b.Length / 2];

            for (Int32 i = 0; i < b.Length; i += 2)
            {
                byte[] tmp = new byte[2];
                tmp[0] = b[i];
                tmp[1] = b[i + 1];

                // It's already in the same byte order
                // as the system that encrypted it, so don't reverse it
                ret[i / 2] = BitConverter.ToUInt16(tmp, 0);
            }

            return ret;

        }
        static public byte[] Sha256Thumbprint(X509Certificate2 cert)
        {
            SHA256CryptoServiceProvider hash = new SHA256CryptoServiceProvider();
            return hash.ComputeHash(cert.RawData);
        }

        static public string FileToString(string path)
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(path, Encoding.ASCII))
            {
                readContents = streamReader.ReadToEnd();
            }

            return readContents;
        }

        static public void StringToFile(string path, string data)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.ASCII))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
            }
        }

        public static byte[] GetRandom(UInt32 cb)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] random = new byte[cb];
                rng.GetBytes(random);
                return random;
            }
        }

        public static X509Certificate2 CertficateFromPem(string certificatePem)
        {
            // Remove the header
            string base64cert = certificatePem.Replace("-----BEGIN CERTIFICATE-----\n", "");

            // And tidy up any trailing characters
            var footerPosition = base64cert.IndexOf("\n-----END CERTIFICATE");
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(base64cert.Substring(0, footerPosition)));
            return cert;
        }
    }

}
