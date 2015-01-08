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

using System.Runtime.Serialization;
using Microsoft.Azure.Commands.KeyVault.WebKey;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.KeyVault.Client
{
    /// <summary>
    /// A KeyBundle consisting of a WebKey plus its Attributes
    /// </summary>
    [DataContract()]
    public class KeyBundle
    {
        internal const string Property_Key        = "key";
        internal const string Property_Attributes = "attributes";

        /// <summary>
        /// The Json web key 
        /// </summary>
        [DataMember(Name = Property_Key)]
        public JsonWebKey Key { get; set; }

        /// <summary>
        /// The key management attributes
        /// </summary>
        [DataMember(Name = Property_Attributes, IsRequired = false, EmitDefaultValue = false)]
        public KeyAttributes Attributes { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyBundle()
        {
            Key = new JsonWebKey();
            Attributes = new KeyAttributes();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
