using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using YamlDotNet.RepresentationModel;
using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    [Cmdlet("Import", AzureRMConstants.AzureRMPrefix + "AksCredential", SupportsShouldProcess = true)]
    [OutputType(typeof(IManagedClusterAccessProfile))]
    [Description(@"Import and merge Kubectl config for a managed Kubernetes Cluster.")]
    public partial class ImportAzAksCredential : KubeCmdletBase, IEventListener
    {
        private const string Clusters = "clusters";
        private const string Users = "users";

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
        ///     Intializes a new instance of the <see cref="ImportAzAksCredential" /> cmdlet class.
        /// </summary>
        public ImportAzAksCredential()
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

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "An IManagedCluseter object, normally passed through the pipeline.")]
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
            ParameterSetName = Constants.NameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = Constants.NameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Import Kubernetes config even if it is the default")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage =
                "A kubectl config file to create or update. Use '-' to print YAML to stdout instead.  Default: %Home%/.kube/config.")]
        public string ConfigPath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Get the 'clusterAdmin' kubectl config instead of the default 'clusterUser'.")]
        public SwitchParameter Admin { get; set; } = false;

        [Parameter(Mandatory = false)] public SwitchParameter PassThru { get; set; }

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
                        var data = messageData();
                        WriteInformation(data, new[] {data.Message});
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
        ///     <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what
        ///     happens
        ///     on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a
        ///     <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedClusterAccessProfile" /> from the
        ///     remote call
        /// </param>
        /// <param name="returnNow">
        ///     /// Determines if the rest of the onOk method should be processed, or if the method should return
        ///     immediately (set to true to skip further processing )
        /// </param>
        partial void overrideOnOk(HttpResponseMessage responseMessage, Task<IManagedClusterAccessProfile> response,
            ref Task<bool> returnNow);

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
                if (ShouldProcess($"Call remote 'ManagedClustersGetAccessProfile' operation"))
                {
                    using (var asyncCommandRuntime = new AsyncCommandRuntime(this, ((IEventListener) this).Token))
                    {
                        asyncCommandRuntime.Wait(ProcessRecordAsync(), ((IEventListener) this).Token);
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

                    // get the client instance
                    await ConfirmActionAsync(Force.IsPresent,
                        Resources.DoYouWantToImportTheKubernetesConfig,
                        Resources.ImportingKubernetesConfigResource,
                        string.Format(Resources.KubernetesCredentialAction, Name, ResourceGroupName),
                        async () =>
                        {
                            if (string.IsNullOrEmpty(ConfigPath))
                            {
                                ConfigPath = Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                                    ".kube",
                                    "config");
                                WriteVerbose(
                                    string.Format(Resources.FileWasNotSpecifiedWritingCredentialTo, ConfigPath));
                            }

                            WriteVerbose(Admin
                                ? Resources.FetchingTheClusterAdminKubectlConfig
                                : Resources.FetchingTheDefaultClusterUserKubectlConfig);
                            await Client.ManagedClustersGetAccessProfile(SubscriptionId, ResourceGroupName, Name,
                                Admin ? "clusterAdmin" : "clusterUser", onOk, onDefault, this, Pipeline);
                        });

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
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name,
                            Admin = Admin
                        })
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
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, ResourceName = Name,
                            Admin = Admin
                        })
                    {
                        ErrorDetails = new ErrorDetails(ex.Message) {RecommendedAction = ex.Action}
                    });
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception($"[{code}] : {message}"), code?.ToString(),
                        ErrorCategory.InvalidOperation,
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, ResourceName = Name,
                            Admin = Admin
                        })
                    {
                        ErrorDetails = new ErrorDetails(message) {RecommendedAction = string.Empty}
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a
        ///     <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedClusterAccessProfile" /> from the
        ///     remote call
        /// </param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is
        ///     completed.
        /// </returns>
        private async Task onOk(HttpResponseMessage responseMessage, Task<IManagedClusterAccessProfile> response)
        {
            using (NoSynchronizationContext)
            {
                var _returnNow = Task.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }
                // onOk - response for 200 / application/json

                var accessProfile = await response;

                var decodedKubeConfig =
                    Encoding.UTF8.GetString(accessProfile.KubeConfig);
                if (ConfigPath == "-")
                {
                    WriteObject(decodedKubeConfig);
                }
                else
                {
                    MergeAndWriteKubeConfig(decodedKubeConfig);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }

        public void MergeAndWriteKubeConfig(string config)
        {
            var dir = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(ConfigPath))
            {
                WriteVerbose(string.Format(Resources.NoConfigFileLocatedAtCreatingKubeConfig, ConfigPath));
                File.WriteAllText(ConfigPath, config);
            }
            else
            {
                var mergedConfig = MergeKubeConfig(File.ReadAllText(ConfigPath), config);
                File.WriteAllText(ConfigPath, mergedConfig);
            }
        }

        public static string MergeKubeConfig(string original, string additions)
        {
            var originalYaml = new YamlStream();
            originalYaml.Load(new StringReader(original));
            var newConfigYaml = new YamlStream();
            newConfigYaml.Load(new StringReader(additions));
            var originalMapping = (YamlMappingNode) originalYaml.Documents[0].RootNode;
            var newMapping = (YamlMappingNode) newConfigYaml.Documents[0].RootNode;

            // clusters
            var mergedClusters = MergeNamedItems(originalMapping, newMapping, Clusters);
            originalMapping.Children.Remove(new YamlScalarNode(Clusters));
            originalMapping.Children.Add(new YamlScalarNode(Clusters), mergedClusters);

            // users
            var mergedUsers = MergeNamedItems(originalMapping, newMapping, Users);
            originalMapping.Children.Remove(new YamlScalarNode(Users));
            originalMapping.Children.Add(new YamlScalarNode(Users), mergedUsers);

            // contexts
            var mergedContexts = MergeNamedItems(originalMapping, newMapping, "contexts");
            originalMapping.Children.Remove(new YamlScalarNode("contexts"));
            originalMapping.Children.Add(new YamlScalarNode("contexts"), mergedContexts);

            // override the current context
            originalMapping.Children.Remove(new YamlScalarNode("current-context"));
            originalMapping.Children.Add(new YamlScalarNode("current-context"),
                newMapping.Children[new YamlScalarNode("current-context")]);

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            originalYaml.Save(sw, false);
            return sb.ToString();
        }

        private static YamlSequenceNode MergeNamedItems(YamlMappingNode original, YamlMappingNode addition, string key)
        {
            var origNamedItems = (YamlSequenceNode) original[new YamlScalarNode(key)];
            var newNamedItems = (YamlSequenceNode) addition[new YamlScalarNode(key)];
            var namedItems = new Dictionary<string, YamlMappingNode>();

            origNamedItems
                .Children
                .Cast<YamlMappingNode>()
                .ForEach(x =>
                {
                    var nameNode = (YamlScalarNode) x.Children[new YamlScalarNode("name")];
                    if (!namedItems.ContainsKey(nameNode.Value)) namedItems.Add(nameNode.Value, x);
                });
            newNamedItems
                .Children
                .Cast<YamlMappingNode>()
                .ForEach(x =>
                {
                    var nameNode = (YamlScalarNode) x.Children[new YamlScalarNode("name")];
                    if (!namedItems.ContainsKey(nameNode.Value))
                    {
                        namedItems.Add(nameNode.Value, x);
                    }
                    else
                    {
                        namedItems[nameNode.Value] = x;
                    }
                });
            return new YamlSequenceNode(namedItems.Values);
        }
    }
}