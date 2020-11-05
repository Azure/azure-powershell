using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class Datum
    {
        public string compact_jwe { get; set; }
        public string tag { get; set; }
    }

    public class EncData
    {
        public EncData()
        {
            data = new List<Datum>();
        }

        public IList<Datum> data { get; set; }
        public string kdf { get; set; }
    }

    public class Plaintext
    {
        public byte[] plaintext;
        public string tag;
    }

    public class PlaintextList
    {
        public PlaintextList()
        {
            list = new List<Plaintext>();
        }

        public void Add(Plaintext p)
        {
            list.Add(p);
        }

        public List<Plaintext> list;
    }

    public class Key
    {
        public string enc_key { get; set; }
        public string x5t_256 { get; set; }
    }

    public class KeyPair
    {
        public Key key1 { get; set; }
        public Key key2 { get; set; }
    }

    public class SplitKeys
    {
        public string key_algorithm { get; set; }
        public IList<KeyPair> keys { get; set; }
    }

    public class SharedKeys
    {
        public string key_algorithm { get; set; }
        public UInt32 required { get; set; }
        public IList<Key> enc_shares { get; set; }
    }

    public class SecurityDomainData
    {
        public EncData EncData { get; set; }

        // Because the deserializer isn't very picky, the struct 
        // can contain both the new and the old members, and we can just use the one we need
        public SplitKeys SplitKeys { get; set; }
        public SharedKeys SharedKeys { get; set; }
        public int version { get; set; }
    }

    public class SecurityDomainWrapper
    {
        public string value { get; set; }
    }
}
