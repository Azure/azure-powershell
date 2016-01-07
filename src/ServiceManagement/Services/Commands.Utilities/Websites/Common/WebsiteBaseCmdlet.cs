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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Common
{
    public abstract class WebsiteBaseCmdlet : AzureSMCmdlet
    {
        private IWebsitesClient websitesClient;

        public IWebsitesClient WebsitesClient
        {
            get
            {
                if (websitesClient == null)
                {
                    var profile = Profile ?? AzureSMProfileProvider.Instance.Profile;
                    websitesClient = new WebsitesClient(profile, profile.Context.Subscription, WriteDebug);
                }
                return websitesClient;
            }

            set { websitesClient = value; }
        }
    }
}
