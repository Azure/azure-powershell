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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using System.Management.Automation;
    using Azure.Storage.File;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileShare), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.")]
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFileShare))]
    public class NewAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the file share to be created.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        public override void ExecuteCmdlet()
        {
            NamingUtil.ValidateShareName(this.Name, false);

            ShareClient share = Util.GetTrack2ShareReference(this.Name,
                (AzureStorageContext)this.Context,
                null,
                ClientOptions);
            share.Create(cancellationToken: this.CmdletCancellationToken);
            ShareProperties shareProperties = share.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;
            WriteObject(new AzureStorageFileShare(share, (AzureStorageContext)this.Context, shareProperties, ClientOptions));
        }
    }
}
