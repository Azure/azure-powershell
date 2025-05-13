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
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageDirectory", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFileDirectory))]
    public class NewAzureStorageDirectory : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the directory would be created.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the files/directories would be listed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder where the files/directories would be listed.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path of the directory to be created.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Only applicable to NFS Directory. The mode permissions to be set on the directory. Symbolic (rwxrw-rw-) is supported.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][xsS-]){2}([r-][w-][xtT-])")]
        public string FileMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Only applicable to NFS Directory. The owner user identifier (UID) to be set on the directory. The default value is 0 (root).")]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Only applicable to NFS Directory. The owner group identifier (GID) to be set on the directory. The default value is 0 (root group).")]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

        public override void ExecuteCmdlet()
        {

            ShareDirectoryClient baseDirClient;
            switch (this.ParameterSetName)
            {
                case Constants.DirectoryParameterSetName:
                    CheckContextForObjectInput((AzureStorageContext)this.Context);
                    baseDirClient = this.ShareDirectoryClient;
                    break;

                case Constants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                    baseDirClient = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient();
                    break;

                case Constants.ShareParameterSetName:
                    CheckContextForObjectInput((AzureStorageContext)this.Context);
                    baseDirClient = this.ShareClient.GetRootDirectoryClient();
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            ShareDirectoryClient directoryToBeCreated = baseDirClient.GetSubdirectoryClient(this.Path);

            ShareDirectoryCreateOptions createOptions = new ShareDirectoryCreateOptions();

            // set nfs properties
            if (this.FileMode != null || this.Owner != null || this.Group != null)
            {
                createOptions.PosixProperties = new FilePosixProperties()
                {
                    FileMode = this.FileMode is null ? null : NfsFileMode.ParseSymbolicFileMode(this.FileMode),
                    Group = this.Group,
                    Owner = this.Owner
                };
            }

            directoryToBeCreated.Create(createOptions, cancellationToken: this.CmdletCancellationToken);
            WriteObject(new AzureStorageFileDirectory(directoryToBeCreated, (AzureStorageContext)this.Context, shareDirectoryProperties: null, ClientOptions));
        }
    }
}
