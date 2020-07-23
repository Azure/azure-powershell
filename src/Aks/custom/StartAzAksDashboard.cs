// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    [Cmdlet("Start", AzureRMConstants.AzureRMPrefix + "AksDashboard")]
    [Description("Create a Kubectl SSH tunnel to the managed cluster's dashboard.")]
    [OutputType(typeof(KubeTunnelJob))]
    public class StartAzAksDashboard : KubeCmdletBase, IEventListener
    {
        private const string ListenAddress = "127.0.0.1";

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

        public AksClient Client => Module.Instance.ClientAPI;

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

        /// <summary>Wait for .NET debugger to attach</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter Break { get; set; }

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

        [Parameter(Mandatory = true,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A IAksIdentity object, normally passed through the pipeline.",
            Position = 0)]
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

        [Parameter(Mandatory = false,
            HelpMessage = "Do not pop open a browser after establishing the kubectl port-forward.")]
        public SwitchParameter DisableBrowser { get; set; }

        [Parameter(Mandatory = false)] public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The listening port for the dashboard. Default value is 8003.")]
        public int ListenPort { get; set; } = 8003;

        public CancellationToken Token => throw new NotImplementedException();

        public Action Cancel => throw new NotImplementedException();

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
                await ((IEventListener) this).Signal(
                    Runtime.Events.CmdletProcessRecordAsyncStart);
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

                    if (!GeneralUtilities.Probe("kubectl"))
                        throw new CmdletInvocationException(Resources
                            .KubectlIsRequriedToBeInstalledAndOnYourPathToExecute);

                    await Client.ManagedClustersGetAccessProfile(SubscriptionId, ResourceGroupName, Name, "clusterUser",
                        onOk, onDefault, this, Pipeline);

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
                    await ((IEventListener) this).Signal(Runtime.Events
                        .CmdletProcessRecordAsyncEnd);
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
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }

                var accessProfile = await response;

                var tmpFileName = Path.GetTempFileName();

                AzureSession.Instance.DataStore.WriteFile(
                    tmpFileName,
                    Encoding.UTF8.GetString(accessProfile.KubeConfig));

                WriteVerbose(string.Format(
                    Resources.RunningKubectlGetPodsKubeconfigNamespaceSelector,
                    tmpFileName));
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "kubectl",
                        Arguments =
                            $"get pods --kubeconfig {tmpFileName} --namespace kube-system --output name --selector k8s-app=kubernetes-dashboard",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                var dashPodName = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                // remove "pods/" or "pod/"
                dashPodName = dashPodName.Substring(dashPodName.IndexOf('/') + 1).TrimEnd('\r', '\n');

                var procDashboardPort = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "kubectl",
                        Arguments =
                            $"get pods --kubeconfig {tmpFileName} --namespace kube-system --selector k8s-app=kubernetes-dashboard --output jsonpath='{{.items[0].spec.containers[0].ports[0].containerPort}}'",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                procDashboardPort.Start();
                var dashboardPortOutput = procDashboardPort.StandardOutput.ReadToEnd();
                procDashboardPort.WaitForExit();

                dashboardPortOutput = dashboardPortOutput.Replace("'", "");
                int dashboardPort = int.Parse(dashboardPortOutput);
                string protocol = dashboardPort == 8443 ? "https" : "http";

                string dashboardUrl = $"{protocol}://{ListenAddress}:{ListenPort}";
                //TODO: check in cloudshell
                //TODO: support for --address {ListenAddress}

                WriteVerbose(string.Format(
                    Resources.RunningInBackgroundJobKubectlTunnel,
                    tmpFileName, dashPodName));

                var exitingJob = JobRepository.Jobs.FirstOrDefault(j => j.Name == "Kubectl-Tunnel");
                if (exitingJob != null)
                {
                    WriteVerbose(Resources.StoppingExistingKubectlTunnelJob);
                    exitingJob.StopJob();
                    JobRepository.Remove(exitingJob);
                }

                var job = new KubeTunnelJob(tmpFileName, dashPodName, ListenPort, dashboardPort);
                if (!DisableBrowser)
                {
                    WriteVerbose(Resources.SettingUpBrowserPop);
                    job.StartJobCompleted += (sender, evt) =>
                    {
                        WriteVerbose(string.Format(Resources.StartingBrowser, dashboardUrl));
                        PopBrowser(dashboardUrl);
                    };
                }

                JobRepository.Add(job);
                job.StartJob();
                WriteObject(job);
            }
        }

        private void PortForwardProc_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PopBrowser(string uri)
        {
            var browserProcess = new Process
            {
                StartInfo = new ProcessStartInfo {Arguments = uri}
            };
            var verboseMessage = Resources.StartingOnDefault;
            // TODO: Remove IfDef
#if NETSTANDARD
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                verboseMessage = "Starting on OSX with open";
                browserProcess.StartInfo.FileName = "open";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                verboseMessage = "Starting on Unix with xdg-open";
                browserProcess.StartInfo.FileName = "xdg-open";
            }
            else
            {
                browserProcess.StartInfo.FileName = "cmd";
                browserProcess.StartInfo.Arguments = $"/c start {uri}";
                browserProcess.StartInfo.CreateNoWindow = true;
            }
#endif

            WriteVerbose(verboseMessage);
            browserProcess.Start();
        }
    }
}