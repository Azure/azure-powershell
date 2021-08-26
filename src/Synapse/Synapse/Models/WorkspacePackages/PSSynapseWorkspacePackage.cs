using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages
{
    public class PSSynapseWorkspacePackage : PSSubResource
    {
        public PSSynapseWorkspacePackage(LibraryResource packageInfo)
         : this(packageInfo, null)
        {
        }

        public PSSynapseWorkspacePackage(LibraryResource packageInfo, string workspaceName)
            : base(packageInfo.Id,
                  packageInfo.Name,
                  packageInfo.Type,
                  packageInfo.Etag)
        {
            this.Path = packageInfo?.Properties?.Path;
            this.ContainerName = packageInfo?.Properties?.ContainerName;
            this.UploadedTimestamp = packageInfo?.Properties?.UploadedTimestamp;
            this.PackageType = packageInfo?.Properties?.Type;
            this.ProvisioningStatus = packageInfo?.Properties?.ProvisioningStatus;
            this.CreatorId = packageInfo?.Properties?.CreatorId;
            this.WorkspaceName = workspaceName;
        }

        public PSSynapseWorkspacePackage(Microsoft.Azure.Management.Synapse.Models.LibraryInfo packageInfo)
            : base(null, packageInfo.Name, null, null)
        {
            this.Path = packageInfo?.Path;
            this.ContainerName = packageInfo?.ContainerName;
            this.UploadedTimestamp = packageInfo?.UploadedTimestamp?.ToUniversalTime().ToString();
            this.PackageType = packageInfo?.Type;
            this.ProvisioningStatus = packageInfo?.ProvisioningStatus;
            this.CreatorId = packageInfo?.CreatorId;
        }

        /// <summary>
        ///  Name of workspace that contains this package.
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary> Location of library/package in storage account. </summary>
        public string Path { get; set; }

        /// <summary> Container name of the library/package. </summary>
        public string ContainerName { get; set; }

        /// <summary> The last update time of the library/package. </summary>
        public string UploadedTimestamp { get; set; }

        /// <summary> Type of the library/package. </summary>
        public string PackageType { get; set; }

        /// <summary> Provisioning status of the library/package. </summary>
        public string ProvisioningStatus { get; set; }

        /// <summary> Creator Id of the library/package. </summary>
        public string CreatorId { get; set; }
    }
}
