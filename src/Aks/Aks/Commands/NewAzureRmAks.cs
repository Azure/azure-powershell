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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Rest;
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
            HelpMessage = "Generate ssh key file to folder {HOME}/.ssh/ using pre-installed ssh-keygen.")]
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
                try
                {
                    var cluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, managedCluster);
                    var psObj = PSMapper.Instance.Map<PSKubernetesCluster>(cluster);
                    WriteObject(psObj);
                }
                catch (ValidationException e)
                {
                    var sdkApiParameterMap = new Dictionary<string, CmdletParameterNameValuePair>()
                    {
                        { Constants.DotNetApiParameterResourceGroupName, new CmdletParameterNameValuePair(nameof(ResourceGroupName), ResourceGroupName) },
                        { Constants.DotNetApiParameterResourceName, new CmdletParameterNameValuePair(nameof(Name), Name) },
                        { "Name", new CmdletParameterNameValuePair(nameof(NodeName), managedCluster.AgentPoolProfiles.FirstOrDefault()?.Name) },
                    };

                    if (!HandleValidationException(e, sdkApiParameterMap))
                    {
                        throw;
                    }
                }
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
            {
                throw new AzPSArgumentException(
                  Resources.AksNodePoolAutoScalingParametersMustAppearTogether,
                  nameof(EnableNodeAutoScaling),
                  desensitizedMessage: Resources.AksNodePoolAutoScalingParametersMustAppearTogether);
            }

            if (this.IsParameterBound(c => c.GenerateSshKey) && this.IsParameterBound(c => c.SshKeyValue))
            {
                throw new AzPSArgumentException(Resources.DonotUseGenerateSshKeyWithSshKeyValue,
                    nameof(GenerateSshKey),
                    desensitizedMessage: Resources.DonotUseGenerateSshKeyWithSshKeyValue);
            }

            if ((this.IsParameterBound(c => c.WindowsProfileAdminUserName) && !this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)) ||
                (!this.IsParameterBound(c => c.WindowsProfileAdminUserName) && this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)))
            {
                throw new AzPSArgumentException(
                    Resources.WindowsUserNameAndPasswordShouldAppearTogether,
                    nameof(WindowsProfileAdminUserName),
                    desensitizedMessage: Resources.WindowsUserNameAndPasswordShouldAppearTogether);
            }

            if (this.IsParameterBound(c => c.WindowsProfileAdminUserName))
            {
                if (!string.Equals(this.NetworkPlugin, "azure"))
                {
                    throw new AzPSArgumentException(
                        Resources.NetworkPluginShouldBeAzure,
                        nameof(NetworkPlugin),
                        desensitizedMessage: Resources.NetworkPluginShouldBeAzure);
                }
            }
        }

        private string GenerateSshKeyValue()
        {
            String generateSshKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "id_rsa"); ;
            if (File.Exists(generateSshKeyPath))
            {
                throw new AzPSArgumentException(
                    string.Format(Resources.DefaultSshKeyAlreadyExist, generateSshKeyPath),
                    nameof(GenerateSshKey),
                    desensitizedMessage: string.Format(Resources.DefaultSshKeyAlreadyExist, "*"));
            }
            using (Process process = new Process())
            {
                try
                {
                    process.StartInfo.FileName = "ssh-keygen";
                    process.StartInfo.Arguments = String.Format("-f \"{0}\"", generateSshKeyPath);
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    string errorOutput = null;
                    process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => errorOutput += e.Data);
                    process.Start();

                    string standOutput = process.StandardOutput.ReadToEnd();
                    if (!string.IsNullOrEmpty(standOutput))
                    {
                        WriteDebug(standOutput);
                    }
                    process.WaitForExit();
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        var errorMessage = string.Format(Resources.FailedToGenerateSshKey, errorOutput);
                        throw new AzPSInvalidOperationException(errorMessage, ErrorKind.InternalError);
                    }
                }
                catch(Win32Exception exception)
                {
                    var message = string.Format(Resources.FailedToRunSshKeyGen, exception.Message);
                    throw new AzPSInvalidOperationException(message, ErrorKind.InternalError);
                }
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
