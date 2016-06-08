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
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    /// <summary>
    /// Updates a persistent VM object with a provisioning configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureProvisioningConfig", DefaultParameterSetName = WindowsParameterSetName), OutputType(typeof(IPersistentVM))]
    public class AddAzureProvisioningConfigCommand : ProvisioningConfigurationCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Virtual Machine to update.")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public IPersistentVM VM
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "To disable IaaS provision guest agent.")]
        public SwitchParameter DisableGuestAgent
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            var role = VM.GetInstance();
            var configSetbuilder = new ConfigurationSetsBuilder(role.ConfigurationSets);
            if (Linux.IsPresent)
            {
                role.NoSSHEndpoint = NoSSHEndpoint.IsPresent;

                if (!string.IsNullOrEmpty(this.LinuxUser))
                {
                    SetProvisioningConfiguration(configSetbuilder.LinuxConfigurationBuilder.Provisioning);
                    configSetbuilder.LinuxConfigurationBuilder.Provisioning.HostName = role.RoleName;
                }

                if (!(DisableSSH.IsPresent || NoSSHEndpoint.IsPresent))
                {
                    configSetbuilder.NetworkConfigurationBuilder.AddSshEndpoint();
                }
            }
            else
            {
                role.NoRDPEndpoint = NoRDPEndpoint.IsPresent;

                if (!string.IsNullOrEmpty(this.AdminUsername))
                {
                    SetProvisioningConfiguration(configSetbuilder.WindowsConfigurationBuilder.Provisioning);
                    configSetbuilder.WindowsConfigurationBuilder.Provisioning.ComputerName = role.RoleName;
                }

                if (!NoRDPEndpoint.IsPresent)
                {
                    configSetbuilder.NetworkConfigurationBuilder.AddRdpEndpoint();
                }

                if (!this.DisableWinRMHttps.IsPresent)
                {
                    var builder = new WinRmConfigurationBuilder();
                    if (this.EnableWinRMHttp.IsPresent)
                    {
                        builder.AddHttpListener();
                    }
                    builder.AddHttpsListener(this.WinRMCertificate);

                    if (!string.IsNullOrEmpty(AdminUsername))
                    {
                        configSetbuilder.WindowsConfigurationBuilder.Provisioning.WinRM = builder.Configuration;
                    }
    
                    if(!this.NoWinRMEndpoint.IsPresent)
                    {
                        configSetbuilder.NetworkConfigurationBuilder.AddWinRmEndpoint();
                    }
                    role.WinRMCertificate = WinRMCertificate;
                }

                role.X509Certificates = new List<X509Certificate2>();
                if (this.X509Certificates != null)
                {
                    role.X509Certificates.AddRange(this.X509Certificates);
                }

                role.NoExportPrivateKey = this.NoExportPrivateKey.IsPresent;
                role.ProvisionGuestAgent = !DisableGuestAgent.IsPresent;

                role.ResourceExtensionReferences = this.DisableGuestAgent.IsPresent ? null :
                    new VirtualMachineExtensionImageFactory(this.ComputeClient).MakeList(
                            VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultPublisher,
                            VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultName,
                            VirtualMachineBGInfoExtensionCmdletBase.ExtensionDefaultVersion);
            }

            WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected void ValidateParameters()
        {
            var vm = (PersistentVM)this.VM;
            
            ValidateLinuxParameterSetParameters(vm);
            ValidateWindowsParameterSetParameters(vm);
        }

        private void ValidateLinuxParameterSetParameters(PersistentVM vm)
        {
            if (LinuxParameterSetName.Equals(ParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                if (!this.NoSSHPassword && ValidationHelpers.IsLinuxPasswordValid(Password) == false)
                {
                    throw new ArgumentException(Resources.PasswordNotComplexEnough);
                }

                if (ValidationHelpers.IsLinuxHostNameValid(vm.RoleName) == false)
                {
                    throw new ArgumentException(Resources.InvalidHostName);
                }
            }
        }

        private void ValidateWindowsParameterSetParameters(PersistentVM vm)
        {
            if (WindowsParameterSetName.Equals(ParameterSetName, StringComparison.OrdinalIgnoreCase) || 
                WindowsDomainParameterSetName.Equals(ParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                if (ValidationHelpers.IsWindowsPasswordValid(Password) == false)
                {
                    throw new ArgumentException(Resources.PasswordNotComplexEnough);
                }

                if (ValidationHelpers.IsWindowsComputerNameValid(vm.RoleName) == false)
                {
                    throw new ArgumentException(Resources.InvalidComputerName);
                }
            }
        }
    }
}
