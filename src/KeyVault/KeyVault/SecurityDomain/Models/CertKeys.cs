using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class CertKeys
    {
        public CertKeys()
        {
            keyValuePairs = new Dictionary<string, CertKey>();
        }

        public void LoadKeys(KeyPath[] paths)
        {
            foreach (var path in paths)
            {
                if (!LoadKey(path))
                    Console.WriteLine("Could not load cert and key from " + path);
            }
        }

        public bool LoadKey(KeyPath path)
        {
            CertKey certKey = new CertKey();

            if (!certKey.Load(path))
                return false;

            string encoded_string = Base64UrlEncoder.Encode(certKey.get_thumbprint());
            keyValuePairs.Add(encoded_string, certKey);
            return true;
        }

        public CertKey Find(string encoded_thumbprint)
        {
            CertKey certKey = null;
            if (!keyValuePairs.TryGetValue(encoded_thumbprint, out certKey))
                return null;

            return certKey;
        }

        public int Count() { return keyValuePairs.Count; }

        Dictionary<string, CertKey> keyValuePairs;
    }
}
