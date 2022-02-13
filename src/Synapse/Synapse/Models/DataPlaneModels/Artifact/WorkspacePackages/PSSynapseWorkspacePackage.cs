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
