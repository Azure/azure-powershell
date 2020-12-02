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
using System.Management.Automation;
using System.Runtime.InteropServices;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [CmdletDeprecation(ReplacementCmdletName = "New-AzAksCluster")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Aks")]
    [OutputType(typeof(PSKubernetesCluster))]
    public class NewAzureRmAks : NewKubeBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Create cluster even if it already exists")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate ssh key file to {HOME}/.ssh/id_rsa.")]
        public SwitchParameter GenerateSshKey { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            PreValidate();
            PrepareParameter();

            Action action = () =>
            {
                WriteVerbose(Resources.PreparingForDeploymentOfYourManagedKubernetesCluster);
                var managedCluster = BuildNewCluster();
                var cluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, managedCluster);
                var psObj = PSMapper.Instance.Map<PSKubernetesCluster>(cluster);
                WriteObject(psObj);
            };

            var msg = $"{Name} in {ResourceGroupName}";

            if (Exists())
            {
                WriteVerbose(Resources.ClusterAlreadyExistsConfirmAction);
                ConfirmAction(
                    Force,
                    Resources.DoYouWantToCreateANewManagedKubernetesCluster,
                    Resources.CreatingAManagedKubernetesCluster,
                    msg,
                    action);
            }
            else
            {
                WriteVerbose(Resources.ClusterIsNew);
                if (ShouldProcess(msg, Resources.CreatingAManagedKubernetesCluster))
                {
                    RunCmdLet(action);
                }
            }
        }

        private void PreValidate()
        {
            if ((this.IsParameterBound(c => c.NodeMinCount) || this.IsParameterBound(c => c.NodeMaxCount) || this.EnableNodeAutoScaling.IsPresent) &&
                !(this.IsParameterBound(c => c.NodeMinCount) && this.IsParameterBound(c => c.NodeMaxCount) && this.EnableNodeAutoScaling.IsPresent))
                throw new PSInvalidCastException(Resources.AksNodePoolAutoScalingParametersMustAppearTogether);

            if (this.IsParameterBound(c => c.GenerateSshKey) && this.IsParameterBound(c => c.SshKeyValue))
            {
                throw new ArgumentException(Resources.DonotUseGenerateSshKeyWithSshKeyValue);
            }

            if ((this.IsParameterBound(c => c.WindowsProfileAdminUserName) && !this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)) ||
                (!this.IsParameterBound(c => c.WindowsProfileAdminUserName) && this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)))
            {
                throw new ArgumentException(Resources.WindowsUserNameAndPasswordShouldAppearTogether);
            }

            if (this.IsParameterBound(c => c.WindowsProfileAdminUserName))
            {
                if (!string.Equals(this.NetworkPlugin, "azure"))
                {
                    throw new ArgumentException(Resources.NetworkPluginShouldBeAzure);
                }
            }
        }

        private void VerifySshKeyGenBinaryExist()
        {
            using (Process process = new Process())
            {
                if ((RuntimeInformation.IsOSPlatform(OSPlatform.Windows)))
                {
                    process.StartInfo.FileName = "where.exe";
                }
                else
                {
                    process.StartInfo.FileName = "whereis";
                }
                process.StartInfo.Arguments = "ssh-keygen";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();
                process.WaitForExit();

                string result = process.StandardOutput.ReadLine();
                if (result.Contains("not found") || result.Contains("Could not find") || result.Trim().Equals("ssh-keygen:"))
                {
                    throw new ArgumentException(Resources.EnableSsh);
                }

                if (process.ExitCode != 0)
                {
                    throw new ArgumentException(Resources.EnableSsh);
                }
            }
        }

        private string GenerateSshKeyValue()
        {
            VerifySshKeyGenBinaryExist();
            String generateSshKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "id_rsa"); ;
            if (File.Exists(generateSshKeyPath))
            {
                throw new ArgumentException(string.Format(Resources.DefaultSshKeyAlreadyExist));
            }
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "ssh-keygen";
                process.StartInfo.Arguments = String.Format("-f \"{0}\"", generateSshKeyPath);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                Console.WriteLine(process.StandardOutput.ReadToEnd());

                process.WaitForExit();
            }
            return GetSshKey(generateSshKeyPath);
        }

        protected void PrepareParameter()
        {
            if (this.IsParameterBound(c => c.GenerateSshKey))
            {
                SshKeyValue = GenerateSshKeyValue();
            }
        }
    }
}
