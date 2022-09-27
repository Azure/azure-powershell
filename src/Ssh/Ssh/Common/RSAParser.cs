using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Ssh
{
    internal class RSAParser
    {
        public const string KeyType = "RSA";

        private const string KeyTypeKey = "kty";
        private const string ModulusKey = "n";
        private const string ExponentKey = "e";

        private string keyId;

        public string Modulus { get; private set; }
        public string Exponent { get; private set; }

        public string KeyId
        {
            get
            {
                if (string.IsNullOrEmpty(keyId))
                {
                    keyId = GetKeyId(Modulus);
                }

                return keyId;
            }
        }

        public Dictionary<string, string> Jwk
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { KeyTypeKey, KeyType },
                    { ModulusKey, Modulus },
                    { ExponentKey, Exponent }
                };
            }
        }

        public RSAParser(string publicKeyFileContents)
        {
            ParseKey(publicKeyFileContents);
        }

        private void ParseKey(string publicKey)
        {
            string[] keyParts = publicKey.Split(' ');

            if (keyParts.Length != 3)
            {
                throw new ArgumentException();
            }

            Span<byte> keyBytes = Convert.FromBase64String(keyParts[1]);

            int read = 0;
            Span<byte> firstLengthBytes = keyBytes.Slice(read, 4);
            firstLengthBytes.Reverse();
            int length = Convert.ToInt32(BitConverter.ToUInt32(firstLengthBytes.ToArray(), 0));

            read += 4;
            Span<byte> algorithm = keyBytes.Slice(read, Convert.ToInt32(length));

            read += length;
            Span<byte> secondLengthBytes = keyBytes.Slice(read, 4);
            secondLengthBytes.Reverse();
            length = Convert.ToInt32(BitConverter.ToUInt32(secondLengthBytes.ToArray(), 0));

            read += 4;
            Span<byte> exponent = keyBytes.Slice(read, length);

            read += length;
            Span<byte> thirdLengthBytes = keyBytes.Slice(read, 4);
            thirdLengthBytes.Reverse();
            length = Convert.ToInt32(BitConverter.ToUInt32(thirdLengthBytes.ToArray(), 0));

            read += 4;
            Span<byte> modulus = keyBytes.Slice(read, length);

            Exponent = Convert.ToBase64String(exponent.ToArray());
            Modulus = Convert.ToBase64String(modulus.ToArray());
        }

        private string GetKeyId(string modulus)
        {
            return modulus.GetHashCode().ToString();
        }
    }
}