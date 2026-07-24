// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>NodePool properties</summary>
    public partial class NodePoolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ImageCacheLowerThreshold" /> property.</summary>
        private int? _imageCacheLowerThreshold;

        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int? ImageCacheLowerThreshold { get => this._imageCacheLowerThreshold; set => this._imageCacheLowerThreshold = value; }

        /// <summary>Backing field for <see cref="ImageCacheUpperThreshold" /> property.</summary>
        private int? _imageCacheUpperThreshold;

        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int? ImageCacheUpperThreshold { get => this._imageCacheUpperThreshold; set => this._imageCacheUpperThreshold = value; }

        /// <summary>Backing field for <see cref="MaxNodeCount" /> property.</summary>
        private int _maxNodeCount;

        /// <summary>The maximum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int MaxNodeCount { get => this._maxNodeCount; set => this._maxNodeCount = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="MinNodeCount" /> property.</summary>
        private int? _minNodeCount;

        /// <summary>The minimum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int? MinNodeCount { get => this._minNodeCount; set => this._minNodeCount = value; }

        /// <summary>Backing field for <see cref="OSDiskSizeGb" /> property.</summary>
        private int? _oSDiskSizeGb;

        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int? OSDiskSizeGb { get => this._oSDiskSizeGb; set => this._oSDiskSizeGb = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ScaleSetPriority" /> property.</summary>
        private string _scaleSetPriority;

        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ScaleSetPriority { get => this._scaleSetPriority; set => this._scaleSetPriority = value; }

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>The node pool subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private string _vMSize;

        /// <summary>The size of the underlying Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Creates an new <see cref="NodePoolProperties" /> instance.</summary>
        public NodePoolProperties()
        {

        }
    }
    /// NodePool properties
    public partial interface INodePoolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold. The default is 40%",
        SerializedName = @"imageCacheLowerThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ImageCacheLowerThreshold { get; set; }
        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%",
        SerializedName = @"imageCacheUpperThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ImageCacheUpperThreshold { get; set; }
        /// <summary>The maximum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of nodes.",
        SerializedName = @"maxNodeCount",
        PossibleTypes = new [] { typeof(int) })]
        int MaxNodeCount { get; set; }
        /// <summary>The minimum number of nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The minimum number of nodes.",
        SerializedName = @"minNodeCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MinNodeCount { get; set; }
        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The size of the OS disk in GB. If not specified, the default is 120 GB.",
        SerializedName = @"osDiskSizeGb",
        PossibleTypes = new [] { typeof(int) })]
        int? OSDiskSizeGb { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.",
        SerializedName = @"scaleSetPriority",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Regular", "Spot")]
        string ScaleSetPriority { get; set; }
        /// <summary>The node pool subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The node pool subnet.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>The size of the underlying Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The size of the underlying Azure VM.",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_NC24ads_A100_v4", "Standard_NC48ads_A100_v4", "Standard_NC96ads_A100_v4", "Standard_NC4as_T4_v3", "Standard_NC8as_T4_v3", "Standard_NC16as_T4_v3", "Standard_NC64as_T4_v3", "Standard_NV6ads_A10_v5", "Standard_NV12ads_A10_v5", "Standard_NV24ads_A10_v5", "Standard_NV36ads_A10_v5", "Standard_NV36adms_A10_v5", "Standard_NV72ads_A10_v5", "Standard_ND40rs_v2")]
        string VMSize { get; set; }

    }
    /// NodePool properties
    internal partial interface INodePoolPropertiesInternal

    {
        /// <summary>
        /// The percent of disk usage before which image garbage collection is never run. This cannot be set higher than imageCacheUpperThreshold.
        /// The default is 40%
        /// </summary>
        int? ImageCacheLowerThreshold { get; set; }
        /// <summary>
        /// The percent of disk usage after which image garbage collection is guaranteed to run. The default is 60%
        /// </summary>
        int? ImageCacheUpperThreshold { get; set; }
        /// <summary>The maximum number of nodes.</summary>
        int MaxNodeCount { get; set; }
        /// <summary>The minimum number of nodes.</summary>
        int? MinNodeCount { get; set; }
        /// <summary>The size of the OS disk in GB. If not specified, the default is 120 GB.</summary>
        int? OSDiskSizeGb { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Regular", "Spot")]
        string ScaleSetPriority { get; set; }
        /// <summary>The node pool subnet.</summary>
        string SubnetId { get; set; }
        /// <summary>The size of the underlying Azure VM.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_NC24ads_A100_v4", "Standard_NC48ads_A100_v4", "Standard_NC96ads_A100_v4", "Standard_NC4as_T4_v3", "Standard_NC8as_T4_v3", "Standard_NC16as_T4_v3", "Standard_NC64as_T4_v3", "Standard_NV6ads_A10_v5", "Standard_NV12ads_A10_v5", "Standard_NV24ads_A10_v5", "Standard_NV36ads_A10_v5", "Standard_NV36adms_A10_v5", "Standard_NV72ads_A10_v5", "Standard_ND40rs_v2")]
        string VMSize { get; set; }

    }
}