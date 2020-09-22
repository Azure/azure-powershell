namespace Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Extensions;

    /// <summary>An update to a private cloud resource</summary>
    public partial class PrivateCloudUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateInternal
    {

        /// <summary>vCenter Single Sign On Identity Sources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IIdentitySource[] IdentitySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).IdentitySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).IdentitySource = value; }

        /// <summary>Connectivity to internet is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.InternetEnum? Internet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).Internet; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).Internet = value; }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string[] ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterHost; }

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public int? ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterId; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public int? ManagementClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterSize = value; }

        /// <summary>Internal Acessors for ManagementCluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateInternal.ManagementCluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementCluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementCluster = value; }

        /// <summary>Internal Acessors for ManagementClusterHost</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateInternal.ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterHost; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterHost = value; }

        /// <summary>Internal Acessors for ManagementClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateInternal.ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)Property).ManagementClusterId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.PrivateCloudUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateProperties _property;

        /// <summary>The updatable properties of a private cloud resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.PrivateCloudUpdateProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.PrivateCloudUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="PrivateCloudUpdate" /> instance.</summary>
        public PrivateCloudUpdate()
        {

        }
    }
    /// An update to a private cloud resource
    public partial interface IPrivateCloudUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IJsonSerializable
    {
        /// <summary>vCenter Single Sign On Identity Sources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"vCenter Single Sign On Identity Sources",
        SerializedName = @"identitySources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IIdentitySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IIdentitySource[] IdentitySource { get; set; }
        /// <summary>Connectivity to internet is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connectivity to internet is enabled or disabled",
        SerializedName = @"internet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.InternetEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.InternetEnum? Internet { get; set; }
        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hosts",
        SerializedName = @"hosts",
        PossibleTypes = new [] { typeof(string) })]
        string[] ManagementClusterHost { get;  }
        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagementClusterId { get;  }
        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster size",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagementClusterSize { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateTags Tag { get; set; }

    }
    /// An update to a private cloud resource
    internal partial interface IPrivateCloudUpdateInternal

    {
        /// <summary>vCenter Single Sign On Identity Sources</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IIdentitySource[] IdentitySource { get; set; }
        /// <summary>Connectivity to internet is enabled or disabled</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.InternetEnum? Internet { get; set; }
        /// <summary>The default cluster used for management</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster ManagementCluster { get; set; }
        /// <summary>The hosts</summary>
        string[] ManagementClusterHost { get; set; }
        /// <summary>The identity</summary>
        int? ManagementClusterId { get; set; }
        /// <summary>The cluster size</summary>
        int? ManagementClusterSize { get; set; }
        /// <summary>The updatable properties of a private cloud resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateProperties Property { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IPrivateCloudUpdateTags Tag { get; set; }

    }
}