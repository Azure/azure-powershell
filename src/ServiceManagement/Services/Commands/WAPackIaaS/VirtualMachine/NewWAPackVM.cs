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
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    [Cmdlet(VerbsCommon.New, "WAPackVM", DefaultParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate)]
    public class NewWAPackVM : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine Name.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine Name.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateVMFromOSDisks, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "VMTemplate to be used in VM creation.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "VMTemplate to be used in VM creation.")]
        [ValidateNotNullOrEmpty]
        public VMTemplate Template
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "Credentials for Admistrator account for Linux VM")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "Credentials for the localuser for Windows VM.")]
        [ValidateNotNullOrEmpty]
        public PSCredential VMCredential
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "The Vnetwork to which the VirtualMachine should be connected.")]
        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "The Vnetwork to which the VirtualMachine should be connected.")]
        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.CreateVMFromOSDisks, ValueFromPipelineByPropertyName = true, HelpMessage = "The Vnetwork to which the VirtualMachine should be connected.")]
        [ValidateNotNullOrEmpty]
        public VMNetwork VNet
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "ProductKey for the OS used on the template.")]
        [ValidateNotNullOrEmpty]
        public string ProductKey
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateVMFromOSDisks, ValueFromPipelineByPropertyName = true, HelpMessage = "OSDisk(Win 2012, Win 2008 R2, etc) to be used in VM creation.")]
        [ValidateNotNullOrEmpty]
        public VirtualHardDisk OSDisk
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateVMFromOSDisks, ValueFromPipelineByPropertyName = true, HelpMessage = "VMSizeProfile(small, large, etc) to be used in VM creation.")]
        [ValidateNotNullOrEmpty]
        public HardwareProfile VMSizeProfile
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateWindowsVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "Creates a Windows VM.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Windows
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "Creates a Linux VM.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Linux
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.CreateLinuxVMFromTemplate, ValueFromPipelineByPropertyName = true, HelpMessage = "The administrator SSH key for Linux VM.")]
        [ValidateNotNullOrEmpty]
        public string AdministratorSSHKey
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            Utilities.WAPackIaaS.DataContract.VirtualMachine newVirtualMachine = null;
            var virtualMachineOperations = new VirtualMachineOperations(this.WebClientFactory);
            Guid? jobId = Guid.Empty;
            
            var virtualNetworkAdaptersWithVNet = this.CustomizeVnaInput();

            if (this.ParameterSetName == WAPackCmdletParameterSets.CreateWindowsVMFromTemplate)
            {
                newVirtualMachine = new Utilities.WAPackIaaS.DataContract.VirtualMachine()
                {
                    Name = Name,
                    VMTemplateId = Template.ID,
                    LocalAdminUserName = VMCredential.UserName,
                    LocalAdminPassword = ExtractSecureString(VMCredential.Password),
                    NewVirtualNetworkAdapterInput = virtualNetworkAdaptersWithVNet,
                    ProductKey = ProductKey,
                };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.CreateLinuxVMFromTemplate)
            {
                newVirtualMachine = new Utilities.WAPackIaaS.DataContract.VirtualMachine()
                {
                    Name = Name,
                    VMTemplateId = Template.ID,
                    LocalAdminUserName = VMCredential.UserName,
                    LocalAdminPassword = ExtractSecureString(VMCredential.Password),
                    NewVirtualNetworkAdapterInput = virtualNetworkAdaptersWithVNet,
                    LinuxAdministratorSSHKeyString = AdministratorSSHKey
                };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.CreateVMFromOSDisks)
            {
                newVirtualMachine = new Utilities.WAPackIaaS.DataContract.VirtualMachine()
                {
                    Name = Name,
                    HardwareProfileId = VMSizeProfile.ID,
                    VirtualHardDiskId = OSDisk.ID,
                    NewVirtualNetworkAdapterInput = virtualNetworkAdaptersWithVNet
                };
            }

            var createdVirtualMachine = virtualMachineOperations.Create(newVirtualMachine, out jobId);

            if (!jobId.HasValue)
            {
                throw new WAPackOperationException(Resources.CreateFailedErrorMessage);
            }
            WaitForJobCompletion(jobId);

            createdVirtualMachine = virtualMachineOperations.Read(createdVirtualMachine.ID);
            WriteObject(createdVirtualMachine);
        }

        private ObservableCollection<NewVMVirtualNetworkAdapterInput> CustomizeVnaInput()
        {
            if (VNet == null)
            {
                return new ObservableCollection<NewVMVirtualNetworkAdapterInput>();
            }
            else
            {
                if (this.ParameterSetName == WAPackCmdletParameterSets.CreateLinuxVMFromTemplate ||
                    this.ParameterSetName == WAPackCmdletParameterSets.CreateWindowsVMFromTemplate)
                {
                    return CustomizeVnaOnTemplate();
                }
                else if (this.ParameterSetName == WAPackCmdletParameterSets.CreateVMFromOSDisks)
                {
                    var adapterInput = new NewVMVirtualNetworkAdapterInput()
                    {
                        VMNetworkName = VNet.Name
                    };

                    return new ObservableCollection<NewVMVirtualNetworkAdapterInput>(){adapterInput};
                }

                return new ObservableCollection<NewVMVirtualNetworkAdapterInput>();
            }
        }

        private ObservableCollection<NewVMVirtualNetworkAdapterInput> CustomizeVnaOnTemplate()
        {
            var templateOps = new VMTemplateOperations(this.WebClientFactory);
            List<VMTemplate> templateWithVnas = templateOps.Read(new Dictionary<string, string>() { { "ID", this.Template.ID.ToString() } }, "VirtualNetworkAdapters");

            if (templateWithVnas != null && templateWithVnas.Count < 0)
            {
                return new ObservableCollection<NewVMVirtualNetworkAdapterInput>();
            }
            else
            {
                var adapterInputs = new ObservableCollection<NewVMVirtualNetworkAdapterInput>();
                for (var i = 0; i < templateWithVnas[0].VirtualNetworkAdapters.Count; i++)
                {
                    adapterInputs.Add(new NewVMVirtualNetworkAdapterInput());
                }

                adapterInputs[0].VMNetworkName = VNet.Name;

                return adapterInputs;
            }
        }
    }
}
