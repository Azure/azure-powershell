namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Creates or updates a service endpoint policy definition in the specified service endpoint policy.
    /// </summary>
    /// <remarks>
    /// [OpenAPI] ServiceEndpointPolicyDefinitions_CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/serviceEndpointPolicies/{serviceEndpointPolicyName}/serviceEndpointPolicyDefinitions/{serviceEndpointPolicyDefinitionName}"
    /// [METADATA]
    /// path: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/serviceEndpointPolicies/{serviceEndpointPolicyName}/serviceEndpointPolicyDefinitions/{serviceEndpointPolicyDefinitionName}'
    /// apiVersions:
    /// - '2019-02-01'
    /// filename:
    /// - 'mem:///990?oai3.shaken.json'
    /// originalLocations:
    /// - >-
    /// https://github.com/Azure/azure-rest-api-specs/blob/resource-hybrid-profile-fix/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/serviceEndpointPolicy.json#/paths/~1subscriptions~1{subscriptionId}~1resourceGroups~1{resourceGroupName}~1providers~1Microsoft.Network~1serviceEndpointPolicies~1{serviceEndpointPolicyName}~1serviceEndpointPolicyDefinitions~1{serviceEndpointPolicyDefinitionName}
    /// profiles:
    /// latest-2019-04-30: '2019-02-01'
    /// [DETAILS]
    /// verb: Set
    /// subjectPrefix:
    /// subject: ServiceEndpointPolicyDefinition
    /// variant: UpdateExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.Set, @"AzServiceEndpointPolicyDefinition_UpdateExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Description(@"Creates or updates a service endpoint policy definition in the specified service endpoint policy.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Profile("latest-2019-04-30")]
    public partial class SetAzServiceEndpointPolicyDefinition_UpdateExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener
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

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Network Client => Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.ClientAPI;

        /// <summary>
        /// The credentials, account, tenant, and subscription used for communication with Azure
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>A description for this rule. Restricted to 140 chars.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A description for this rule. Restricted to 140 chars.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A description for this rule. Restricted to 140 chars.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        public string Description { get => ServiceEndpointPolicyDefinitionsBody.Description ?? null; set => ServiceEndpointPolicyDefinitionsBody.Description = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A unique read-only string that changes whenever the resource is updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        public string Etag { get => ServiceEndpointPolicyDefinitionsBody.Etag ?? null; set => ServiceEndpointPolicyDefinitionsBody.Etag = value; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Resource ID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource ID.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        public string Id { get => ServiceEndpointPolicyDefinitionsBody.Id ?? null; set => ServiceEndpointPolicyDefinitionsBody.Id = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>
        /// <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the service endpoint policy definition name.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the service endpoint policy definition name.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the service endpoint policy definition name.",
        SerializedName = @"serviceEndpointPolicyDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("ServiceEndpointPolicyDefinitionName")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the resource group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the resource group.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The name of the resource that is unique within a resource group. This name can be used to access the resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string ResourceName { get => ServiceEndpointPolicyDefinitionsBody.Name ?? null; set => ServiceEndpointPolicyDefinitionsBody.Name = value; }

        /// <summary>Service endpoint name.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Service endpoint name.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service endpoint name.",
        SerializedName = @"service",
        PossibleTypes = new [] { typeof(string) })]
        public string Service { get => ServiceEndpointPolicyDefinitionsBody.Service ?? null; set => ServiceEndpointPolicyDefinitionsBody.Service = value; }

        /// <summary>Backing field for <see cref="ServiceEndpointPolicyDefinitionsBody" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition _serviceEndpointPolicyDefinitionsBody= new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ServiceEndpointPolicyDefinition();

        /// <summary>Service Endpoint policy definitions.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition ServiceEndpointPolicyDefinitionsBody { get => this._serviceEndpointPolicyDefinitionsBody; set => this._serviceEndpointPolicyDefinitionsBody = value; }

        /// <summary>Backing field for <see cref="ServiceEndpointPolicyName" /> property.</summary>
        private string _serviceEndpointPolicyName;

        /// <summary>The name of the service endpoint policy.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the service endpoint policy.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the service endpoint policy.",
        SerializedName = @"serviceEndpointPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string ServiceEndpointPolicyName { get => this._serviceEndpointPolicyName; set => this._serviceEndpointPolicyName = value; }

        /// <summary>A list of service resources.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A list of service resources.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of service resources.",
        SerializedName = @"serviceResources",
        PossibleTypes = new [] { typeof(string) })]
        public string[] ServiceResource { get => ServiceEndpointPolicyDefinitionsBody.ServiceResource ?? null /* arrayOf */; set => ServiceEndpointPolicyDefinitionsBody.ServiceResource = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part
        /// of the URI for every service call.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.DefaultInfo(
        Name = @"",
        Description =@"",
        Script = @"(Get-AzContext).Subscription.Id")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition"
        /// /> from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of SetAzServiceEndpointPolicyDefinition_UpdateExpanded</returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.SetAzServiceEndpointPolicyDefinition_UpdateExpanded Clone()
        {
            var clone = new SetAzServiceEndpointPolicyDefinition_UpdateExpanded();
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
            clone.ServiceEndpointPolicyDefinitionsBody = this.ServiceEndpointPolicyDefinitionsBody;
            clone.ResourceGroupName = this.ResourceGroupName;
            clone.ServiceEndpointPolicyName = this.ServiceEndpointPolicyName;
            clone.Name = this.Name;
            clone.SubscriptionId = this.SubscriptionId;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletEndProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.DelayBeforePolling:
                    {
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            var data = messageData();
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }
                        break;
                    }
                }
                await Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.Signal(id, token, messageData, (i,t,m) => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(i,t,()=> Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventDataConverter.ConvertFrom( m() ) as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventData ), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'ServiceEndpointPolicyDefinitionsCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordEnd).Wait();
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
                await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordAsyncStart); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    await this.Client.ServiceEndpointPolicyDefinitionsCreateOrUpdate(ResourceGroupName, ServiceEndpointPolicyName, Name, SubscriptionId, ServiceEndpointPolicyDefinitionsBody, onOk, this, Pipeline);
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  ResourceGroupName=ResourceGroupName,ServiceEndpointPolicyName=ServiceEndpointPolicyName,Name=Name,SubscriptionId=SubscriptionId,body=ServiceEndpointPolicyDefinitionsBody})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>
        /// Intializes a new instance of the <see cref="SetAzServiceEndpointPolicyDefinition_UpdateExpanded" /> cmdlet class.
        /// </summary>
        public SetAzServiceEndpointPolicyDefinition_UpdateExpanded()
        {

        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition"
        /// /> from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicyDefinition
                WriteObject((await response));
            }
        }
    }
}