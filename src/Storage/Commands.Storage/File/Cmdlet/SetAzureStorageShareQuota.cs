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

using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.File;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet(VerbsCommon.Set, StorageNouns.ShareQuota), OutputType(typeof(FileShareProperties))]
    public class SetAzureStorageShareQuota : AzureStorageFileCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share name",
            ParameterSetName = Constants.ShareNameParameterSetName,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ParameterSetName = Constants.ShareParameterSetName,
        HelpMessage = "CloudFileShare object indicated the share whose quota to set.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Share Quota")]
        [ValidateRange(1, 5120)]
        public int Quota { get; set; }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudFileShare fileShare = null;

            switch (this.ParameterSetName)
            {
                case Constants.ShareNameParameterSetName:
                    fileShare = this.BuildFileShareObjectFromName(this.ShareName);
                    break;

                case Constants.ShareParameterSetName:
                    fileShare = this.Share;
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            this.Channel.FetchShareAttributes(fileShare, null, this.RequestOptions, this.OperationContext);

            if (fileShare.Properties.Quota != this.Quota)
            {
                fileShare.Properties.Quota = this.Quota;
                this.Channel.SetShareProperties(fileShare, null, this.RequestOptions, this.OperationContext);
            }

            WriteObject(fileShare.Properties);
        }
    }
}

