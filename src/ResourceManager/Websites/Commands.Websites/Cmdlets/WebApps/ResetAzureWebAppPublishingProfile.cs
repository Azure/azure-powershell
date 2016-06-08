
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


using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// This commandlet resets the publishing creds of the given Azure Web app
    /// </summary>
    [Cmdlet(VerbsCommon.Reset, "AzureRmWebAppPublishingProfile")]
    public class ResetAzureWebAppPublishingProfileCmdlet : WebAppBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.ResetWebAppPublishingCredentials(ResourceGroupName, Name, null));
        }
    }
}
