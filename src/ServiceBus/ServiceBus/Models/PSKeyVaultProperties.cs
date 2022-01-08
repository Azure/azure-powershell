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
    public class PSKeyVaultProperties
    {
        public PSKeyVaultProperties()
        {

        }

        public PSKeyVaultProperties(KeyVaultProperties keyVaultProperties)
        {
            if (keyVaultProperties != null)
            {
                if (keyVaultProperties.KeyName != null)
                {
                    KeyName = keyVaultProperties.KeyName;
                }
                if(keyVaultProperties.KeyVaultUri != null)
                {
                    KeyVaultUri = keyVaultProperties.KeyVaultUri;
                }
                if(keyVaultProperties.KeyVersion != null)
                {
                    KeyVersion = keyVaultProperties.KeyVersion;
                }
                if(keyVaultProperties.Identity.UserAssignedIdentity != null)
                {
                    UserAssignedIdentity = keyVaultProperties.Identity.UserAssignedIdentity;
                }
            }
        }

        public string KeyName { get; set; }

        public string KeyVaultUri { get; set; }

        public string KeyVersion { get; set; }

        public string UserAssignedIdentity { get; set; }

    }
}
