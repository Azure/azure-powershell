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


using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.WebApps.Utilities;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public abstract class WebAppBaseClientCmdLet : AzureRMCmdlet
    {
        private ResourceClient _resourcesClient;
        public ResourceClient ResourcesClient
        {
            get
            {
                if (_resourcesClient == null)
                {
                    _resourcesClient = new ResourceClient(DefaultProfile.DefaultContext);
                }

                this._resourcesClient.VerboseLogger = WriteVerboseWithTimestamp;
                this._resourcesClient.ErrorLogger = WriteErrorWithTimestamp;
                this._resourcesClient.WarningLogger = WriteWarningWithTimestamp;
                return _resourcesClient;
            }
            set { _resourcesClient = value; }
        }

        private WebsitesClient _websitesClient;
        public WebsitesClient WebsitesClient
        {
            get
            {
                if (_websitesClient == null)
                {
                    _websitesClient = new WebsitesClient(DefaultProfile.DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _websitesClient;
            }
            set { _websitesClient = value; }
        }

        private KeyVaultClient _keyVaultClient { get; set; }
        public KeyVaultClient KeyvaultClient
        {
            get
            {
                if (_keyVaultClient == null)
                {
                    _keyVaultClient = new KeyVaultClient(DefaultProfile.DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _keyVaultClient;
            }
            set { _keyVaultClient = value; }
        }
    }
}
