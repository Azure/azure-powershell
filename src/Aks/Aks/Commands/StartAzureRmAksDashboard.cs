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

<<<<<<< HEAD
using System;
using System.ComponentModel;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
<<<<<<< HEAD
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
=======

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksDashboard", DefaultParameterSetName = GroupNameParameterSet)]
    [OutputType(typeof(KubeTunnelJob))]
    public class StartAzureRmAksDashboard : KubeCmdletBase
    {
<<<<<<< HEAD

        private const string IdParameterSet = "IdParameterSet";
        private const string GroupNameParameterSet = "GroupNameParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ProxyUrl = "http://127.0.0.1:8001";
=======
        private const string IdParameterSet = "IdParameterSet";
        private const string GroupNameParameterSet = "GroupNameParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ListenAddress = "127.0.0.1";
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a


        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.",
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster InputObject { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = GroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
<<<<<<< HEAD
            HelpMessage = "Do not pop open a browser after establising the kubectl port-forward.")]
        public SwitchParameter DisableBrowser { get; set; }

=======
            HelpMessage = "Do not pop open a browser after establishing the kubectl port-forward.")]
        public SwitchParameter DisableBrowser { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The listening port for the dashboard. Default value is 8003.")]
        public int ListenPort { get; set; } = 8003;

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case IdParameterSet:
                    {
                        var resource = new ResourceIdentifier(Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        Name = resource.ResourceName;
                        break;
                    }
                case InputObjectParameterSet:
                    {
                        var resource = new ResourceIdentifier(InputObject.Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        Name = resource.ResourceName;
                        break;
                    }
            }

            RunCmdLet(() =>
            {
                if (!GeneralUtilities.Probe("kubectl"))
<<<<<<< HEAD
                    throw new CmdletInvocationException(Resources.KubectlIsRequriedToBeInstalledAndOnYourPathToExecute);

                var tmpFileName = Path.GetTempFileName();
                var encoded = Client.ManagedClusters.GetAccessProfiles(ResourceGroupName, Name, "clusterUser")
                    .KubeConfig;
                AzureSession.Instance.DataStore.WriteFile(
                    tmpFileName,
                    Encoding.UTF8.GetString(Convert.FromBase64String(encoded)));
=======
                    throw new AzPSApplicationException(Resources.KubectlIsRequriedToBeInstalledAndOnYourPathToExecute);

                var tmpFileName = Path.GetTempFileName();
                var credentials = Client.ManagedClusters.ListClusterAdminCredentials(ResourceGroupName, Name).Kubeconfigs;
                var encoded = credentials.First(credential => credential.Name.Equals("clusterUser")).Value;
                AzureSession.Instance.DataStore.WriteFile(
                    tmpFileName,
                    Encoding.UTF8.GetString(encoded));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                WriteVerbose(string.Format(
                    Resources.RunningKubectlGetPodsKubeconfigNamespaceSelector,
                    tmpFileName));
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "kubectl",
                        Arguments = $"get pods --kubeconfig {tmpFileName} --namespace kube-system --output name --selector k8s-app=kubernetes-dashboard",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                var dashPodName = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

<<<<<<< HEAD
                // remove "pods/"
                dashPodName = dashPodName.Substring(5).TrimEnd('\r', '\n');
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
                var job = new KubeTunnelJob(tmpFileName, dashPodName);
=======
                var job = new KubeTunnelJob(tmpFileName, dashPodName, ListenPort, dashboardPort);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                if (!DisableBrowser)
                {
                    WriteVerbose(Resources.SettingUpBrowserPop);
                    job.StartJobCompleted += (sender, evt) =>
                    {
<<<<<<< HEAD
                        WriteVerbose(string.Format(Resources.StartingBrowser, ProxyUrl));
                        PopBrowser(ProxyUrl);
=======
                        WriteVerbose(string.Format(Resources.StartingBrowser, dashboardUrl));
                        PopBrowser(dashboardUrl);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    };
                }

                JobRepository.Add(job);
                job.StartJob();
                WriteObject(job);
            });
        }

        private void PopBrowser(string uri)
        {
            var browserProcess = new Process
            {
                StartInfo = new ProcessStartInfo { Arguments = uri }
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
<<<<<<< HEAD
=======
            else
            {
                browserProcess.StartInfo.FileName = "cmd";
                browserProcess.StartInfo.Arguments = $"/c start {uri}";
                browserProcess.StartInfo.CreateNoWindow = true;
            }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
#endif

            WriteVerbose(verboseMessage);
            browserProcess.Start();
        }
    }

<<<<<<< HEAD
    public class KubeTunnelJob : Job2
    {
        private readonly string _credFilePath;
        private int _pid;
        private readonly string _dashPod;
        private string _statusMsg = "Initializing";

        public KubeTunnelJob(string credFilePath, string dashPod) : base("Start-AzKubernetesDashboard",
            "Kubectl-Tunnel")
        {
            _credFilePath = credFilePath;
            _dashPod = dashPod;
        }

        public override string StatusMessage => _statusMsg;
        public override bool HasMoreData { get; }
        public override string Location { get; }

        public int Pid => _pid;

        public override void StopJob()
        {
            _statusMsg = string.Format(Resources.StoppingProcessWithId, _pid);
            SetJobState(JobState.Stopping);
            try
            {
                Process.GetProcessById(_pid).Kill();
            }
            catch (Exception)
            {
                _statusMsg = Resources.PidDoesntExistOrJobIsAlreadyDead;
            }
            SetJobState(JobState.Stopped);
            _statusMsg = string.Format(Resources.StoppedProcesWithId, _pid);
            OnStopJobCompleted(new AsyncCompletedEventArgs(null, false, _statusMsg));
        }

        public override void StartJob()
        {
            var kubectlCmd = $"--kubeconfig {_credFilePath} --namespace kube-system port-forward {_dashPod} 8001:9090";
            _statusMsg = string.Format(Resources.StartingKubectl, kubectlCmd);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "kubectl",
                    Arguments = kubectlCmd,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            TestMockSupport.Delay(1500);
            _pid = process.Id;
            SetJobState(JobState.Running);
            _statusMsg = string.Format(Resources.StartedKubectl, kubectlCmd);
            OnStartJobCompleted(new AsyncCompletedEventArgs(null, false, string.Format(Resources.ProcessStartedWithId, _pid)));
        }

        public override void StartJobAsync()
        {
            StartJob();
        }

        public override void StopJobAsync()
        {
            StopJob();
        }

        public override void SuspendJob()
        {
            StopJob();
        }

        public override void SuspendJobAsync()
        {
            StopJob();
        }

        public override void ResumeJob()
        {
            StartJob();
        }

        public override void ResumeJobAsync()
        {
            StartJob();
        }

        public override void UnblockJob()
        {
            // noop
        }

        public override void UnblockJobAsync()
        {
            UnblockJob();
        }

        public override void StopJob(bool force, string reason)
        {
            StopJob();
        }

        public override void StopJobAsync(bool force, string reason)
        {
            StopJob();
        }

        public override void SuspendJob(bool force, string reason)
        {
            StopJob();
        }

        public override void SuspendJobAsync(bool force, string reason)
        {
            StopJob();
        }
    }
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
