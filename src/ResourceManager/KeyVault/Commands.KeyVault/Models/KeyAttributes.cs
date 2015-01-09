// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using Client = Microsoft.Azure.Commands.KeyVault.Client;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyAttributes
    {
        public KeyAttributes()
        { }

        internal KeyAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string keyType, string[] keyOps)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.KeyType = keyType;
            this.KeyOps = keyOps;
        }

        internal KeyAttributes(bool? enabled, int? expires, int? notBefore, string keyType = null, string[] keyOps = null) :
            this(enabled, FromUnixTime(expires), FromUnixTime(notBefore), keyType, keyOps)
        { }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public string KeyType { get; private set; }

        public string[] KeyOps { get; set; }

        public static explicit operator Client.KeyAttributes(KeyAttributes attr)
        {
            return new Client.KeyAttributes()
            {
                Enabled = attr.Enabled,
                NotBefore = attr.NotBeforeUnixTime,
                Expires = attr.ExpiresUnixTime
            };
        }

        internal int? ExpiresUnixTime
        {
            get
            {
                return ToUnixTime(this.Expires);
            }
        }

        internal int? NotBeforeUnixTime
        {
            get
            {
                return ToUnixTime(this.NotBefore);
            }
        }

        private static int? ToUnixTime(DateTime? utcTime)
        {
            if (!utcTime.HasValue)
            {
                return null;
            }
            return Client.UnixEpoch.ToUnixTime(utcTime.Value);
        }

        private static DateTime? FromUnixTime(int? utcTime)
        {
            if (!utcTime.HasValue)
            {
                return null;
            }
            return Client.UnixEpoch.FromUnixTime(utcTime.Value);
        }
    }
}
