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
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Create a storage config for creating a media service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, MediaServiceStorageConfigStr, SupportsShouldProcess = true), OutputType(typeof(PSStorageAccount))]
    public class NewAzureRmMediaServiceStorageConfig : AzureRMCmdlet
    {
        private const string MediaServiceStorageConfigStr = "AzureRmMediaServiceStorageConfig";
        private const string NewMediaServiceStorageConfigWhatIfMessage = "New media service storage config ";
        private const string StorageAccountIdPattern = @"^/subscriptions/[^/]+/resourcegroups/[^/]+/providers/Microsoft.(ClassicStorage|Storage)/storageAccounts/.+$";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id for the existed storage account.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(StorageAccountIdPattern)]
        public string StorageAccountId;

        [Parameter(
            Position = 1,
            Mandatory = false,
            HelpMessage = "Specifies as the primary storage account for the media service.")]
        public SwitchParameter IsPrimary;

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(StorageAccountId, NewMediaServiceStorageConfigWhatIfMessage))
            {
                var config = new PSStorageAccount
                {
                    Id = StorageAccountId,
                    IsPrimary = IsPrimary
                };

                WriteObject(config);
            }
        }
    }
}
