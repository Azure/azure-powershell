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

    [Cmdlet(VerbsCommon.New, Constants.ShareCmdletName, DefaultParameterSetName = Constants.ShareNameParameterSetName)]
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

        public override void ExecuteCmdlet()
        {
            NamingUtil.ValidateShareName(this.Name, false);

            var share = this.Channel.GetShareReference(this.Name);
            this.RunTask(async taskId =>
            {
                await this.Channel.CreateShareAsync(share, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
                this.OutputStream.WriteObject(taskId, share);
            });
        }
    }
}
