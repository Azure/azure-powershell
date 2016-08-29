
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


using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.WebApps.Cmdlets.DeploymentSlots
{
    /// <summary>
    /// this commandlet will get the publishing creds of the given Azure Web app slot using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppSlotPublishingProfile")]
    public class GetAzureWebAppSlotPublishingProfileCmdlet : WebAppSlotBaseCmdlet
    {
        private const string DefaultFormat = "WebDeploy";

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The file the publishing profile will we saved as")]
        public string OutputFile { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The format of the profile. Allowed values are [WebDeploy|FileZilla3|Ftp]. Default value is WebDeploy")]
        [ValidateSet("WebDeploy", "FileZilla3", "Ftp", IgnoreCase = true)]
        public string Format { get; set; }

        public GetAzureWebAppSlotPublishingProfileCmdlet()
        {
            Format = Format ?? DefaultFormat;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(WebsitesClient.GetWebAppPublishingProfile(ResourceGroupName, Name, Slot, OutputFile, Format));
        }

    }
}



