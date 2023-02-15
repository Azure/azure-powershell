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

using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSEncryptionConfigAttributes
    {
        public PSEncryptionConfigAttributes()
        {

        }

        public PSEncryptionConfigAttributes(KeyVaultProperties keyVaultProperties)
        {
            if (keyVaultProperties != null)
            {
                KeyName = keyVaultProperties?.KeyName;
                
                KeyVaultUri = keyVaultProperties?.KeyVaultUri;
                
                KeyVersion = keyVaultProperties?.KeyVersion;

                if(KeyVersion == null)
                {
                    KeyVersion = "";
                }

                if(KeyVaultUri != null)
                {
                    KeyVaultUri = KeyVaultUri.EndsWith("/") ? KeyVaultUri.Substring(0, KeyVaultUri.Length - 1) : KeyVaultUri;
                }

                UserAssignedIdentity = keyVaultProperties?.Identity?.UserAssignedIdentity;
            }
        }

        public string KeyName { get; set; }

        public string KeyVaultUri { get; set; }

        public string KeyVersion { get; set; }

        public string UserAssignedIdentity { get; set; }

    }
}
