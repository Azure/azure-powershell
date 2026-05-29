// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Cmdlets;
    using System;

    /// <summary>create hardware settings</summary>
    /// <remarks>
    /// [OpenAPI] CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/hardwareSettings/{hardwareSettingName}"
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.New, @"AzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Description(@"create hardware settings")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.HttpPath(Path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/disconnectedOperations/{name}/hardwareSettings/{hardwareSettingName}", ApiVersion = "2026-03-15")]
    public partial class NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IContext
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

        /// <summary>Hardware settings resource.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting _resourceBody = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSetting();

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.DisconnectedOperationsService Client => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.ClientAPI;

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>The unique Id of the device</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The unique Id of the device")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique Id of the device",
        SerializedName = @"deviceId",
        PossibleTypes = new [] { typeof(string) })]
        public string DeviceId { get => _resourceBody.DeviceId ?? null; set => _resourceBody.DeviceId = value; }

        /// <summary>Backing field for <see cref="DisconnectedOperationInputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity _disconnectedOperationInputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity DisconnectedOperationInputObject { get => this._disconnectedOperationInputObject; set => this._disconnectedOperationInputObject = value; }

        /// <summary>The disk space in GB</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The disk space in GB")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk space in GB",
        SerializedName = @"diskSpaceInGb",
        PossibleTypes = new [] { typeof(int) })]
        public int DiskSpaceInGb { get => _resourceBody.DiskSpaceInGb ?? default(int); set => _resourceBody.DiskSpaceInGb = value; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>Backing field for <see cref="HardwareSettingName" /> property.</summary>
        private string _hardwareSettingName;

        /// <summary>The name of the HardwareSetting</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the HardwareSetting")]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the HardwareSetting",
        SerializedName = @"hardwareSettingName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Path)]
        public string HardwareSettingName { get => this._hardwareSettingName; set => this._hardwareSettingName = value; }

        /// <summary>The hardware SKU</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The hardware SKU")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The hardware SKU",
        SerializedName = @"hardwareSku",
        PossibleTypes = new [] { typeof(string) })]
        public string HardwareSku { get => _resourceBody.HardwareSku ?? null; set => _resourceBody.HardwareSku = value; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>The memory in GB</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The memory in GB")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory in GB",
        SerializedName = @"memoryInGb",
        PossibleTypes = new [] { typeof(int) })]
        public int MemoryInGb { get => _resourceBody.MemoryInGb ?? default(int); set => _resourceBody.MemoryInGb = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>The number of nodes</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The number of nodes")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of nodes",
        SerializedName = @"nodes",
        PossibleTypes = new [] { typeof(int) })]
        public int Node { get => _resourceBody.Node ?? default(int); set => _resourceBody.Node = value; }

        /// <summary>The OEM</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The OEM")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OEM",
        SerializedName = @"oem",
        PossibleTypes = new [] { typeof(string) })]
        public string Oem { get => _resourceBody.Oem ?? null; set => _resourceBody.Oem = value; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>The solution builder extension at registration</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The solution builder extension at registration")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The solution builder extension at registration",
        SerializedName = @"solutionBuilderExtension",
        PossibleTypes = new [] { typeof(string) })]
        public string SolutionBuilderExtension { get => _resourceBody.SolutionBuilderExtension ?? null; set => _resourceBody.SolutionBuilderExtension = value; }

        /// <summary>The total number of cores</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The total number of cores")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total number of cores",
        SerializedName = @"totalCores",
        PossibleTypes = new [] { typeof(int) })]
        public int TotalCore { get => _resourceBody.TotalCore ?? default(int); set => _resourceBody.TotalCore = value; }

        /// <summary>The active version at registration</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The active version at registration")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Category(global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The active version at registration",
        SerializedName = @"versionAtRegistration",
        PossibleTypes = new [] { typeof(string) })]
        public string VersionAtRegistration { get => _resourceBody.VersionAtRegistration ?? null; set => _resourceBody.VersionAtRegistration = value; }

        /// <summary>
        /// <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting">Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>
        /// a duplicate instance of NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Cmdlets.NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded Clone()
        {
            var clone = new NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded();
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
            clone.HardwareSettingName = this.HardwareSettingName;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
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
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.Progress:
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
                    case Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.DelayBeforePolling:
                    {
                        var data = messageData();
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
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
                await Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded"
        /// /> cmdlet class.
        /// </summary>
        public NewAzDisconnectedOperationsHardwareSetting_CreateViaIdentityDisconnectedOperationExpanded()
        {

        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'HardwareSettingsCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletProcessRecordEnd).Wait();
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
                await ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    if (DisconnectedOperationInputObject?.Id != null)
                    {
                        this.DisconnectedOperationInputObject.Id += $"/hardwareSettings/{(global::System.Uri.EscapeDataString(this.HardwareSettingName.ToString()))}";
                        await this.Client.HardwareSettingsCreateOrUpdateViaIdentity(DisconnectedOperationInputObject.Id, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate);
                    }
                    else
                    {
                        // try to call with PATH parameters from Input Object
                        if (null == DisconnectedOperationInputObject.SubscriptionId)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("DisconnectedOperationInputObject has null value for DisconnectedOperationInputObject.SubscriptionId"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, DisconnectedOperationInputObject) );
                        }
                        if (null == DisconnectedOperationInputObject.ResourceGroupName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("DisconnectedOperationInputObject has null value for DisconnectedOperationInputObject.ResourceGroupName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, DisconnectedOperationInputObject) );
                        }
                        if (null == DisconnectedOperationInputObject.Name)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("DisconnectedOperationInputObject has null value for DisconnectedOperationInputObject.Name"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, DisconnectedOperationInputObject) );
                        }
                        await this.Client.HardwareSettingsCreateOrUpdate(DisconnectedOperationInputObject.SubscriptionId ?? null, DisconnectedOperationInputObject.ResourceGroupName ?? null, DisconnectedOperationInputObject.Name ?? null, HardwareSettingName, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeCreate);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { HardwareSettingName=HardwareSettingName})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse> response)
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
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IErrorResponse>(responseMessage, await response);
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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting">Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting
                var result = (await response);
                WriteObject(result, false);
            }
        }
    }
}