// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Cmdlets;
    using System;

    /// <summary>create a new migration.</summary>
    /// <remarks>
    /// [OpenAPI] Create=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/migrations/{migrationName}"
    /// [DETAILS]
    /// verb: New
    /// subjectPrefix: PostgreSqlFlexibleServer
    /// subject: Migration
    /// variant: CreateViaIdentityFlexibleServerExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.New, @"AzPostgreSqlFlexibleServerMigration_CreateViaIdentityFlexibleServerExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Description(@"create a new migration.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.HttpPath(Path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/migrations/{migrationName}", ApiVersion = "2026-01-01-preview")]
    public partial class NewAzPostgreSqlFlexibleServerMigration_CreateViaIdentityFlexibleServerExpanded : global::System.Management.Automation.PSCmdlet,
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

        /// <summary>A buffer to record first returned object in response.</summary>
        private object _firstResponse = null;

        /// <summary>Properties of a migration.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration _parametersBody = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Migration();

        /// <summary>
        /// A flag to tell whether it is the first returned object in a call. Zero means no response yet. One means 1 returned object.
        /// Two means multiple returned objects in response.
        /// </summary>
        private int _responseSize = 0;

        /// <summary>Password for the user of the source server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Password for the user of the source server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password for the user of the source server.",
        SerializedName = @"sourceServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => _parametersBody.AdminCredentialsSourceServerPassword ?? null; set => _parametersBody.AdminCredentialsSourceServerPassword = value; }

        /// <summary>Password for the user of the target server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Password for the user of the target server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password for the user of the target server.",
        SerializedName = @"targetServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => _parametersBody.AdminCredentialsTargetServerPassword ?? null; set => _parametersBody.AdminCredentialsTargetServerPassword = value; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if cancel must be triggered for the entire migration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if cancel must be triggered for the entire migration.",
        SerializedName = @"cancel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string Cancel { get => _parametersBody.Cancel ?? null; set => _parametersBody.Cancel = value; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PostgreSqlManagementClient Client => Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.ClientAPI;

        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToCancelMigrationOn",
        PossibleTypes = new [] { typeof(string) })]
        public string[] DbsToCancelMigrationOn { get => _parametersBody.DbsToCancelMigrationOn?.ToArray() ?? null /* fixedArrayOf */; set => _parametersBody.DbsToCancelMigrationOn = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>Names of databases to migrate.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Names of databases to migrate.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Names of databases to migrate.",
        SerializedName = @"dbsToMigrate",
        PossibleTypes = new [] { typeof(string) })]
        public string[] DbsToMigrate { get => _parametersBody.DbsToMigrate?.ToArray() ?? null /* fixedArrayOf */; set => _parametersBody.DbsToMigrate = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToTriggerCutoverOn",
        PossibleTypes = new [] { typeof(string) })]
        public string[] DbsToTriggerCutoverOn { get => _parametersBody.DbsToTriggerCutoverOn?.ToArray() ?? null /* fixedArrayOf */; set => _parametersBody.DbsToTriggerCutoverOn = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>Backing field for <see cref="FlexibleServerInputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity _flexibleServerInputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity FlexibleServerInputObject { get => this._flexibleServerInputObject; set => this._flexibleServerInputObject = value; }

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

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>The geo-location where the resource lives</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The geo-location where the resource lives")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The geo-location where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        public string Location { get => _parametersBody.Location ?? null; set => _parametersBody.Location = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if roles and permissions must be migrated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if roles and permissions must be migrated.",
        SerializedName = @"migrateRoles",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string MigrateRole { get => _parametersBody.MigrateRole ?? null; set => _parametersBody.MigrateRole = value; }

        /// <summary>Identifier of the private endpoint migration instance.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the private endpoint migration instance.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the private endpoint migration instance.",
        SerializedName = @"migrationInstanceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        public string MigrationInstanceResourceId { get => _parametersBody.InstanceResourceId ?? null; set => _parametersBody.InstanceResourceId = value; }

        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Mode used to perform the migration: Online or Offline.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mode used to perform the migration: Online or Offline.",
        SerializedName = @"migrationMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        public string MigrationMode { get => _parametersBody.Mode ?? null; set => _parametersBody.Mode = value; }

        /// <summary>Supported option for a migration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Supported option for a migration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Supported option for a migration.",
        SerializedName = @"migrationOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Validate", "Migrate", "ValidateAndMigrate")]
        public string MigrationOption { get => _parametersBody.Option ?? null; set => _parametersBody.Option = value; }

        /// <summary>End time (UTC) for migration window.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "End time (UTC) for migration window.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time (UTC) for migration window.",
        SerializedName = @"migrationWindowEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        public global::System.DateTime MigrationWindowEndTimeInUtc { get => _parametersBody.WindowEndTimeInUtc ?? default(global::System.DateTime); set => _parametersBody.WindowEndTimeInUtc = value; }

        /// <summary>Start time (UTC) for migration window.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Start time (UTC) for migration window.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time (UTC) for migration window.",
        SerializedName = @"migrationWindowStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        public global::System.DateTime MigrationWindowStartTimeInUtc { get => _parametersBody.WindowStartTimeInUtc ?? default(global::System.DateTime); set => _parametersBody.WindowStartTimeInUtc = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of migration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Name of migration.")]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of migration.",
        SerializedName = @"migrationName",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("MigrationName")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Path)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration workflow detects that the database already exists on the target server, it will wait for a confirmation.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration workflow detects that the database already exists on the target server, it will wait for a confirmation.",
        SerializedName = @"overwriteDbsInTarget",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string OverwriteDbsInTarget { get => _parametersBody.OverwriteDbsInTarget ?? null; set => _parametersBody.OverwriteDbsInTarget = value; }

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
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.",
        SerializedName = @"sourceServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        public string SecretParameterSourceServerUsername { get => _parametersBody.SecretParameterSourceServerUsername ?? null; set => _parametersBody.SecretParameterSourceServerUsername = value; }

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.",
        SerializedName = @"targetServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        public string SecretParameterTargetServerUsername { get => _parametersBody.SecretParameterTargetServerUsername ?? null; set => _parametersBody.SecretParameterTargetServerUsername = value; }

        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates whether to setup logical replication on source server, if needed.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether to setup logical replication on source server, if needed.",
        SerializedName = @"setupLogicalReplicationOnSourceDbIfNeeded",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string SetupLogicalReplicationOnSourceDbIfNeeded { get => _parametersBody.SetupLogicalReplicationOnSourceDbIfNeeded ?? null; set => _parametersBody.SetupLogicalReplicationOnSourceDbIfNeeded = value; }

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration service will always use it to connect to the source server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration service will always use it to connect to the source server.",
        SerializedName = @"sourceDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        public string SourceDbServerFullyQualifiedDomainName { get => _parametersBody.SourceDbServerFullyQualifiedDomainName ?? null; set => _parametersBody.SourceDbServerFullyQualifiedDomainName = value; }

        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types this must be set to ipaddress:port@username or hostname:port@username.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types this must be set to ipaddress:port@username or hostname:port@username.",
        SerializedName = @"sourceDbServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        public string SourceDbServerResourceId { get => _parametersBody.SourceDbServerResourceId ?? null; set => _parametersBody.SourceDbServerResourceId = value; }

        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL, Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL, GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer, PostgreSQLSingleServer, or Supabase_PostgreSQL")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL, Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL, GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer, PostgreSQLSingleServer, or Supabase_PostgreSQL",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("OnPremises", "AWS", "GCP", "AzureVM", "PostgreSQLSingleServer", "AWS_RDS", "AWS_AURORA", "AWS_EC2", "GCP_CloudSQL", "GCP_AlloyDB", "GCP_Compute", "EDB", "EDB_Oracle_Server", "EDB_PostgreSQL", "PostgreSQLFlexibleServer", "PostgreSQLCosmosDB", "Huawei_RDS", "Huawei_Compute", "Heroku_PostgreSQL", "Crunchy_PostgreSQL", "ApsaraDB_RDS", "Digital_Ocean_Droplets", "Digital_Ocean_PostgreSQL", "Supabase_PostgreSQL")]
        public string SourceType { get => _parametersBody.SourceType ?? null; set => _parametersBody.SourceType = value; }

        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other source types is 'Prefer'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other source types is 'Prefer'.",
        SerializedName = @"sslMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Prefer", "Require", "VerifyCA", "VerifyFull")]
        public string SslMode { get => _parametersBody.SslMode ?? null; set => _parametersBody.SslMode = value; }

        /// <summary>Indicates if data migration must start right away.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if data migration must start right away.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if data migration must start right away.",
        SerializedName = @"startDataMigration",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string StartDataMigration { get => _parametersBody.StartDataMigration ?? null; set => _parametersBody.StartDataMigration = value; }

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
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration service will always use it to connect to the target server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration service will always use it to connect to the target server.",
        SerializedName = @"targetDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        public string TargetDbServerFullyQualifiedDomainName { get => _parametersBody.TargetDbServerFullyQualifiedDomainName ?? null; set => _parametersBody.TargetDbServerFullyQualifiedDomainName = value; }

        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Indicates if cutover must be triggered for the entire migration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Category(global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if cutover must be triggered for the entire migration.",
        SerializedName = @"triggerCutover",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        public string TriggerCutover { get => _parametersBody.TriggerCutover ?? null; set => _parametersBody.TriggerCutover = value; }

        /// <summary>
        /// <c>overrideOnCreated</c> will be called before the regular onCreated has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onCreated method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnCreated(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

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

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            if (1 ==_responseSize)
            {
                // Flush buffer
                WriteObject(_firstResponse);
            }
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
                        var data = messageData();
                        WriteInformation(data.Message, new string[]{});
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
                }
                await Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAzPostgreSqlFlexibleServerMigration_CreateViaIdentityFlexibleServerExpanded"
        /// /> cmdlet class.
        /// </summary>
        public NewAzPostgreSqlFlexibleServerMigration_CreateViaIdentityFlexibleServerExpanded()
        {

        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'MigrationsCreate' operation"))
                {
                    using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token) )
                    {
                        asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token);
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
                    if (FlexibleServerInputObject?.Id != null)
                    {
                        this.FlexibleServerInputObject.Id += $"/migrations/{(global::System.Uri.EscapeDataString(this.Name.ToString()))}";
                        await this.Client.MigrationsCreateViaIdentity(FlexibleServerInputObject.Id, _parametersBody, onOk, onCreated, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeCreate);
                    }
                    else
                    {
                        // try to call with PATH parameters from Input Object
                        if (null == FlexibleServerInputObject.SubscriptionId)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("FlexibleServerInputObject has null value for FlexibleServerInputObject.SubscriptionId"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, FlexibleServerInputObject) );
                        }
                        if (null == FlexibleServerInputObject.ResourceGroupName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("FlexibleServerInputObject has null value for FlexibleServerInputObject.ResourceGroupName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, FlexibleServerInputObject) );
                        }
                        if (null == FlexibleServerInputObject.ServerName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("FlexibleServerInputObject has null value for FlexibleServerInputObject.ServerName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, FlexibleServerInputObject) );
                        }
                        await this.Client.MigrationsCreate(FlexibleServerInputObject.SubscriptionId ?? null, FlexibleServerInputObject.ResourceGroupName ?? null, FlexibleServerInputObject.ServerName ?? null, Name, _parametersBody, onOk, onCreated, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeCreate);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { Name=Name})
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

        /// <summary>a delegate that is called when the remote service returns 201 (Created).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onCreated(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnCreated(responseMessage, response, ref _returnNow);
                // if overrideOnCreated has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // onCreated - response for 201 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration
                var result = (await response);
                if (null != result)
                {
                    if (0 == _responseSize)
                    {
                        _firstResponse = result;
                        _responseSize = 1;
                    }
                    else
                    {
                        if (1 ==_responseSize)
                        {
                            // Flush buffer
                            WriteObject(_firstResponse.AddMultipleTypeNameIntoPSObject());
                        }
                        WriteObject(result.AddMultipleTypeNameIntoPSObject());
                        _responseSize = 2;
                    }
                }
            }
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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration">Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration
                var result = (await response);
                if (null != result)
                {
                    if (0 == _responseSize)
                    {
                        _firstResponse = result;
                        _responseSize = 1;
                    }
                    else
                    {
                        if (1 ==_responseSize)
                        {
                            // Flush buffer
                            WriteObject(_firstResponse.AddMultipleTypeNameIntoPSObject());
                        }
                        WriteObject(result.AddMultipleTypeNameIntoPSObject());
                        _responseSize = 2;
                    }
                }
            }
        }
    }
}