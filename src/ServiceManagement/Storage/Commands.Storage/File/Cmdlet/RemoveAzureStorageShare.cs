﻿﻿// ----------------------------------------------------------------------------------
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

    [Cmdlet(
        VerbsCommon.Remove,
        Constants.ShareCmdletName,
        DefaultParameterSetName = Constants.ShareNameParameterSetName,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share object to be removed.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the removed file share. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudFileShare share;
            switch (this.ParameterSetName)
            {
                case Constants.ShareParameterSetName:
                    share = this.Share;
                    break;

                case Constants.ShareNameParameterSetName:
                    share = this.BuildFileShareObjectFromName(this.Name);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            this.RunTask(async taskId =>
            {
                if (this.ShouldProcess(share.Name))
                {
                    await this.Channel.DeleteShareAsync(share, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
                }

                if (this.PassThru)
                {
                    this.OutputStream.WriteObject(taskId, share);
                }
            });
        }
    }
}
