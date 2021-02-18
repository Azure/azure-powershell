using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    /*
 * In the JWE Compact Serialization, a JWE is represented as the
concatenation:

  BASE64URL(UTF8(JWE Protected Header)) || '.' ||
  BASE64URL(JWE Encrypted Key) || '.' ||
  BASE64URL(JWE Initialization Vector) || '.' ||
  BASE64URL(JWE Ciphertext) || '.' ||
  BASE64URL(JWE Authentication Tag)
  */

    // Sample header = {"alg":"RSA-OAEP-256","enc":"A256CBC-HS512","kid":"not used"}

    public class JWE_header
    {
        public string alg { get; set; } // algorithm
        public string enc { get; set; } // encryption algorithm
        public string zip { get; set; } // compression algorithm
        public string jku { get; set; } // JWK set URL
        public string jwk { get; set; } // JSON Web key
        public string kid { get; set; } // Key ID
        public string x5u { get; set; } // X509 certificate URL
        public string x5c { get; set; } // X509 certificate chain
        public string x5t { get; set; } // X.509 Certificate SHA-1 Thumbprint

        [JsonProperty("x5t#S256")]
        public string x5t_S256 { get; set; } // X.509 Certificate SHA-256 Thumbprint
        public string typ { get; set; } // Type
        public string cty { get; set; } // Content type
        public string crit { get; set; } // Critical
    }

    public class JweDecode
    {
        public JweDecode(string compact_jwe)
        {
            string[] parts = compact_jwe.Split('.');

            if (parts.Length != 5)
            {
                throw new Exception("Malformed input");
            }

            encoded_header = parts[0];
            string header = Base64UrlEncoder.Decode(encoded_header);
            encrypted_key = Base64UrlEncoder.DecodeBytes(parts[1]);
            init_vector = Base64UrlEncoder.DecodeBytes(parts[2]);
            ciphertext = Base64UrlEncoder.DecodeBytes(parts[3]);
            auth_tag = Base64UrlEncoder.DecodeBytes(parts[4]);

            protected_header = JsonConvert.DeserializeObject<JWE_header>(header);
        }

        // For encryption
        public JweDecode()
        {
            encoded_header = "";
            encrypted_key = null;
            init_vector = null;
            ciphertext = null;
            auth_tag = null;
            protected_header = new JWE_header();
        }

        public void EncodeHeader()
        {
            string header_json = JsonConvert.SerializeObject(
                                                protected_header,
                                                Formatting.None,
                                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            encoded_header = Base64UrlEncoder.Encode(header_json);
        }

        public string EncodeCompact()
        {
            string ret = encoded_header + ".";

            if (encrypted_key != null)
            {
                ret += Base64UrlEncoder.Encode(encrypted_key);
            }

            ret += ".";
            if (init_vector != null)
            {
                ret += Base64UrlEncoder.Encode(init_vector);
            }

            ret += ".";
            if (ciphertext != null)
            {
                ret += Base64UrlEncoder.Encode(ciphertext);
            }

            ret += ".";
            if (auth_tag != null)
            {
                ret += Base64UrlEncoder.Encode(auth_tag);
            }

            return ret;
        }

        public JWE_header protected_header;
        public string encoded_header;
        public byte[] encrypted_key;
        public byte[] init_vector;
        public byte[] ciphertext;
        public byte[] auth_tag;
    }

    public class JWE
    {
        public JWE(string compact_jwe)
        {
            jwe_decode = new JweDecode(compact_jwe);
        }

        public JWE()
        {
            jwe_decode = new JweDecode();
        }

        public string EncodeCompact()
        {
            return jwe_decode.EncodeCompact();
        }

        RSAEncryptionPadding GetPaddingMode()
        {
            string alg = jwe_decode.protected_header.alg;
            switch (alg)
            {
                case "RSA-OAEP-256":
                    return RSAEncryptionPadding.OaepSHA256;
                case "RSA-OAEP":
                    return RSAEncryptionPadding.OaepSHA1;
                case "RSA1_5":
                    return RSAEncryptionPadding.Pkcs1;
            }

            return null;
        }

        public byte[] GetCEK(RSA private_key)
        {
            return private_key.Decrypt(jwe_decode.encrypted_key, GetPaddingMode());
        }

        public void SetCEK(X509Certificate2 cert, byte[] cek)
        {
            RSA rsa = cert.GetRSAPublicKey();
            jwe_decode.encrypted_key = rsa.Encrypt(cek, GetPaddingMode());
        }
        byte[] DekFromCek(byte[] cek)
        {
            byte[] dek = new byte[32];
            Array.Copy(cek, 32, dek, 0, 32);
            return dek;
        }

        byte[] HmacKeyFromCek(byte[] cek)
        {
            byte[] hk = new byte[32];
            Array.Copy(cek, 0, hk, 0, 32);
            return hk;
        }

        byte[] GetMac(byte[] hk)
        {
            HMACSHA512 hMAC = new HMACSHA512(hk);
            byte[] header_bytes = Encoding.ASCII.GetBytes(jwe_decode.encoded_header);

            using (MemoryStream stm = new MemoryStream())
            {
                UInt64 auth_bits = (UInt64)header_bytes.Length * 8;
                stm.Write(header_bytes);
                stm.Write(jwe_decode.init_vector);
                stm.Write(jwe_decode.ciphertext);
                // Add the associated_data_length bytes to the hash
                stm.Write(KDF.to_big_endian(auth_bits));
                byte[] hash_data = stm.ToArray();

                return hMAC.ComputeHash(hash_data);
            }
        }

        void Aes256HmacSha512Encrypt(byte[] cek, byte[] plain_text)
        {
            byte[] dek = DekFromCek(cek);
            byte[] hk = HmacKeyFromCek(cek);

            using (Aes alg = Aes.Create())
            {
                alg.Key = dek;
                alg.IV = Utils.GetRandom(16);
                ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key, alg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plain_text);
                        csEncrypt.FlushFinalBlock();
                        csEncrypt.Close();

                        // Have to wait to set hash once header is complete
                        jwe_decode.ciphertext = msEncrypt.ToArray();
                        jwe_decode.init_vector = alg.IV;
                    }
                }
            }
            byte[] mac_value = GetMac(hk);
            jwe_decode.auth_tag = new byte[32];
            Array.Copy(mac_value, jwe_decode.auth_tag, 32);
        }

        byte[] Aes256HmacSha512Decrypt(byte[] cek)
        {
            byte[] dek = DekFromCek(cek);
            byte[] hk = HmacKeyFromCek(cek);

            byte[] mac_value = GetMac(hk);
            // We're then going to truncate the MAC to 32 bytes, as per standard
            int test = 0;
            for (UInt32 i = 0; i < jwe_decode.auth_tag.Length && jwe_decode.auth_tag.Length == 32; ++i)
            {
                test |= (jwe_decode.auth_tag[i] ^ mac_value[i]);
            }

            if (test != 0)
                return null;

            // Nothing has been tampered with, decrypt
            using (Aes alg = Aes.Create())
            {
                alg.Key = dek;
                alg.IV = jwe_decode.init_vector;
                ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key, alg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(jwe_decode.ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (BinaryReader srDecrypt = new BinaryReader(csDecrypt))
                        {
                            return srDecrypt.ReadBytes(jwe_decode.ciphertext.Length);
                        }
                    }
                }
            }
        }

        // Call this with the last parameter non-null to do direct encryption
        public void Encrypt(byte[] cek, byte[] plain_text, string algId, string kid = null)
        {
            if (kid != null)
            {
                jwe_decode.protected_header.alg = "dir";
                jwe_decode.protected_header.kid = kid;
            }

            switch (algId)
            {
                case "A256CBC-HS512":
                    jwe_decode.protected_header.enc = "A256CBC-HS512";
                    jwe_decode.EncodeHeader();
                    Aes256HmacSha512Encrypt(cek, plain_text);
                    return;
            }

        }

        public byte[] Decrypt(byte[] cek)
        {
            switch (jwe_decode.protected_header.enc)
            {
                case "A256CBC-HS512":
                    return Aes256HmacSha512Decrypt(cek);
            }

            return null;
        }

        // Note - we don't have a true key wrap, for now
        // just encrypt keys as if they were data
        public void Encrypt(X509Certificate2 cert, byte[] plaintext)
        {
            // Only allow one encryption method right now
            // and only 256-bit keys
            jwe_decode.protected_header.alg = "RSA-OAEP-256";
            jwe_decode.protected_header.kid = "not used";

            byte[] cek = Utils.GetRandom(64);

            SetCEK(cert, cek);
            Encrypt(cek, plaintext, "A256CBC-HS512");
        }

        public byte[] Decrypt(RSA private_key)
        {
            byte[] cek = GetCEK(private_key);
            return Decrypt(cek);
        }

        JweDecode jwe_decode;
    }

}
