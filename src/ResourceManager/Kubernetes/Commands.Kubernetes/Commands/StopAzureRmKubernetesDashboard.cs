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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kubernetes.Properties;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet("Stop", KubeNounStr + "Dashboard")]
    public class StopAzureRmKubernetesDashboard : KubeCmdletBase
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var exitingJob = JobRepository.Jobs.FirstOrDefault(j => j.Name == "Kubectl-Tunnel") as KubeTunnelJob;
                if (exitingJob != null)
                {
                    WriteVerbose(string.Format(Resources.StoppingExistingKubectlTunnelJobWithPid, exitingJob.Pid));
                    exitingJob.StopJob();
                    JobRepository.Remove(exitingJob);
                }
                else
                {
                    WriteVerbose(Resources.DidNotFindJob);
                }

                if (PassThru)
                {
                    WriteObject(true);
                }
            });
        }
    }
}