// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Cmdlets;
    using System;

    /// <summary>
    /// update a mongo cluster. update overwrites all properties for the resource. To only modify some of the properties, use
    /// PATCH.
    /// </summary>
    /// <remarks>
    /// [OpenAPI] Get=>GET:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}"
    /// [DETAILS]
    /// verb: Update
    /// subjectPrefix: DocumentDB
    /// subject: MongoCluster
    /// variant: UpdateViaIdentityExpanded
    /// [OpenAPI] CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/mongoClusters/{mongoClusterName}"
    /// [DETAILS]
    /// verb: Update
    /// subjectPrefix: DocumentDB
    /// subject: MongoCluster
    /// variant: UpdateViaIdentityExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsData.Update, @"AzDocumentDBMongoCluster_UpdateViaIdentityExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Description(@"update a mongo cluster. update overwrites all properties for the resource. To only modify some of the properties, use PATCH.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Generated]
    public partial class UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IContext
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

        /// <summary>Represents a mongo cluster resource.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster _resourceBody = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoCluster();

        /// <summary>The administrator password.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The administrator password.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator password.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        public System.Security.SecureString AdministratorPassword { get => _resourceBody.AdministratorPassword ?? null; set => _resourceBody.AdministratorPassword = value; }

        /// <summary>The administrator user name.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The administrator user name.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator user name.",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        public string AdministratorUserName { get => _resourceBody.AdministratorUserName ?? null; set => _resourceBody.AdministratorUserName = value; }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Allowed authentication modes for data access on the cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allowed authentication modes for data access on the cluster.",
        SerializedName = @"allowedModes",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("NativeAuth", "MicrosoftEntraID")]
        public string[] AuthConfigAllowedMode { get => _resourceBody.AuthConfigAllowedMode?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.AuthConfigAllowedMode = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.MongoClusterManagementClient Client => Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.ClientAPI;

        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30', 'M40'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30', 'M40'.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        public string ComputeTier { get => _resourceBody.ComputeTier ?? null; set => _resourceBody.ComputeTier = value; }

        /// <summary>The URI of the key vault key used for encryption.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The URI of the key vault key used for encryption.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the key vault key used for encryption.",
        SerializedName = @"keyEncryptionKeyUrl",
        PossibleTypes = new [] { typeof(string) })]
        public string CustomerManagedKeyEncryptionKeyUrl { get => _resourceBody.CustomerManagedKeyEncryptionKeyUrl ?? null; set => _resourceBody.CustomerManagedKeyEncryptionKeyUrl = value; }

        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The mode to indicate whether the Mongo Data API is enabled for a cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The mode to indicate whether the Mongo Data API is enabled for a cluster.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string DataApiMode { get => _resourceBody.DataApiMode ?? null; set => _resourceBody.DataApiMode = value; }

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Determines whether to enable a system-assigned identity for the resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Determines whether to enable a system-assigned identity for the resource.")]
        public System.Boolean? EnableSystemAssignedIdentity { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>The target high availability mode requested for the cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The target high availability mode requested for the cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target high availability mode requested for the cluster.",
        SerializedName = @"targetMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Disabled", "SameZone", "ZoneRedundantPreferred")]
        public string HighAvailabilityTargetMode { get => _resourceBody.HighAvailabilityTargetMode ?? null; set => _resourceBody.HighAvailabilityTargetMode = value; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Backing field for <see cref="InputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity _inputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity InputObject { get => this._inputObject; set => this._inputObject = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of identity. Only 'UserAssignedIdentity' is supported.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity. Only 'UserAssignedIdentity' is supported.",
        SerializedName = @"identityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("UserAssignedIdentity")]
        public string KeyEncryptionKeyIdentityType { get => _resourceBody.KeyEncryptionKeyIdentityType ?? null; set => _resourceBody.KeyEncryptionKeyIdentityType = value; }

        /// <summary>The user assigned identity resource id.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The user assigned identity resource id.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user assigned identity resource id.",
        SerializedName = @"userAssignedIdentityResourceId",
        PossibleTypes = new [] { typeof(string) })]
        public string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get => _resourceBody.KeyEncryptionKeyIdentityUserAssignedIdentityResourceId ?? null; set => _resourceBody.KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.",
        SerializedName = @"networkBypassMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("None", "AzureCosmosDB")]
        public string NetworkBypassMode { get => _resourceBody.NetworkBypassMode ?? null; set => _resourceBody.NetworkBypassMode = value; }

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>List of private endpoint connections.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "List of private endpoint connections.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of private endpoint connections.",
        SerializedName = @"previewFeatures",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("GeoReplicas")]
        public string[] PreviewFeature { get => _resourceBody.PreviewFeature?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.PreviewFeature = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether or not public endpoint access is allowed for this mongo cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not public endpoint access is allowed for this mongo cluster.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        public string PublicNetworkAccess { get => _resourceBody.PublicNetworkAccess ?? null; set => _resourceBody.PublicNetworkAccess = value; }

        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The Mongo DB server version. Defaults to the latest available version if not specified.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Mongo DB server version. Defaults to the latest available version if not specified.",
        SerializedName = @"serverVersion",
        PossibleTypes = new [] { typeof(string) })]
        public string ServerVersion { get => _resourceBody.ServerVersion ?? null; set => _resourceBody.ServerVersion = value; }

        /// <summary>Number of shards to provision on the cluster.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Number of shards to provision on the cluster.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of shards to provision on the cluster.",
        SerializedName = @"shardCount",
        PossibleTypes = new [] { typeof(int) })]
        public int ShardingShardCount { get => _resourceBody.ShardingShardCount ?? default(int); set => _resourceBody.ShardingShardCount = value; }

        /// <summary>The size of the data disk assigned to each server.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The size of the data disk assigned to each server.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The size of the data disk assigned to each server.",
        SerializedName = @"sizeGb",
        PossibleTypes = new [] { typeof(long) })]
        public long StorageSizeGb { get => _resourceBody.StorageSizeGb ?? default(long); set => _resourceBody.StorageSizeGb = value; }

        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of storage to provision the cluster servers with.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of storage to provision the cluster servers with.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("PremiumSSD", "PremiumSSDv2")]
        public string StorageType { get => _resourceBody.StorageType ?? null; set => _resourceBody.StorageType = value; }

        /// <summary>Resource tags.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource tags.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ITrackedResourceTags) })]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ITrackedResourceTags Tag { get => _resourceBody.Tag ?? null /* object */; set => _resourceBody.Tag = value; }

        /// <summary>
        /// The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in
        /// the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'")]
        [global::System.Management.Automation.AllowEmptyCollection]
        public string[] UserAssignedIdentity { get; set; }

        /// <summary>
        /// <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster">Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>
        /// a duplicate instance of UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Cmdlets.UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded Clone()
        {
            var clone = new UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded();
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
            clone._resourceBody = this._resourceBody;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
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
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.Progress:
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
                    case Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.DelayBeforePolling:
                    {
                        var data = messageData();
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
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
                await Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        private void PreProcessManagedIdentityParametersWithGetResult()
        {
            bool supportsSystemAssignedIdentity = (true == this.EnableSystemAssignedIdentity || null == this.EnableSystemAssignedIdentity && true == _resourceBody?.IdentityType?.Contains("SystemAssigned"));
            bool supportsUserAssignedIdentity = false;
            if (this.UserAssignedIdentity?.Length > 0)
            {
                // calculate UserAssignedIdentity
                _resourceBody.IdentityUserAssignedIdentity.Clear();
                foreach( var id in this.UserAssignedIdentity )
                {
                    _resourceBody.IdentityUserAssignedIdentity.Add(id, new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.UserAssignedIdentity());
                }
            }
            supportsUserAssignedIdentity = true == this.MyInvocation?.BoundParameters?.ContainsKey("UserAssignedIdentity") && this.UserAssignedIdentity?.Length > 0 ||
                    true != this.MyInvocation?.BoundParameters?.ContainsKey("UserAssignedIdentity") && true == _resourceBody.IdentityType?.Contains("UserAssigned");
            if (!supportsUserAssignedIdentity)
            {
                _resourceBody.IdentityUserAssignedIdentity = null;
            }
            // calculate IdentityType
            if ((supportsUserAssignedIdentity && supportsSystemAssignedIdentity))
            {
                _resourceBody.IdentityType = "SystemAssigned,UserAssigned";
            }
            else if ((supportsUserAssignedIdentity && !supportsSystemAssignedIdentity))
            {
                _resourceBody.IdentityType = "UserAssigned";
            }
            else if ((!supportsUserAssignedIdentity && supportsSystemAssignedIdentity))
            {
                _resourceBody.IdentityType = "SystemAssigned";
            }
            else
            {
                _resourceBody.IdentityType = "None";
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'MongoClustersCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletProcessRecordEnd).Wait();
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
                await ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    if (InputObject?.Id != null)
                    {
                        _resourceBody = await this.Client.MongoClustersGetViaIdentityWithResult(InputObject.Id, this, Pipeline);
                        this.PreProcessManagedIdentityParametersWithGetResult();
                        this.Update_resourceBody();
                        await this.Client.MongoClustersCreateOrUpdateViaIdentity(InputObject.Id, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode.IncludeUpdate);
                    }
                    else
                    {
                        // try to call with PATH parameters from Input Object
                        if (null == InputObject.SubscriptionId)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.SubscriptionId"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.ResourceGroupName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.ResourceGroupName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.MongoClusterName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.MongoClusterName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        _resourceBody = await this.Client.MongoClustersGetWithResult(InputObject.SubscriptionId ?? null, InputObject.ResourceGroupName ?? null, InputObject.MongoClusterName ?? null, this, Pipeline);
                        this.PreProcessManagedIdentityParametersWithGetResult();
                        this.Update_resourceBody();
                        await this.Client.MongoClustersCreateOrUpdate(InputObject.SubscriptionId ?? null, InputObject.ResourceGroupName ?? null, InputObject.MongoClusterName ?? null, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode.IncludeUpdate);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded" /> cmdlet class.
        /// </summary>
        public UpdateAzDocumentDBMongoCluster_UpdateViaIdentityExpanded()
        {

        }

        private void Update_resourceBody()
        {
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("Tag")))
            {
                this.Tag = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ITrackedResourceTags)(this.MyInvocation?.BoundParameters["Tag"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ServerVersion")))
            {
                this.ServerVersion = (string)(this.MyInvocation?.BoundParameters["ServerVersion"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("PublicNetworkAccess")))
            {
                this.PublicNetworkAccess = (string)(this.MyInvocation?.BoundParameters["PublicNetworkAccess"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("PreviewFeature")))
            {
                this.PreviewFeature = (string[])(this.MyInvocation?.BoundParameters["PreviewFeature"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("NetworkBypassMode")))
            {
                this.NetworkBypassMode = (string)(this.MyInvocation?.BoundParameters["NetworkBypassMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageSizeGb")))
            {
                this.StorageSizeGb = (long)(this.MyInvocation?.BoundParameters["StorageSizeGb"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("StorageType")))
            {
                this.StorageType = (string)(this.MyInvocation?.BoundParameters["StorageType"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ShardingShardCount")))
            {
                this.ShardingShardCount = (int)(this.MyInvocation?.BoundParameters["ShardingShardCount"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataApiMode")))
            {
                this.DataApiMode = (string)(this.MyInvocation?.BoundParameters["DataApiMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AdministratorUserName")))
            {
                this.AdministratorUserName = (string)(this.MyInvocation?.BoundParameters["AdministratorUserName"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AdministratorPassword")))
            {
                this.AdministratorPassword = (System.Security.SecureString)(this.MyInvocation?.BoundParameters["AdministratorPassword"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("HighAvailabilityTargetMode")))
            {
                this.HighAvailabilityTargetMode = (string)(this.MyInvocation?.BoundParameters["HighAvailabilityTargetMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("ComputeTier")))
            {
                this.ComputeTier = (string)(this.MyInvocation?.BoundParameters["ComputeTier"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("AuthConfigAllowedMode")))
            {
                this.AuthConfigAllowedMode = (string[])(this.MyInvocation?.BoundParameters["AuthConfigAllowedMode"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("CustomerManagedKeyEncryptionKeyUrl")))
            {
                this.CustomerManagedKeyEncryptionKeyUrl = (string)(this.MyInvocation?.BoundParameters["CustomerManagedKeyEncryptionKeyUrl"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("KeyEncryptionKeyIdentityType")))
            {
                this.KeyEncryptionKeyIdentityType = (string)(this.MyInvocation?.BoundParameters["KeyEncryptionKeyIdentityType"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId")))
            {
                this.KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = (string)(this.MyInvocation?.BoundParameters["KeyEncryptionKeyIdentityUserAssignedIdentityResourceId"]);
            }
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse> response)
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
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IErrorResponse>(responseMessage, await response);
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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster">Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster
                var result = (await response);
                WriteObject(result, false);
            }
        }
    }
}