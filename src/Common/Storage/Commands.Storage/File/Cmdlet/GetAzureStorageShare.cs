﻿// ----------------------------------------------------------------------------------
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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Storage.File;

    [Cmdlet(VerbsCommon.Get, Constants.ShareCmdletName, DefaultParameterSetName = Constants.MatchingPrefixParameterSetName)]
    public class GetAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.SpecificParameterSetName,
            HelpMessage = "Name of the file share to be listed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            ParameterSetName = Constants.MatchingPrefixParameterSetName,
            HelpMessage = "A prefix of the file shares to be listed.")]
        public string Prefix { get; set; }

        public override void ExecuteCmdlet()
        {
            this.RunTask(async taskId =>
            {
                switch (this.ParameterSetName)
                {
                    case Constants.SpecificParameterSetName:
                        NamingUtil.ValidateShareName(this.Name, false);
                        var share = this.Channel.GetShareReference(this.Name);
                        await this.Channel.FetchShareAttributesAsync(share, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
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
                            this.CmdletCancellationToken);

                        break;

                    default:
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
                }
            });
        }
    }
}
