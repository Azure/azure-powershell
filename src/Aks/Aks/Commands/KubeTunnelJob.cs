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
using System.ComponentModel;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    public class KubeTunnelJob : Job2
    {
        private readonly string _credFilePath;
        private int _pid;
        private readonly string _dashPod;
        private readonly int _listen_port;
        private readonly int _dashboard_port;
        private string _statusMsg = "Initializing";

        public KubeTunnelJob(string credFilePath, string dashPod, int listenPort, int dashboardPort) : base("Start-AzKubernetesDashboard",
            "Kubectl-Tunnel")
        {
            _credFilePath = credFilePath;
            _dashPod = dashPod;
            _listen_port = listenPort;
            _dashboard_port = dashboardPort;
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
            var kubectlCmd = $"--kubeconfig {_credFilePath} --namespace kube-system port-forward {_dashPod} {_listen_port}:{_dashboard_port}";
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
}
