using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class CertKey
    {
        public bool Load(KeyPath path)
        {
            try
            {
                cert = new X509Certificate2(path.PublicKey);
                RSAParameters parameters = RsaParamsFromPem(path.PrivateKey, path.Password);
                key = RSA.Create();
                key.ImportParameters(parameters);
                thumbprint = Utils.Sha256Thumbprint(cert);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public byte[] get_thumbprint() { return thumbprint; }
        public RSA get_key() { return key; }
        public X509Certificate2 get_cert() { return cert; }

        static RSAParameters RsaParamsFromPem(string path, string password)
        {
            using (var stream = File.OpenText(path))
            {
                var reader = string.IsNullOrEmpty(password) ? new PemReader(stream) : new PemReader(stream, new PasswordFinder(password));
                var keyParameters = reader.ReadObject() as RsaPrivateCrtKeyParameters;

                return ToRSAParameters(keyParameters);
            }
        }

        static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
        {
            RSAParameters rp = new RSAParameters();
            rp.Modulus = privKey.Modulus.ToByteArrayUnsigned();
            rp.Exponent = privKey.PublicExponent.ToByteArrayUnsigned();
            rp.P = privKey.P.ToByteArrayUnsigned();
            rp.Q = privKey.Q.ToByteArrayUnsigned();
            rp.D = ConvertRSAParametersField(privKey.Exponent, rp.Modulus.Length);
            rp.DP = ConvertRSAParametersField(privKey.DP, rp.P.Length);
            rp.DQ = ConvertRSAParametersField(privKey.DQ, rp.Q.Length);
            rp.InverseQ = ConvertRSAParametersField(privKey.QInv, rp.Q.Length);
            return rp;
        }


        static byte[] ConvertRSAParametersField(Org.BouncyCastle.Math.BigInteger n, int size)
        {
            byte[] bs = n.ToByteArrayUnsigned();
            if (bs.Length == size)
                return bs;
            if (bs.Length > size)
                throw new ArgumentException("Specified size too small", "size");
            byte[] padded = new byte[size];
            Array.Copy(bs, 0, padded, size - bs.Length, bs.Length);
            return padded;
        }

        X509Certificate2 cert;
        RSA key;
        byte[] thumbprint;

        private class PasswordFinder : IPasswordFinder
        {
            private string v;

            public PasswordFinder(string v)
            {
                this.v = v;
            }

            public char[] GetPassword()
            {
                return v.ToCharArray();
            }
        }
    }
}