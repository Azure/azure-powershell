// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Cmdlets;
    using System;

    /// <summary>update a AgriServiceResource</summary>
    /// <remarks>
    /// [OpenAPI] Get=>GET:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AgriculturePlatform/agriServices/{agriServiceResourceName}"
    /// [OpenAPI] CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AgriculturePlatform/agriServices/{agriServiceResourceName}"
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsData.Update, @"AzAgriculturePlatformAgriService_UpdateViaIdentityExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Description(@"update a AgriServiceResource")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Generated]
    public partial class UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IContext
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

        /// <summary>
        /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource _resourceBody = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResource();

        /// <summary>
        /// A flag to tell whether it is the first returned object in a call. Zero means no response yet. One means 1 returned object.
        /// Two means multiple returned objects in response.
        /// </summary>
        private int _responseSize = 0;

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.MicrosoftAgriculturePlatform Client => Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.ClientAPI;

        /// <summary>Data connector credentials of AgriService instance.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Data connector credentials of AgriService instance.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data connector credentials of AgriService instance.",
        SerializedName = @"dataConnectorCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap) })]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap[] DataConnectorCredentials { get => _resourceBody.DataConnectorCredentials?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.DataConnectorCredentials = (value != null ? new System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(value) : null); }

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Determines whether to enable a system-assigned identity for the resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Determines whether to enable a system-assigned identity for the resource.")]
        public System.Boolean? EnableSystemAssignedIdentity { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Backing field for <see cref="InputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriculturePlatformIdentity _inputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriculturePlatformIdentity InputObject { get => this._inputObject; set => this._inputObject = value; }

        /// <summary>AgriService installed solutions.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "AgriService installed solutions.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AgriService installed solutions.",
        SerializedName = @"installedSolutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap) })]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap[] InstalledSolution { get => _resourceBody.InstalledSolution?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.InstalledSolution = (value != null ? new System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(value) : null); }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the
        /// resource this may be omitted.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        public int SkuCapacity { get => _resourceBody.SkuCapacity ?? default(int); set => _resourceBody.SkuCapacity = value; }

        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "If the service has different generations of hardware, for the same SKU, then that can be captured here.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If the service has different generations of hardware, for the same SKU, then that can be captured here.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        public string SkuFamily { get => _resourceBody.SkuFamily ?? null; set => _resourceBody.SkuFamily = value; }

        /// <summary>The name of the SKU. Ex - P3. It is typically a letter+number code</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The name of the SKU. Ex - P3. It is typically a letter+number code")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU. Ex - P3. It is typically a letter+number code",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string SkuName { get => _resourceBody.SkuName ?? null; set => _resourceBody.SkuName = value; }

        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        public string SkuSize { get => _resourceBody.SkuSize ?? null; set => _resourceBody.SkuSize = value; }

        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required
        /// on a PUT.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("Free", "Basic", "Standard", "Premium")]
        public string SkuTier { get => _resourceBody.SkuTier ?? null; set => _resourceBody.SkuTier = value; }

        /// <summary>Resource tags.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource tags.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags) })]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags Tag { get => _resourceBody.Tag ?? null /* object */; set => _resourceBody.Tag = value; }

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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource">Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>
        /// a duplicate instance of UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Cmdlets.UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded Clone()
        {
            var clone = new UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded();
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
            if (1 ==_responseSize)
            {
                // Flush buffer
                WriteObject(_firstResponse);
            }
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
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
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.Progress:
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
                    case Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.DelayBeforePolling:
                    {
                        var data = messageData();
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
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
                await Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
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
                    _resourceBody.IdentityUserAssignedIdentity.Add(id, new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.UserAssignedIdentity());
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
            ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'AgriServiceCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletProcessRecordEnd).Wait();
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
                await ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    if (InputObject?.Id != null)
                    {
                        _resourceBody = await this.Client.AgriServiceGetViaIdentityWithResult(InputObject.Id, this, Pipeline);
                        this.PreProcessManagedIdentityParametersWithGetResult();
                        this.Update_resourceBody();
                        await this.Client.AgriServiceCreateOrUpdateViaIdentity(InputObject.Id, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeUpdate);
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
                        if (null == InputObject.AgriServiceResourceName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.AgriServiceResourceName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        _resourceBody = await this.Client.AgriServiceGetWithResult(InputObject.SubscriptionId ?? null, InputObject.ResourceGroupName ?? null, InputObject.AgriServiceResourceName ?? null, this, Pipeline);
                        this.PreProcessManagedIdentityParametersWithGetResult();
                        this.Update_resourceBody();
                        await this.Client.AgriServiceCreateOrUpdate(InputObject.SubscriptionId ?? null, InputObject.ResourceGroupName ?? null, InputObject.AgriServiceResourceName ?? null, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeCreate|Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeUpdate);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded" /> cmdlet
        /// class.
        /// </summary>
        public UpdateAzAgriculturePlatformAgriService_UpdateViaIdentityExpanded()
        {

        }

        private void Update_resourceBody()
        {
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("Tag")))
            {
                this.Tag = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags)(this.MyInvocation?.BoundParameters["Tag"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("InstalledSolution")))
            {
                this.InstalledSolution = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap[])(this.MyInvocation?.BoundParameters["InstalledSolution"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuTier")))
            {
                this.SkuTier = (string)(this.MyInvocation?.BoundParameters["SkuTier"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuCapacity")))
            {
                this.SkuCapacity = (int)(this.MyInvocation?.BoundParameters["SkuCapacity"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("DataConnectorCredentials")))
            {
                this.DataConnectorCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap[])(this.MyInvocation?.BoundParameters["DataConnectorCredentials"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuName")))
            {
                this.SkuName = (string)(this.MyInvocation?.BoundParameters["SkuName"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuSize")))
            {
                this.SkuSize = (string)(this.MyInvocation?.BoundParameters["SkuSize"]);
            }
            if ((bool)(true == this.MyInvocation?.BoundParameters.ContainsKey("SkuFamily")))
            {
                this.SkuFamily = (string)(this.MyInvocation?.BoundParameters["SkuFamily"]);
            }
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse> response)
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
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IErrorResponse>(responseMessage, await response);
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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource">Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource
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