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
    using Microsoft.WindowsAzure.Storage.File;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Remove,
        Constants.FileDirectoryCmdletName,
        SupportsShouldProcess = true,
        DefaultParameterSetName = Constants.ShareNameParameterSetName)]
    public class RemoveAzureStorageDirectory : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the directory would be removed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the directory would be removed.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the directory would be removed.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "Path to the directory to be removed.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Path to the directory to be removed.")]
        [Parameter(
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "Path to the directory to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the removed directory. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string[] path = NamingUtil.ValidatePath(this.Path);
            CloudFileDirectory baseDirectory;
            switch (this.ParameterSetName)
            {
                case Constants.DirectoryParameterSetName:
                    baseDirectory = this.Directory;
                    break;

                case Constants.ShareNameParameterSetName:
                    var share = this.BuildFileShareObjectFromName(this.ShareName);
                    baseDirectory = share.GetRootDirectoryReference();
                    break;

                case Constants.ShareParameterSetName:
                    baseDirectory = this.Share.GetRootDirectoryReference();
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            var directoryToBeRemoved = baseDirectory.GetDirectoryReferenceByPath(path);
            this.RunTask(async taskId =>
            {
                if (this.ShouldProcess(directoryToBeRemoved.GetFullPath(), "Remove directory"))
                {
                    await this.Channel.DeleteDirectoryAsync(directoryToBeRemoved, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
                }

                if (this.PassThru)
                {
                    this.OutputStream.WriteObject(taskId, directoryToBeRemoved);
                }
            });
        }
    }
}
