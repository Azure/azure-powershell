// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Cmdlets;
    using System;

    /// <summary>update a new server.</summary>
    /// <remarks>
    /// [OpenAPI] Get=>GET:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}"
    /// [DETAILS]
    /// verb: Update
    /// subjectPrefix: PostgreSqlFlexible
    /// subject: Server
    /// variant: UpdateExpanded
    /// [OpenAPI] CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}"
    /// [DETAILS]
    /// verb: Update
    /// subjectPrefix: PostgreSqlFlexible
    /// subject: Server
    /// variant: UpdateExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsData.Update, @"AzPostgreSqlFlexibleServer_UpdateExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Description(@"update a new server.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Generated]
    public partial class UpdateAzPostgreSqlFlexibleServer_UpdateExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IContext
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = System.Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private global::System.Management.Automation.InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        /// The <see cref="global::System.Threading.CancellationTokenSource" /> for this operation.
        /// </summary>
        private global::System.Threading.CancellationTokenSource _cancellationTokenSource = new global::System.Threading.CancellationTokenSource();

        /// <summary>A dictionary to carry over additional data for pipeline.</summary>
        private global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object> _extensibleParameters = new System.Collections.Generic.Dictionary<string, object>();

        /// <summary>Properties of a server.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer _parametersBody = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Server();

        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed at any time.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed at any time.",
        SerializedName = @"administratorLoginPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        public System.Security.SecureString AdministratorLoginPassword { get => _parametersBody.AdministratorLoginPassword ?? null; set => _parametersBody.AdministratorLoginPassword = value; }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if the server supports Microsoft Entra authentication.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if the server supports Microsoft Entra authentication.",
        SerializedName = @"activeDirectoryAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string AuthConfigActiveDirectoryAuth { get => _parametersBody.AuthConfigActiveDirectoryAuth ?? null; set => _parametersBody.AuthConfigActiveDirectoryAuth = value; }

        /// <summary>Indicates if the server supports password based authentication.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if the server supports password based authentication.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if the server supports password based authentication.",
        SerializedName = @"passwordAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string AuthConfigPasswordAuth { get => _parametersBody.AuthConfigPasswordAuth ?? null; set => _parametersBody.AuthConfigPasswordAuth = value; }

        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the tenant of the delegated resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the tenant of the delegated resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        public string AuthConfigTenantId { get => _parametersBody.AuthConfigTenantId ?? null; set => _parametersBody.AuthConfigTenantId = value; }

        /// <summary>Backup retention days for the server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Backup retention days for the server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        public int BackupRetentionDay { get => _parametersBody.BackupRetentionDay ?? default(int); set => _parametersBody.BackupRetentionDay = value; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PostgreSqlManagementClient Client => Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.ClientAPI;

        /// <summary>Default database name for the elastic cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Default database name for the elastic cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default database name for the elastic cluster.",
        SerializedName = @"defaultDatabaseName",
        PossibleTypes = new [] { typeof(string) })]
        public string ClusterDefaultDatabaseName { get => _parametersBody.ClusterDefaultDatabaseName ?? null; set => _parametersBody.ClusterDefaultDatabaseName = value; }

        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Number of nodes assigned to the elastic cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of nodes assigned to the elastic cluster.",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        public int ClusterSize { get => _parametersBody.ClusterSize ?? default(int); set => _parametersBody.ClusterSize = value; }

        /// <summary>Creation mode of a new server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Creation mode of a new server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Creation mode of a new server.",
        SerializedName = @"createMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Default", "Create", "Update", "PointInTimeRestore", "GeoRestore", "Replica", "ReviveDropped")]
        public string CreateMode { get => _parametersBody.CreateMode ?? null; set => _parametersBody.CreateMode = value; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        public string DataEncryptionGeoBackupKeyUri { get => _parametersBody.DataEncryptionGeoBackupKeyUri ?? null; set => _parametersBody.DataEncryptionGeoBackupKeyUri = value; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        public string DataEncryptionGeoBackupUserAssignedIdentityId { get => _parametersBody.DataEncryptionGeoBackupUserAssignedIdentityId ?? null; set => _parametersBody.DataEncryptionGeoBackupUserAssignedIdentityId = value; }

        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        public string DataEncryptionPrimaryKeyUri { get => _parametersBody.DataEncryptionPrimaryKeyUri ?? null; set => _parametersBody.DataEncryptionPrimaryKeyUri = value; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the primary storage associated to a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        public string DataEncryptionPrimaryUserAssignedIdentityId { get => _parametersBody.DataEncryptionPrimaryUserAssignedIdentityId ?? null; set => _parametersBody.DataEncryptionPrimaryUserAssignedIdentityId = value; }

        /// <summary>Data encryption type used by a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Data encryption type used by a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data encryption type used by a server.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("SystemManaged", "AzureKeyVault")]
        public string DataEncryptionType { get => _parametersBody.DataEncryptionType ?? null; set => _parametersBody.DataEncryptionType = value; }

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Determines whether to enable a system-assigned identity for the resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Determines whether to enable a system-assigned identity for the resource.")]
        public System.Boolean? EnableSystemAssignedIdentity { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>High availability mode for a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "High availability mode for a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"High availability mode for a server.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Disabled", "ZoneRedundant", "SameZone")]
        public string HighAvailabilityMode { get => _parametersBody.HighAvailabilityMode ?? null; set => _parametersBody.HighAvailabilityMode = value; }

        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.",
        SerializedName = @"standbyAvailabilityZone",
        PossibleTypes = new [] { typeof(string) })]
        public string HighAvailabilityStandbyAvailabilityZone { get => _parametersBody.HighAvailabilityStandbyAvailabilityZone ?? null; set => _parametersBody.HighAvailabilityStandbyAvailabilityZone = value; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the object of the service principal associated to the user assigned managed identity.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the object of the service principal associated to the user assigned managed identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        public string IdentityPrincipalId { get => _parametersBody.IdentityPrincipalId ?? null; set => _parametersBody.IdentityPrincipalId = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates whether custom window is enabled or disabled.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether custom window is enabled or disabled.",
        SerializedName = @"customWindow",
        PossibleTypes = new [] { typeof(string) })]
        public string MaintenanceWindowCustomWindow { get => _parametersBody.MaintenanceWindowCustomWindow ?? null; set => _parametersBody.MaintenanceWindowCustomWindow = value; }

        /// <summary>Day of the week to be used for maintenance window.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Day of the week to be used for maintenance window.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Day of the week to be used for maintenance window.",
        SerializedName = @"dayOfWeek",
        PossibleTypes = new [] { typeof(int) })]
        public int MaintenanceWindowDayOfWeek { get => _parametersBody.MaintenanceWindowDayOfWeek ?? default(int); set => _parametersBody.MaintenanceWindowDayOfWeek = value; }

        /// <summary>Start hour to be used for maintenance window.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Start hour to be used for maintenance window.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start hour to be used for maintenance window.",
        SerializedName = @"startHour",
        PossibleTypes = new [] { typeof(int) })]
        public int MaintenanceWindowStartHour { get => _parametersBody.MaintenanceWindowStartHour ?? default(int); set => _parametersBody.MaintenanceWindowStartHour = value; }

        /// <summary>Start minute to be used for maintenance window.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Start minute to be used for maintenance window.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start minute to be used for maintenance window.",
        SerializedName = @"startMinute",
        PossibleTypes = new [] { typeof(int) })]
        public int MaintenanceWindowStartMinute { get => _parametersBody.MaintenanceWindowStartMinute ?? default(int); set => _parametersBody.MaintenanceWindowStartMinute = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the server.")]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the server.",
        SerializedName = @"serverName",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("ServerName")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Path)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"delegatedSubnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        public string NetworkDelegatedSubnetResourceId { get => _parametersBody.NetworkDelegatedSubnetResourceId ?? null; set => _parametersBody.NetworkDelegatedSubnetResourceId = value; }

        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"privateDnsZoneArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        public string NetworkPrivateDnsZoneArmResourceId { get => _parametersBody.NetworkPrivateDnsZoneArmResourceId ?? null; set => _parametersBody.NetworkPrivateDnsZoneArmResourceId = value; }

        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into a virtual network which is owned and provided by customer when server is deployed.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into a virtual network which is owned and provided by customer when server is deployed.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string NetworkPublicNetworkAccess { get => _parametersBody.NetworkPublicNetworkAccess ?? null; set => _parametersBody.NetworkPublicNetworkAccess = value; }

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover means that the read replica will roles with the primary server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover means that the read replica will roles with the primary server.",
        SerializedName = @"promoteMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Standalone", "Switchover")]
        public string ReplicaPromoteMode { get => _parametersBody.ReplicaPromoteMode ?? null; set => _parametersBody.ReplicaPromoteMode = value; }

        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Data synchronization option to use when processing the operation specified in the promoteMode property. This property is write only.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data synchronization option to use when processing the operation specified in the promoteMode property. This property is write only.",
        SerializedName = @"promoteOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Planned", "Forced")]
        public string ReplicaPromoteOption { get => _parametersBody.ReplicaPromoteOption ?? null; set => _parametersBody.ReplicaPromoteOption = value; }

        /// <summary>Role of the server in a replication set.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Role of the server in a replication set.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Role of the server in a replication set.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        public string ReplicaRole { get => _parametersBody.ReplicaRole ?? null; set => _parametersBody.ReplicaRole = value; }

        /// <summary>Role of the server in a replication set.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Role of the server in a replication set.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Role of the server in a replication set.",
        SerializedName = @"replicationRole",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        public string ReplicationRole { get => _parametersBody.ReplicationRole ?? null; set => _parametersBody.ReplicationRole = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the resource group. The name is case insensitive.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Path)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Name by which is known a given compute size assigned to a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Name by which is known a given compute size assigned to a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name by which is known a given compute size assigned to a server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string SkuName { get => _parametersBody.SkuName ?? null; set => _parametersBody.SkuName = value; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Tier of the compute assigned to a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        public string SkuTier { get => _parametersBody.SkuTier ?? null; set => _parametersBody.SkuTier = value; }

        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions allow for automatically growing storage size.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions allow for automatically growing storage size.",
        SerializedName = @"autoGrow",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string StorageAutoGrow { get => _parametersBody.StorageAutoGrow ?? null; set => _parametersBody.StorageAutoGrow = value; }

        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"iops",
        PossibleTypes = new [] { typeof(int) })]
        public int StorageIop { get => _parametersBody.StorageIop ?? default(int); set => _parametersBody.StorageIop = value; }

        /// <summary>Size of storage assigned to a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Size of storage assigned to a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of storage assigned to a server.",
        SerializedName = @"storageSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        public int StorageSizeGb { get => _parametersBody.StorageSizeGb ?? default(int); set => _parametersBody.StorageSizeGb = value; }

        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"throughput",
        PossibleTypes = new [] { typeof(int) })]
        public int StorageThroughput { get => _parametersBody.StorageThroughput ?? default(int); set => _parametersBody.StorageThroughput = value; }

        /// <summary>Storage tier of a server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Storage tier of a server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Storage tier of a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("P1", "P2", "P3", "P4", "P6", "P10", "P15", "P20", "P30", "P40", "P50", "P60", "P70", "P80")]
        public string StorageTier { get => _parametersBody.StorageTier ?? null; set => _parametersBody.StorageTier = value; }

        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified, it defaults to Premium_LRS.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified, it defaults to Premium_LRS.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Premium_LRS", "PremiumV2_LRS", "UltraSSD_LRS")]
        public string StorageType { get => _parametersBody.StorageType ?? null; set => _parametersBody.StorageType = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The ID of the target subscription. The value must be an UUID.")]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.DefaultInfo(
        Name = @"",
        Description =@"",
        Script = @"(Get-AzContext).Subscription.Id",
        SetCondition = @"")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Path)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Resource tags.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource tags.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags) })]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags Tag { get => _parametersBody.Tag ?? null /* object */; set => _parametersBody.Tag = value; }

        /// <summary>
        /// The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in
        /// the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'")]
        [global::System.Management.Automation.AllowEmptyCollection]
        public string[] UserAssignedIdentity { get; set; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Major version of PostgreSQL database engine.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("18", "17", "16", "15", "14", "13", "12", "11")]
        public string Version { get => _parametersBody.Version ?? null; set => _parametersBody.Version = value; }

        /// <summary>
        /// <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of UpdateAzPostgreSqlFlexibleServer_UpdateExpanded</returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Cmdlets.UpdateAzPostgreSqlFlexibleServer_UpdateExpanded Clone()
        {
            var clone = new UpdateAzPostgreSqlFlexibleServer_UpdateExpanded();
            clone.__correlationId = this.__correlationId;
            clone.__processRecordId = this.__processRecordId;
            clone.DefaultProfile = this.DefaultProfile;
            clone.InvocationInformation = this.InvocationInformation;
            clone.Proxy = this.Proxy;
            clone.Pipeline = this.Pipeline;
            clone.AsJob = this.AsJob;
            clone.Break = this.Break;
            clone.ProxyCredential = this.ProxyCredential;
            clone.ProxyUseDefaultCredentials = this.ProxyUseDefaultCredentials;
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            clone._parametersBody = this._parametersBody;
            clone.SubscriptionId = this.SubscriptionId;
            clone.ResourceGroupName = this.ResourceGroupName;
            clone.Name = this.Name;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
            if (telemetryInfo != null)
            {
                telemetryInfo.TryGetValue("ShowSecretsWarning", out var showSecretsWarning);
                telemetryInfo.TryGetValue("SanitizedProperties", out var sanitizedProperties);
                telemetryInfo.TryGetValue("InvocationName", out var invocationName);
                if (showSecretsWarning == "true")
                {
                    if (string.IsNullOrEmpty(sanitizedProperties))
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing secrets. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                    else
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing the following secrets: {sanitizedProperties}. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                }
            }
        }

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.Progress:
                    {
                        var data = messageData();
                        int progress = (int)data.Value;
                        string activityMessage, statusDescription;
                        global::System.Management.Automation.ProgressRecordType recordType;
                        if (progress < 100)
                        {
                            activityMessage = "In progress";
                            statusDescription = "Checking operation status";
                            recordType = System.Management.Automation.ProgressRecordType.Processing;
                        }
                        else
                        {
                            activityMessage = "Completed";
                            statusDescription = "Completed";
                            recordType = System.Management.Automation.ProgressRecordType.Completed;
                        }
                        WriteProgress(new global::System.Management.Automation.ProgressRecord(1, activityMessage, statusDescription)
                        {
                            PercentComplete = progress,
                        RecordType = recordType
                        });
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.DelayBeforePolling:
                    {
                        var data = messageData();
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }
                        else
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                int delay = (int)(response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 30);
                                WriteDebug($"Delaying {delay} seconds before polling.");
                                for (var now = 0; now < delay; ++now)
                                {
                                    WriteProgress(new global::System.Management.Automation.ProgressRecord(1, "In progress", "Checking operation status")
                                    {
                                        PercentComplete = now * 100 / delay
                                    });
                                    await global::System.Threading.Tasks.Task.Delay(1000, token);
                                }
                            }
                        }
                        break;
                    }
                }
                await Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        private void PreProcessManagedIdentityParametersWithGetResult()
        {
            bool supportsSystemAssignedIdentity = (true == this.EnableSystemAssignedIdentity || null == this.EnableSystemAssignedIdentity && true == _parametersBody?.IdentityType?.Contains("SystemAssigned"));
            bool supportsUserAssignedIdentity = false;
            if (this.UserAssignedIdentity?.Length > 0)
            {
                // calculate UserAssignedIdentity
                _parametersBody.IdentityUserAssignedIdentity.Clear();
                foreach( var id in this.UserAssignedIdentity )
                {
                    _parametersBody.IdentityUserAssignedIdentity.Add(id, new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserIdentity());
                }
            }
            supportsUserAssignedIdentity = true == this.MyInvocation?.BoundParameters?.ContainsKey("UserAssignedIdentity") && this.UserAssignedIdentity?.Length > 0 ||
                    true != this.MyInvocation?.BoundParameters?.ContainsKey("UserAssignedIdentity") && true == _parametersBody.IdentityType?.Contains("UserAssigned");
            if (!supportsUserAssignedIdentity)
            {
                _parametersBody.IdentityUserAssignedIdentity = null;
            }
            // calculate IdentityType
            if ((supportsUserAssignedIdentity && supportsSystemAssignedIdentity))
            {
                _parametersBody.IdentityType = "SystemAssigned,UserAssigned";
            }
            else if ((supportsUserAssignedIdentity && !supportsSystemAssignedIdentity))
            {
                _parametersBody.IdentityType = "UserAssigned";
            }
            else if ((!supportsUserAssignedIdentity && supportsSystemAssignedIdentity))
            {
                _parametersBody.IdentityType = "SystemAssigned";
            }
            else
            {
                _parametersBody.IdentityType = "None";
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'ServersCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async global::System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    _parametersBody = await this.Client.ServersGetWithResult(SubscriptionId, ResourceGroupName, Name, this, Pipeline);
                    this.PreProcessManagedIdentityParametersWithGetResult();
                    this.Update_parametersBody();
                    await this.Client.ServersCreateOrUpdate(SubscriptionId, ResourceGroupName, Name, _parametersBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeUpdate);
                    await ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { SubscriptionId=SubscriptionId,ResourceGroupName=ResourceGroupName,Name=Name})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAzPostgreSqlFlexibleServer_UpdateExpanded" /> cmdlet class.
        /// </summary>
        public UpdateAzPostgreSqlFlexibleServer_UpdateExpanded()
        {

        }

        private void Update_parametersBody()
        {
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("Tag")))
            {
                this.Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags)(this.MyInvocation?.BoundParameters["Tag"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ReplicationRole")))
            {
                this.ReplicationRole = (string)(this.MyInvocation?.BoundParameters["ReplicationRole"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("CreateMode")))
            {
                this.CreateMode = (string)(this.MyInvocation?.BoundParameters["CreateMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuTier")))
            {
                this.SkuTier = (string)(this.MyInvocation?.BoundParameters["SkuTier"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AdministratorLoginPassword")))
            {
                this.AdministratorLoginPassword = (System.Security.SecureString)(this.MyInvocation?.BoundParameters["AdministratorLoginPassword"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("Version")))
            {
                this.Version = (string)(this.MyInvocation?.BoundParameters["Version"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageAutoGrow")))
            {
                this.StorageAutoGrow = (string)(this.MyInvocation?.BoundParameters["StorageAutoGrow"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageType")))
            {
                this.StorageType = (string)(this.MyInvocation?.BoundParameters["StorageType"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataEncryptionType")))
            {
                this.DataEncryptionType = (string)(this.MyInvocation?.BoundParameters["DataEncryptionType"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuName")))
            {
                this.SkuName = (string)(this.MyInvocation?.BoundParameters["SkuName"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("IdentityPrincipalId")))
            {
                this.IdentityPrincipalId = (string)(this.MyInvocation?.BoundParameters["IdentityPrincipalId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageSizeGb")))
            {
                this.StorageSizeGb = (int)(this.MyInvocation?.BoundParameters["StorageSizeGb"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageTier")))
            {
                this.StorageTier = (string)(this.MyInvocation?.BoundParameters["StorageTier"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageIop")))
            {
                this.StorageIop = (int)(this.MyInvocation?.BoundParameters["StorageIop"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageThroughput")))
            {
                this.StorageThroughput = (int)(this.MyInvocation?.BoundParameters["StorageThroughput"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AuthConfigActiveDirectoryAuth")))
            {
                this.AuthConfigActiveDirectoryAuth = (string)(this.MyInvocation?.BoundParameters["AuthConfigActiveDirectoryAuth"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AuthConfigPasswordAuth")))
            {
                this.AuthConfigPasswordAuth = (string)(this.MyInvocation?.BoundParameters["AuthConfigPasswordAuth"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AuthConfigTenantId")))
            {
                this.AuthConfigTenantId = (string)(this.MyInvocation?.BoundParameters["AuthConfigTenantId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataEncryptionPrimaryKeyUri")))
            {
                this.DataEncryptionPrimaryKeyUri = (string)(this.MyInvocation?.BoundParameters["DataEncryptionPrimaryKeyUri"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataEncryptionPrimaryUserAssignedIdentityId")))
            {
                this.DataEncryptionPrimaryUserAssignedIdentityId = (string)(this.MyInvocation?.BoundParameters["DataEncryptionPrimaryUserAssignedIdentityId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataEncryptionGeoBackupKeyUri")))
            {
                this.DataEncryptionGeoBackupKeyUri = (string)(this.MyInvocation?.BoundParameters["DataEncryptionGeoBackupKeyUri"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataEncryptionGeoBackupUserAssignedIdentityId")))
            {
                this.DataEncryptionGeoBackupUserAssignedIdentityId = (string)(this.MyInvocation?.BoundParameters["DataEncryptionGeoBackupUserAssignedIdentityId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("BackupRetentionDay")))
            {
                this.BackupRetentionDay = (int)(this.MyInvocation?.BoundParameters["BackupRetentionDay"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("NetworkPublicNetworkAccess")))
            {
                this.NetworkPublicNetworkAccess = (string)(this.MyInvocation?.BoundParameters["NetworkPublicNetworkAccess"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("NetworkDelegatedSubnetResourceId")))
            {
                this.NetworkDelegatedSubnetResourceId = (string)(this.MyInvocation?.BoundParameters["NetworkDelegatedSubnetResourceId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("NetworkPrivateDnsZoneArmResourceId")))
            {
                this.NetworkPrivateDnsZoneArmResourceId = (string)(this.MyInvocation?.BoundParameters["NetworkPrivateDnsZoneArmResourceId"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("HighAvailabilityMode")))
            {
                this.HighAvailabilityMode = (string)(this.MyInvocation?.BoundParameters["HighAvailabilityMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("HighAvailabilityStandbyAvailabilityZone")))
            {
                this.HighAvailabilityStandbyAvailabilityZone = (string)(this.MyInvocation?.BoundParameters["HighAvailabilityStandbyAvailabilityZone"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("MaintenanceWindowCustomWindow")))
            {
                this.MaintenanceWindowCustomWindow = (string)(this.MyInvocation?.BoundParameters["MaintenanceWindowCustomWindow"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("MaintenanceWindowStartHour")))
            {
                this.MaintenanceWindowStartHour = (int)(this.MyInvocation?.BoundParameters["MaintenanceWindowStartHour"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("MaintenanceWindowStartMinute")))
            {
                this.MaintenanceWindowStartMinute = (int)(this.MyInvocation?.BoundParameters["MaintenanceWindowStartMinute"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("MaintenanceWindowDayOfWeek")))
            {
                this.MaintenanceWindowDayOfWeek = (int)(this.MyInvocation?.BoundParameters["MaintenanceWindowDayOfWeek"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ReplicaRole")))
            {
                this.ReplicaRole = (string)(this.MyInvocation?.BoundParameters["ReplicaRole"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ReplicaPromoteMode")))
            {
                this.ReplicaPromoteMode = (string)(this.MyInvocation?.BoundParameters["ReplicaPromoteMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ReplicaPromoteOption")))
            {
                this.ReplicaPromoteOption = (string)(this.MyInvocation?.BoundParameters["ReplicaPromoteOption"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ClusterSize")))
            {
                this.ClusterSize = (int)(this.MyInvocation?.BoundParameters["ClusterSize"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ClusterDefaultDatabaseName")))
            {
                this.ClusterDefaultDatabaseName = (string)(this.MyInvocation?.BoundParameters["ClusterDefaultDatabaseName"]);
            }
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnDefault(responseMessage, response, ref _returnNow);
                // if overrideOnDefault has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // Error Response : default
                var code = (await response)?.Code;
                var message = (await response)?.Message;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IErrorResponse>(responseMessage, await response);
                    WriteError( new global::System.Management.Automation.ErrorRecord(ex, ex.Code, global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(ex.Message) { RecommendedAction = ex.Action }
                    });
                }
                else
                {
                    WriteError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception($"[{code}] : {message}"), code?.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(message) { RecommendedAction = global::System.String.Empty }
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // onOk - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer
                var result = (await response);
                WriteObject(result, false);
            }
        }
    }
}