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
    using Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare", DefaultParameterSetName = Constants.MatchingPrefixParameterSetName)]
    [OutputType(typeof(CloudFileShare))]
    public class GetAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.SpecificParameterSetName,
            HelpMessage = "Name of the file share to be received.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            ParameterSetName = Constants.MatchingPrefixParameterSetName,
            HelpMessage = "A prefix of the file shares to be listed.")]
        public string Prefix { get; set; }

        [Parameter(
        Position = 1,
        Mandatory = false,
        ParameterSetName = Constants.SpecificParameterSetName,
        HelpMessage = "SnapshotTime of the file share snapshot to be received.")]
                [ValidateNotNullOrEmpty]
                public DateTimeOffset? SnapshotTime { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.MatchingPrefixParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.SpecificParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        public override IStorageContext Context { get; set; }

        public override void ExecuteCmdlet()
        {
            this.RunTask(async taskId =>
            {
                switch (this.ParameterSetName)
                {
                    case Constants.SpecificParameterSetName:
                        NamingUtil.ValidateShareName(this.Name, false);
                        var share = this.Channel.GetShareReference(this.Name, this.SnapshotTime);
                        await this.Channel.FetchShareAttributesAsync(share, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                        this.OutputStream.WriteObject(taskId, share);

                        break;

                    case Constants.MatchingPrefixParameterSetName:
                        NamingUtil.ValidateShareName(this.Prefix, true);
                        await this.Channel.EnumerateSharesAsync(
                            this.Prefix,
                            ShareListingDetails.All,
                            item => this.OutputStream.WriteObject(taskId, item),
                            this.RequestOptions,
                            this.OperationContext,
                            this.CmdletCancellationToken).ConfigureAwait(false);

                        break;

                    default:
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
                }
            });
        }
    }
}
