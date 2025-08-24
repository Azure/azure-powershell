// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>Request structure for file share provisioning parameters recommendation API.</summary>
    public partial class FileShareProvisioningRecommendationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationRequest,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationRequestInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInput Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningRecommendationInput()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInput _property;

        /// <summary>The properties of the file share provisioning recommendation input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInput Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningRecommendationInput()); set => this._property = value; }

        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning
        /// parameters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int ProvisionedStorageGiB { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInputInternal)Property).ProvisionedStorageGiB; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInputInternal)Property).ProvisionedStorageGiB = value ; }

        /// <summary>
        /// Creates an new <see cref="FileShareProvisioningRecommendationRequest" /> instance.
        /// </summary>
        public FileShareProvisioningRecommendationRequest()
        {

        }
    }
    /// Request structure for file share provisioning parameters recommendation API.
    public partial interface IFileShareProvisioningRecommendationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning
        /// parameters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning parameters.",
        SerializedName = @"provisionedStorageGiB",
        PossibleTypes = new [] { typeof(int) })]
        int ProvisionedStorageGiB { get; set; }

    }
    /// Request structure for file share provisioning parameters recommendation API.
    internal partial interface IFileShareProvisioningRecommendationRequestInternal

    {
        /// <summary>The properties of the file share provisioning recommendation input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInput Property { get; set; }
        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning
        /// parameters.
        /// </summary>
        int ProvisionedStorageGiB { get; set; }

    }
}