namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input required to add vCenter.</summary>
    public partial class AddVCenterRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestInternal
    {

        /// <summary>The friendly name of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>The IP address of the vCenter to be discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).IPAddress = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddVCenterRequestProperties()); set { {_property = value;} } }

        /// <summary>The port number for discovery.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Port { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).Port = value ?? null; }

        /// <summary>The process server Id from where the discovery is orchestrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProcessServerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).ProcessServerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).ProcessServerId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestProperties _property;

        /// <summary>The properties of an add vCenter request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddVCenterRequestProperties()); set => this._property = value; }

        /// <summary>The account Id which has privileges to discover the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RunAsAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).RunAsAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestPropertiesInternal)Property).RunAsAccountId = value ?? null; }

        /// <summary>Creates an new <see cref="AddVCenterRequest" /> instance.</summary>
        public AddVCenterRequest()
        {

        }
    }
    /// Input required to add vCenter.
    public partial interface IAddVCenterRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The friendly name of the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of the vCenter.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The IP address of the vCenter to be discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address of the vCenter to be discovered.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The port number for discovery.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port number for discovery.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(string) })]
        string Port { get; set; }
        /// <summary>The process server Id from where the discovery is orchestrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The process server Id from where the discovery is orchestrated.",
        SerializedName = @"processServerId",
        PossibleTypes = new [] { typeof(string) })]
        string ProcessServerId { get; set; }
        /// <summary>The account Id which has privileges to discover the vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account Id which has privileges to discover the vCenter.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }

    }
    /// Input required to add vCenter.
    internal partial interface IAddVCenterRequestInternal

    {
        /// <summary>The friendly name of the vCenter.</summary>
        string FriendlyName { get; set; }
        /// <summary>The IP address of the vCenter to be discovered.</summary>
        string IPAddress { get; set; }
        /// <summary>The port number for discovery.</summary>
        string Port { get; set; }
        /// <summary>The process server Id from where the discovery is orchestrated.</summary>
        string ProcessServerId { get; set; }
        /// <summary>The properties of an add vCenter request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddVCenterRequestProperties Property { get; set; }
        /// <summary>The account Id which has privileges to discover the vCenter.</summary>
        string RunAsAccountId { get; set; }

    }
}