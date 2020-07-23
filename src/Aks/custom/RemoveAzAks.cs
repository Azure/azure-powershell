using System;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    using static Extensions;

    /// <summary>Deletes the managed cluster with a specified resource group and name.</summary>
    /// <remarks>
    ///     [OpenAPI]
    ///     ManagedClusters_Delete=>DELETE:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}"
    /// </remarks>
    [Cmdlet(VerbsCommon.Remove, @"AzAks", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    [Description(@"Deletes the managed cluster with a specified resource group and name.")]
    [Generated]
    public partial class RemoveAzAks : KubeCmdletBase, IEventListener
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        ///     The <see cref="CancellationTokenSource" /> for this operation.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>
        ///     Intializes a new instance of the <see cref="RemoveAzAks" /> cmdlet class.
        /// </summary>
        public RemoveAzAks()
        {
        }

        /// <summary>
        ///     Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of
        ///     the URI
        ///     for every service call.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage =
                "Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.")]
        [Info(
            Required = true,
            ReadOnly = false,
            Description =
                @"Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.",
            SerializedName = @"subscriptionId",
            PossibleTypes = new[] {typeof(string)})]
        [DefaultInfo(
            Name = @"",
            Description = @"",
            Script = @"(Get-AzContext).Subscription.Id")]
        [Category(ParameterCategory.Path)]
        public string SubscriptionId
        {
            get => _subscriptionId;
            set => _subscriptionId = value;
        }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter Break { get; set; }

        /// <summary>The reference to the client API class.</summary>
        public AksClient Client => Module.Instance.ClientAPI;

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public InvocationInfo InvocationInformation
        {
            get => __invocationInfo = __invocationInfo ?? MyInvocation;
            set { __invocationInfo = value; }
        }

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "A IAksIdentity object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public IAksIdentity InputObject { get; set; }

        /// <summary>
        ///     Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = Constants.IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        /// <summary>
        ///     Resource group name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.GroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [Info(Required = true)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = Constants.GroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [Info(Required = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation
        ///     continue
        ///     asynchronously.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter NoWait { get; set; }

        /// <summary>
        ///     When specified, forces the cmdlet return a 'bool' given that there isn't a return type by default.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Returns true when the command succeeds")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        ///     The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.HttpPipeline" /> that the remote call
        ///     will use.
        /// </summary>
        private HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [Category(ParameterCategory.Runtime)]
        public Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>
        ///     <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        Action IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
        CancellationToken IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the message is
        ///     completed.
        /// </returns>
        async Task IEventListener.Signal(string id, CancellationToken token, Func<EventData> messageData)
        {
            using (NoSynchronizationContext)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                switch (id)
                {
                    case Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Error:
                    {
                        WriteError(new ErrorRecord(new Exception(messageData().Message), string.Empty,
                            ErrorCategory.NotSpecified, null));
                        return;
                    }
                    case Runtime.Events.DelayBeforePolling:
                    {
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            var data = messageData();
                            if (data.ResponseMessage is HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = string.IsNullOrEmpty(asyncOperation)
                                    ? string.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri :
                                    location
                                    : asyncOperation;
                                WriteObject(new AsyncOperationResponse {Target = uri});
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }

                        break;
                    }
                }

                await Module.Instance.Signal(id, token, messageData,
                    (i, t, m) =>
                        ((IEventListener) this).Signal(i, t, () => EventDataConverter.ConvertFrom(m()) as EventData),
                    InvocationInformation, ParameterSetName, __correlationId, __processRecordId, null);
                if (token.IsCancellationRequested)
                {
                    return;
                }

                WriteDebug($"{id}: {(messageData().Message ?? string.Empty)}");
            }
        }

        /// <summary>
        ///     <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of
        ///     what
        ///     happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.ICloudError" /> from the
        ///     remote call
        /// </param>
        /// <param name="returnNow">
        ///     /// Determines if the rest of the onDefault method should be processed, or if the method should
        ///     return immediately (set to true to skip further processing )
        /// </param>
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> response,
            ref Task<bool> returnNow);

        /// <summary>
        ///     <c>overrideOnNoContent</c> will be called before the regular onNoContent has been processed, allowing customization
        ///     of
        ///     what happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="returnNow">
        ///     /// Determines if the rest of the onNoContent method should be processed, or if the method should
        ///     return immediately (set to true to skip further processing )
        /// </param>
        partial void overrideOnNoContent(HttpResponseMessage responseMessage, ref Task<bool> returnNow);

        /// <summary>
        ///     (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                AttachDebugger.Break();
            }

            ((IEventListener) this).Signal(Runtime.Events.CmdletBeginProcessing).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of RemoveAzAks_Delete</returns>
        public RemoveAzAks Clone()
        {
            var clone = new RemoveAzAks();
            clone.__correlationId = __correlationId;
            clone.__processRecordId = __processRecordId;
            clone.DefaultProfile = DefaultProfile;
            clone.InvocationInformation = InvocationInformation;
            clone.Proxy = Proxy;
            clone.Pipeline = Pipeline;
            clone.AsJob = AsJob;
            clone.Break = Break;
            clone.ProxyCredential = ProxyCredential;
            clone.ProxyUseDefaultCredentials = ProxyUseDefaultCredentials;
            clone.HttpPipelinePrepend = HttpPipelinePrepend;
            clone.HttpPipelineAppend = HttpPipelineAppend;
            clone.SubscriptionId = SubscriptionId;
            clone.ResourceGroupName = ResourceGroupName;
            clone.Name = Name;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            ((IEventListener) this).Signal(Runtime.Events.CmdletEndProcessing).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordStart).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }

            __processRecordId = Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'ManagedClustersDelete' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = Clone();
                        var job = new AsyncJob(instance, MyInvocation.Line, MyInvocation.MyCommand.Name,
                            _cancellationTokenSource.Token, _cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using (var asyncCommandRuntime = new AsyncCommandRuntime(this, ((IEventListener) this).Token))
                        {
                            asyncCommandRuntime.Wait(ProcessRecordAsync(), ((IEventListener) this).Token);
                        }
                    }
                }
            }
            catch (AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach (var innerException in aggregateException.Flatten().InnerExceptions)
                {
                    ((IEventListener) this).Signal(Runtime.Events.CmdletException,
                            $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}")
                        .Wait();
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }

                    // Write exception out to error channel.
                    WriteError(new ErrorRecord(innerException, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
            catch (Exception exception) when ((exception as PipelineStoppedException) == null ||
                                              (exception as PipelineStoppedException).InnerException != null)
            {
                ((IEventListener) this).Signal(Runtime.Events.CmdletException,
                    $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait();
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                // Write exception out to error channel.
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null));
            }
            finally
            {
                ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is
        ///     completed.
        /// </returns>
        protected async Task ProcessRecordAsync()
        {
            using (NoSynchronizationContext)
            {
                await ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordAsyncStart);
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                await ((IEventListener) this).Signal(Runtime.Events.CmdletGetPipeline);
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                Pipeline = Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((CommandRuntime as IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ??
                                     HttpPipelinePrepend);
                }

                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((CommandRuntime as IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ??
                                    HttpPipelineAppend);
                }

                // get the client instance
                try
                {
                    switch (ParameterSetName)
                    {
                        case Constants.IdParameterSet:
                        {
                            var resource = new ResourceIdentifier(Id);
                            ResourceGroupName = resource.ResourceGroupName;
                            Name = resource.ResourceName;
                            break;
                        }
                        case Constants.InputObjectParameterSet:
                        {
                            var resource = new ResourceIdentifier(InputObject.Id);
                            ResourceGroupName = resource.ResourceGroupName;
                            Name = resource.ResourceName;
                            break;
                        }
                    }

                    await ((IEventListener) this).Signal(Runtime.Events.CmdletBeforeAPICall);
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }

                    await Client.ManagedClustersDelete(SubscriptionId, ResourceGroupName, Name, onNoContent, onDefault,
                        this, Pipeline);
                    await ((IEventListener) this).Signal(Runtime.Events.CmdletAfterAPICall);
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }
                }
                catch (UndeclaredResponseException urexception)
                {
                    WriteError(new ErrorRecord(urexception, urexception.StatusCode.ToString(),
                        ErrorCategory.InvalidOperation,
                        new {SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name})
                    {
                        ErrorDetails = new ErrorDetails(urexception.Message) {RecommendedAction = urexception.Action}
                    });
                }
                finally
                {
                    await ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((IEventListener) this).Cancel();
            base.StopProcessing();
        }

        /// <summary>
        ///     a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.ICloudError" /> from the
        ///     remote call
        /// </param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is
        ///     completed.
        /// </returns>
        private async Task onDefault(HttpResponseMessage responseMessage, Task<ICloudError> response)
        {
            using (NoSynchronizationContext)
            {
                var _returnNow = Task.FromResult(false);
                overrideOnDefault(responseMessage, response, ref _returnNow);
                // if overrideOnDefault has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }

                // Error Response : default
                var code = (await response)?.Code;
                var message = (await response)?.Message;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    var ex = new RestException<ICloudError>(responseMessage, await response);
                    WriteError(new ErrorRecord(ex, ex.Code, ErrorCategory.InvalidOperation,
                        new {SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name})
                    {
                        ErrorDetails = new ErrorDetails(ex.Message) {RecommendedAction = ex.Action}
                    });
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception($"[{code}] : {message}"), code?.ToString(),
                        ErrorCategory.InvalidOperation,
                        new {SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name})
                    {
                        ErrorDetails = new ErrorDetails(message) {RecommendedAction = string.Empty}
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 204 (NoContent).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is
        ///     completed.
        /// </returns>
        private async Task onNoContent(HttpResponseMessage responseMessage)
        {
            using (NoSynchronizationContext)
            {
                var _returnNow = Task.FromResult(false);
                overrideOnNoContent(responseMessage, ref _returnNow);
                // if overrideOnNoContent has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }

                // onNoContent - response for 204 /
                if (true == MyInvocation?.BoundParameters?.ContainsKey("PassThru"))
                {
                    WriteObject(true);
                }
            }
        }
    }
}