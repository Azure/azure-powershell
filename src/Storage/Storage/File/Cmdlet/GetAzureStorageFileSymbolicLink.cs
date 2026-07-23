using global::Azure.Storage.Files.Shares;
using global::Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileSymbolicLink", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(ShareFileSymbolicLinkInfo))]
    public class GetAzureStorageFileSymbolicLink : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share containing the symbolic link.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicating the share containing the symbolic link.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicating the base folder containing the symbolic link.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path of the symbolic link file to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

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
            ShareFileClient sharefile = baseDirClient.GetFileClient(this.Path);
            ShareFileSymbolicLinkInfo info = sharefile.GetSymbolicLink(this.CmdletCancellationToken).Value;
            WriteObject(new AzureStorageFile(sharefile, (AzureStorageContext)this.Context, info, this.ClientOptions));
        }
    }
}