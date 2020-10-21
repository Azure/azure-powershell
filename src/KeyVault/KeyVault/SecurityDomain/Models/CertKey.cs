using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class CertKey
    {
        public void Load(KeyPath path)
        {
            _cert = new X509Certificate2(path.PublicKey);
            RSAParameters parameters = RsaParamsFromPem(path.PrivateKey, path.Password?.ToPlainText());

            // On Windows PowerShell (.net framework), RSA.Create() returns a RSACryptoServiceProvider instance,
            // which does not support decrypting with "OAEP - SHA-2 (SHA256)" padding mode that security domain data is encrypted with.
            // see https://docs.microsoft.com/en-us/dotnet/standard/security/cross-platform-cryptography#rsa

            // solution is to use RSACng instead
            // see https://stackoverflow.com/questions/57815949/override-default-algorithm-in-rsa-object-to-support-oaepsha256-padding

            // RSACng only supports Windows so on Linux we still use RSA.Create(),
            // which should return an algorithm that uses OpenSSL under the hood

            // However RSACng is not in netstandard 2.0, so we introduced dependency to
            // System.Security.Cryptography.Cng library
            // But the netstandard 2.0 version does not support Windows PowerShell (.net framework)
            // (Error: Windows Cryptography Next Generation (CNG) is not supported on this platform.)
            // so we need to preload .net framework version of the assembly

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _key = new RSACng();
            }
            else
            {
                _key = RSA.Create();
            }

            _key.ImportParameters(parameters);
            _thumbprint = Utils.Sha256Thumbprint(_cert);
        }

        public byte[] GetThumbprint() { return _thumbprint; }
        public RSA GetKey() { return _key; }
        public X509Certificate2 GetCert() { return _cert; }

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
            RSAParameters rp = new RSAParameters
            {
                Modulus = privKey.Modulus.ToByteArrayUnsigned(),
                Exponent = privKey.PublicExponent.ToByteArrayUnsigned(),
                P = privKey.P.ToByteArrayUnsigned(),
                Q = privKey.Q.ToByteArrayUnsigned()
            };
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

        X509Certificate2 _cert;
        RSA _key;
        byte[] _thumbprint;

        private class PasswordFinder : IPasswordFinder
        {
            private readonly string _password;

            public PasswordFinder(string password)
            {
                _password = password;
            }

            public char[] GetPassword()
            {
                return _password.ToCharArray();
            }
        }
    }
}