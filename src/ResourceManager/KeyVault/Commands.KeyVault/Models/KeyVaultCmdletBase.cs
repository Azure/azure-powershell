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

using Microsoft.Azure.Common.Extensions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Net.Http;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCmdletBase : AzurePSCmdlet
    {        
        public KeyVaultCmdletBase()
        {        
        }

        internal IKeyVaultDataServiceClient DataServiceClient
        {
            get
            {
                if (dataServiceClient == null)
                {
                    this.dataServiceClient = new KeyVaultDataServiceClient(
                        AzureSession.AuthenticationFactory,
                        AzureSession.CurrentContext,
                        new HttpClient());
                }

                return this.dataServiceClient;
            }
            set
            {
                this.dataServiceClient = value;
            }
        }

        internal string ResolvePath(string filePath, string notFoundMessage)
        {
            FileInfo keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(filePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(notFoundMessage, filePath));
            }
            return keyFile.FullName;
        }

        private IKeyVaultDataServiceClient dataServiceClient;
    }
}
