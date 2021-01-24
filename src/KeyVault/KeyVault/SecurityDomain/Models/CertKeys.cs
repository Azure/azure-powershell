using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class CertKeys
    {
        public CertKeys()
        {
            _keys = new Dictionary<string, CertKey>();
        }

        public void LoadKeys(KeyPath[] paths)
        {
            foreach (var path in paths)
            {
                try { LoadKey(path); }
                catch (Exception ex)
                {
                    throw new Exception($"Could not load public and private key from {path.PublicKey} and {path.PrivateKey}", ex);
                }
            }
        }

        public void LoadKey(KeyPath path)
        {
            CertKey certKey = new CertKey();
            certKey.Load(path);
            string encodedThumbprint = Base64UrlEncoder.Encode(certKey.GetThumbprint());
            _keys.Add(encodedThumbprint, certKey);
        }

        public CertKey Find(string encoded_thumbprint)
        {
            if (!_keys.TryGetValue(encoded_thumbprint, out CertKey certKey))
                return null;

            return certKey;
        }

        public int Count() { return _keys.Count; }

        private readonly Dictionary<string, CertKey> _keys;
    }
}
