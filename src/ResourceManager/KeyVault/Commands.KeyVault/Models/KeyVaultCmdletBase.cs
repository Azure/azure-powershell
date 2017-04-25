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
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCmdletBase : AzureRMCmdlet
    {
        public static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        internal IKeyVaultDataServiceClient DataServiceClient
        {
            get
            {
                if (dataServiceClient == null)
                {
                    this.dataServiceClient = new KeyVaultDataServiceClient(
                        AzureSession.AuthenticationFactory,
                        DefaultContext);
                }

                return this.dataServiceClient;
            }
            set
            {
                this.dataServiceClient = value;
            }
        }

        protected string GetDefaultFileForOperation( string operationName, string vaultName, string entityName )
        {
            // caller is responsible for parameter validation
            var currentPath = CurrentPath();
            var filename = string.Format("{0}\\{1}-{2}-{3}-{4}", currentPath, vaultName, entityName, DateTime.UtcNow.Subtract(EpochDate).TotalSeconds);

            return filename;
        }

        protected string ResolvePathFromFilename( string filePath, bool throwOnPreExisting, string errorMessage )
        {
            FileInfo file = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(filePath));
            if ( file.Exists && throwOnPreExisting )
            {
                throw new IOException( string.Format( errorMessage, filePath ) );
            }

            return file.FullName;
        }

        private IKeyVaultDataServiceClient dataServiceClient;
    }
}
