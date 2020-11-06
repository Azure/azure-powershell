using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public enum JwkKeyType
    {
        RSA // only type supported now
    }
    public enum JwkUse
    {
        enc,
        sig
    }

    /*
     (Note that the "key_ops" values intentionally match the "KeyUsage"
     values defined in the Web Cryptography API
     [W3C.CR-WebCryptoAPI-20141211] specification.)
   */
    public enum JwkKeyOps
    {
        sign,
        verify,
        encrypt,
        decrypt,
        wrapKey,
        unwrapKey,
        deriveKey,
        deriveBits
    }

    public enum JwkAlg
    {
        RSA_OAEP,
        RSA_OAEP_256
    }

    public class JWK
    {
        public JWK()
        {
            key_ops = new List<string>();
            x5c = new List<string>();
        }

        public JWK(X509Certificate2 cert)
        {
            key_ops = new List<string>();
            x5c = new List<string>();

            PublicKey publicKey = cert.PublicKey;
            // Originally "RSA" is the only supported alg
            // However on Windows PowerShell this is what you get from a certificate
            // And I have verified this could work
            if (
                (publicKey.Key.KeyExchangeAlgorithm != "RSA-PKCS1-KeyEx") &&
                (publicKey.Key.KeyExchangeAlgorithm != "RSA") || publicKey.Key.KeySize < 2048)
                throw new Exception("Incorrect certificate format.");

            RSAParameters rsaParameters = cert.GetRSAPublicKey().ExportParameters(false);
            SetExponent(rsaParameters.Exponent);
            SetModulus(rsaParameters.Modulus);

            SetKeyType(JwkKeyType.RSA);

            // Figure out the key_ops
            // Unsure what deriveKey, deriveBits requires, omit for now
            if (cert.PrivateKey != null)
            {
                AddKeyOp(JwkKeyOps.sign);
                AddKeyOp(JwkKeyOps.decrypt);
                AddKeyOp(JwkKeyOps.unwrapKey);
            }

            AddKeyOp(JwkKeyOps.verify);
            AddKeyOp(JwkKeyOps.encrypt);
            AddKeyOp(JwkKeyOps.wrapKey);

            SetAlg(JwkAlg.RSA_OAEP_256);
            SetX5c(cert);
            SetX5t(cert);
            SetX5t256(cert);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(
                this,
                Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        void SetExponent(byte[] exp)
        {
            e = Base64UrlEncoder.Encode(exp);
        }

        void SetModulus(byte[] modulus)
        {
            n = Base64UrlEncoder.Encode(modulus);
        }

        void SetKeyType(JwkKeyType keyType)
        {
            // This is all we support right now
            if (keyType == JwkKeyType.RSA)
                kty = "RSA";
            else
                throw new Exception("Invalid argument");
        }

        void SetUse(JwkUse _use)
        {
            if (_use == JwkUse.enc)
                use = "enc";
            else if (_use == JwkUse.sig)
                use = "sig";
            else
                throw new Exception("Invalid argument");
        }

        void AddKeyOp(JwkKeyOps keyOp)
        {
            switch (keyOp)
            {
                case JwkKeyOps.sign:
                    key_ops.Add("sign");
                    break;
                case JwkKeyOps.verify:
                    key_ops.Add("verify");
                    break;
                case JwkKeyOps.encrypt:
                    key_ops.Add("encrypt");
                    break;
                case JwkKeyOps.decrypt:
                    key_ops.Add("decrypt");
                    break;
                case JwkKeyOps.wrapKey:
                    key_ops.Add("wrapKey");
                    break;
                case JwkKeyOps.unwrapKey:
                    key_ops.Add("unwrapKey");
                    break;
                case JwkKeyOps.deriveKey:
                    key_ops.Add("deriveKey");
                    break;
                case JwkKeyOps.deriveBits:
                    key_ops.Add("deriveBits");
                    break;
            }
        }

        void SetKeyOps(JwkKeyOps[] keyOps)
        {
            foreach (JwkKeyOps op in keyOps)
            {
                AddKeyOp(op);
            }
        }

        public void SetAlg(JwkAlg _alg)
        {
            if (_alg == JwkAlg.RSA_OAEP)
                alg = "RSA-OAEP";
            else
            if (_alg == JwkAlg.RSA_OAEP_256)
                alg = "RSA-OAEP-256";
            else
                throw new Exception("Invalid argument");
        }

        public void SetKid(string _kid)
        {
            kid = _kid;
        }

        void SetX5u()
        {
            // Just to document that this is not to be used
            throw new Exception("Not supported");
        }

        void SetX5c(X509Certificate2 cert)
        {
            // TODO, note: does not support chain, just one cert
            string base64cert = Convert.ToBase64String(cert.RawData);
            x5c.Add(base64cert);
        }

        public X509Certificate2 GetX5c()
        {
            if (x5c.Count < 1)
                return null;

            string base64cert = x5c[0];
            byte[] rawCert = Convert.FromBase64String(base64cert);
            X509Certificate2 cert = new X509Certificate2(rawCert);
            return cert;
        }

        public string GetX5cAsPem()
        {
            string base64cert = x5c[0];
            // Convert to PEM
            string header = "-----BEGIN CERTIFICATE-----\n";
            string footer = "-----END CERTIFICATE-----";
            string pem = header;

            // Now grab 65-character pieces of the base64-encoded cert
            for (Int32 i = 0; i < base64cert.Length; i += 65)
            {
                Int32 remaining = base64cert.Length - i;
                string line = base64cert.Substring(i, remaining > 65 ? 65 : remaining);
                pem += line + "\n";
            }

            pem += footer;
            return pem;
        }

        // TODO - move to utils
        public static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        void SetX5t(X509Certificate2 cert)
        {
            x5t = Base64UrlEncoder.Encode(ToByteArray(cert.Thumbprint));
        }

        void SetX5t256(X509Certificate2 cert)
        {
            x5t_S256 = Base64UrlEncoder.Encode(Utils.Sha256Thumbprint(cert));
        }

        public string kty { get; set; }
        public string use { get; set; }
        public IList<string> key_ops { get; set; }

        public string alg { get; set; }
        public string kid { get; set; }
        public string x5u { get; set; }
        public IList<string> x5c { get; set; }
        public string x5t { get; set; } // X.509 Certificate SHA-1 Thumbprint

        [JsonProperty("x5t#S256")]
        public string x5t_S256 { get; set; } // X.509 Certificate SHA-256 Thumbprint
        public string n { get; set; }
        public string e { get; set; }
    }
}
