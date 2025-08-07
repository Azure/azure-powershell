// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share provisioning parameters recommendation API input structure.</summary>
    public partial class FileShareProvisioningRecommendationInput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInput,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationInputInternal
    {

        /// <summary>Backing field for <see cref="ProvisionedStorageGiB" /> property.</summary>
        private int _provisionedStorageGiB;

        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning
        /// parameters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int ProvisionedStorageGiB { get => this._provisionedStorageGiB; set => this._provisionedStorageGiB = value; }

        /// <summary>
        /// Creates an new <see cref="FileShareProvisioningRecommendationInput" /> instance.
        /// </summary>
        public FileShareProvisioningRecommendationInput()
        {

        }
    }
    /// File share provisioning parameters recommendation API input structure.
    public partial interface IFileShareProvisioningRecommendationInput :
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
    /// File share provisioning parameters recommendation API input structure.
    internal partial interface IFileShareProvisioningRecommendationInputInternal

    {
        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be use to calculate the values of remaining provisioning
        /// parameters.
        /// </summary>
        int ProvisionedStorageGiB { get; set; }

    }
}