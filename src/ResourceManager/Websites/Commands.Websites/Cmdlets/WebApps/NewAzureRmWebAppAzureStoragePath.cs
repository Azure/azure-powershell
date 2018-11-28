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

using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAzureStoragePath", SupportsShouldProcess = true), OutputType(typeof(WebAppAzureStoragePath))]
    public class NewAzureRmWebAppAzureStoragePath: WebAppBaseClientCmdLet
    {
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the Azure Storage property. Must be unique within the Web App or Slot")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Type of Azure Storage account. Windows Containers only supports Azure Files")]
        [ValidateNotNullOrEmpty]
        public AzureStorageType Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Storage account name. E.g.: myfilestorageaccount.file.core.windows.net")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the share to mount to the container")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Access key to the Azure Storage account")]
        [ValidateNotNullOrEmpty]
        public string AccessKey { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Path in the container where the share specified by ShareName will be exposed")]
        [ValidateNotNullOrEmpty]
        public string MountPath { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new WebAppAzureStoragePath()
            {
                AccessKey = AccessKey,
                AccountName = AccountName,
                MountPath = MountPath,
                ShareName = ShareName,
                Type = Type,
                Name = Name
            });
        }
    }
}
