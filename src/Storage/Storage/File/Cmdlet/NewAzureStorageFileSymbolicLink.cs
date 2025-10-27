using global::Azure.Storage.Files.Shares;
using global::Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileSymbolicLink", DefaultParameterSetName = Constants.ShareNameParameterSetName, SupportsShouldProcess = true), OutputType(typeof(AzureStorageFile))]
    public class NewAzureStorageFileSymbolicLink : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the symbolic link would be created.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the symbolic link would be created.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder where the symbolic link would be created.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path of the symbolic link to be created.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "The absolute or relative path to the file to be linked to.")]
        [ValidateNotNullOrEmpty]
        public string LinkText { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Optional custom metadata to set for the symbolic link.")]
        public Hashtable Metadata { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The creation time of the symbolic link.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? FileCreatedOn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The last write time of the symbolic link.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? FileLastWrittenOn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Optional. The owner user identifier (UID) to be set on the symbolic link. The default value is 0 (root).")]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Optional. The owner group identifier (GID) to be set on the symbolic link. The default value is 0 (root group).")]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Path, "Create File Symbolic Link"))
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
                ShareFileClient sharefile = baseDirClient.GetFileClient(this.Path);
                
                // Convert Hashtable to IDictionary<string, string>
                IDictionary<string, string> metadata = null;
                if (this.Metadata != null)
                {
                    metadata = new Dictionary<string, string>();
                    foreach (DictionaryEntry entry in this.Metadata)
                    {
                        if (entry.Key != null && entry.Value != null)
                        {
                            metadata[entry.Key.ToString()] = entry.Value.ToString();
                        }
                    }
                }
                
                var options = new ShareFileCreateSymbolicLinkOptions
                {
                    Metadata = metadata,
                    FileCreatedOn = this.FileCreatedOn,
                    FileLastWrittenOn = this.FileLastWrittenOn,
                    Owner = this.Owner,
                    Group = this.Group
                };
                ShareFileInfo info = sharefile.CreateSymbolicLink(this.LinkText, options, this.CmdletCancellationToken).Value;
                WriteObject(new AzureStorageFile(sharefile, (AzureStorageContext)this.Context, info, this.ClientOptions));
            }
        }
    }
}