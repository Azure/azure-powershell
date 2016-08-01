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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using System.Globalization;
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Extension.Chef
{
    [Cmdlet(
        VerbsCommon.Remove, ProfileNouns.VirtualMachineChefExtension, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class RemoveAzureRmVMChefExtension : VirtualMachineExtensionBaseCmdlet
    {
        private string ExtensionDefaultPublisher = "Chef.Bootstrap.WindowsAzure";
        private string ExtensionDefaultName = "ChefClient";
        private string LinuxExtensionName = "LinuxChefClient";

        protected const string LinuxParameterSetName = "Linux";
        protected const string WindowsParameterSetName = "Windows";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Extension Name.")]
        public string Name
        {
            get
            {
                return this.ExtensionDefaultName;
            }
            set
            {
                this.ExtensionDefaultName = value;
            }
        }

        [Parameter(
            Mandatory = true,
            ParameterSetName = LinuxParameterSetName,
            HelpMessage = "Set extension for Linux.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = WindowsParameterSetName,
            HelpMessage = "Set extension for Windows.")]
        public SwitchParameter Windows { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Linux.IsPresent)
            {
                this.Name = LinuxExtensionName;
            }
            else if (this.Windows.IsPresent)
            {
                this.Name = ExtensionDefaultName;
            }

            ConfirmAction("Remove Chef Extension", this.VMName,
                () =>
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        VirtualMachine virtualMachine = ComputeClient.ComputeManagementClient.VirtualMachines.Get(
                            this.ResourceGroupName, this.VMName);
                        var chefExtension = virtualMachine.Resources != null
                                ? virtualMachine.Resources.FirstOrDefault(extension =>
                                    extension.Publisher.Equals(ExtensionDefaultPublisher, StringComparison.InvariantCultureIgnoreCase) &&
                                    extension.VirtualMachineExtensionType.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase))
                                : null;

                        if (chefExtension == null)
                        {
                            WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.ChefExtensionNotFound, this.ResourceGroupName, this.VMName));
                            return;
                        }
                        else
                        {
                            this.Name = chefExtension.Name;
                        }
                    }

                    var op = this.VirtualMachineExtensionClient.DeleteWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VMName,
                        this.Name).GetAwaiter().GetResult();
                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                });
        }
    }
}
