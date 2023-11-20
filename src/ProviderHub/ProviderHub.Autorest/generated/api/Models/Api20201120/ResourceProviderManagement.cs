namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagementInternal
    {

        /// <summary>Backing field for <see cref="IncidentContactEmail" /> property.</summary>
        private string _incidentContactEmail;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string IncidentContactEmail { get => this._incidentContactEmail; set => this._incidentContactEmail = value; }

        /// <summary>Backing field for <see cref="IncidentRoutingService" /> property.</summary>
        private string _incidentRoutingService;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string IncidentRoutingService { get => this._incidentRoutingService; set => this._incidentRoutingService = value; }

        /// <summary>Backing field for <see cref="IncidentRoutingTeam" /> property.</summary>
        private string _incidentRoutingTeam;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string IncidentRoutingTeam { get => this._incidentRoutingTeam; set => this._incidentRoutingTeam = value; }

        /// <summary>Backing field for <see cref="ManifestOwner" /> property.</summary>
        private string[] _manifestOwner;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] ManifestOwner { get => this._manifestOwner; set => this._manifestOwner = value; }

        /// <summary>Backing field for <see cref="ResourceAccessPolicy" /> property.</summary>
        private string _resourceAccessPolicy;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ResourceAccessPolicy { get => this._resourceAccessPolicy; set => this._resourceAccessPolicy = value; }

        /// <summary>Backing field for <see cref="ResourceAccessRole" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] _resourceAccessRole;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ResourceAccessRole { get => this._resourceAccessRole; set => this._resourceAccessRole = value; }

        /// <summary>Backing field for <see cref="SchemaOwner" /> property.</summary>
        private string[] _schemaOwner;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] SchemaOwner { get => this._schemaOwner; set => this._schemaOwner = value; }

        /// <summary>Backing field for <see cref="ServiceTreeInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] _serviceTreeInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get => this._serviceTreeInfo; set => this._serviceTreeInfo = value; }

        /// <summary>Creates an new <see cref="ResourceProviderManagement" /> instance.</summary>
        public ResourceProviderManagement()
        {

        }
    }
    public partial interface IResourceProviderManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentContactEmail",
        PossibleTypes = new [] { typeof(string) })]
        string IncidentContactEmail { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentRoutingService",
        PossibleTypes = new [] { typeof(string) })]
        string IncidentRoutingService { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"incidentRoutingTeam",
        PossibleTypes = new [] { typeof(string) })]
        string IncidentRoutingTeam { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"manifestOwners",
        PossibleTypes = new [] { typeof(string) })]
        string[] ManifestOwner { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceAccessPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceAccessPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceAccessRoles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ResourceAccessRole { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"schemaOwners",
        PossibleTypes = new [] { typeof(string) })]
        string[] SchemaOwner { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"serviceTreeInfos",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get; set; }

    }
    internal partial interface IResourceProviderManagementInternal

    {
        string IncidentContactEmail { get; set; }

        string IncidentRoutingService { get; set; }

        string IncidentRoutingTeam { get; set; }

        string[] ManifestOwner { get; set; }

        string ResourceAccessPolicy { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[] ResourceAccessRole { get; set; }

        string[] SchemaOwner { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[] ServiceTreeInfo { get; set; }

    }
}