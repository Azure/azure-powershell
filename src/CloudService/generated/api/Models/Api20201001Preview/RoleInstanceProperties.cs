namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class RoleInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal
    {

        /// <summary>Backing field for <see cref="InstanceView" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceView _instanceView;

        /// <summary>The instance view of the role instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceView InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.RoleInstanceView()); set => this._instanceView = value; }

        /// <summary>The Fault Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public int? InstanceViewPlatformFaultDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformFaultDomain; }

        /// <summary>The Update Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public int? InstanceViewPlatformUpdateDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformUpdateDomain; }

        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string InstanceViewPrivateId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PrivateId; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IResourceInstanceViewStatus[] InstanceViewStatuses { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).Statuses; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceView Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.RoleInstanceView()); set { {_instanceView = value;} } }

        /// <summary>Internal Acessors for InstanceViewPlatformFaultDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.InstanceViewPlatformFaultDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformFaultDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformFaultDomain = value; }

        /// <summary>Internal Acessors for InstanceViewPlatformUpdateDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.InstanceViewPlatformUpdateDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformUpdateDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PlatformUpdateDomain = value; }

        /// <summary>Internal Acessors for InstanceViewPrivateId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.InstanceViewPrivateId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PrivateId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).PrivateId = value; }

        /// <summary>Internal Acessors for InstanceViewStatuses</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IResourceInstanceViewStatus[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.InstanceViewStatuses { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).Statuses; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceViewInternal)InstanceView).Statuses = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.RoleInstanceNetworkProfile()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for NetworkProfileNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstancePropertiesInternal.NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfileInternal)NetworkProfile).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfileInternal)NetworkProfile).NetworkInterface = value; }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfile _networkProfile;

        /// <summary>Describes the network profile for the role instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.RoleInstanceNetworkProfile()); set => this._networkProfile = value; }

        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfileInternal)NetworkProfile).NetworkInterface; }

        /// <summary>Creates an new <see cref="RoleInstanceProperties" /> instance.</summary>
        public RoleInstanceProperties()
        {

        }
    }
    public partial interface IRoleInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The Fault Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Fault Domain.",
        SerializedName = @"platformFaultDomain",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewPlatformFaultDomain { get;  }
        /// <summary>The Update Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Update Domain.",
        SerializedName = @"platformUpdateDomain",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewPlatformUpdateDomain { get;  }
        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.",
        SerializedName = @"privateId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceViewPrivateId { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"statuses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IResourceInstanceViewStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IResourceInstanceViewStatus[] InstanceViewStatuses { get;  }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the list of resource Ids for the network interfaces associated with the role instance.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource[] NetworkProfileNetworkInterface { get;  }

    }
    internal partial interface IRoleInstancePropertiesInternal

    {
        /// <summary>The instance view of the role instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceView InstanceView { get; set; }
        /// <summary>The Fault Domain.</summary>
        int? InstanceViewPlatformFaultDomain { get; set; }
        /// <summary>The Update Domain.</summary>
        int? InstanceViewPlatformUpdateDomain { get; set; }
        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        string InstanceViewPrivateId { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IResourceInstanceViewStatus[] InstanceViewStatuses { get; set; }
        /// <summary>Describes the network profile for the role instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstanceNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource[] NetworkProfileNetworkInterface { get; set; }

    }
}