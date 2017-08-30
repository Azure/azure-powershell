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

using System.Collections;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerInstance.Models;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// New-AzureRmContainerGroup
    /// </summary>
    [Cmdlet(VerbsCommon.New, ContainerGroupNoun), OutputType(typeof(PSContainerGroup))]
    public class NewAzureContainerGroupCommand : ContainerInstanceCmdletBase
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The container group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "The container image.")]
        [ValidateNotNullOrEmpty]
        public string Image { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container group Location. Default to the location of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container OS type. Default: Linux")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            OperatingSystemTypes.Linux,
            OperatingSystemTypes.Windows,
            IgnoreCase = true)]
        public string OsType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The required CPU cores. Default: 1")]
        [ValidateNotNullOrEmpty]
        public double? Cpu { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The required memory in GB. Default: 1.5")]
        [ValidateNotNullOrEmpty]
        public double? Memory { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP address type.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "Public",
            IgnoreCase = true)]
        public string IpAddressType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The port to open.")]
        [ValidateNotNullOrEmpty]
        public int? Port { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The command to run in the container. e.g. @(\"executable\",\"param1\",\"param2\")")]
        [ValidateNotNullOrEmpty]
        public string[] Command { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container environment variables.")]
        [ValidateNotNullOrEmpty]
        public Hashtable EnvrionmentVariables { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The custom container registry login server.")]
        [ValidateNotNullOrEmpty]
        public string RegistryServer { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The custom container registry username.")]
        [ValidateNotNullOrEmpty]
        public string RegistryUsername { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The custom container registry password.")]
        [ValidateNotNullOrEmpty]
        public SecureString RegistryPassword { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, "Create Container Group"))
            {
                var creationParameter = new ContainerGroupCreationParameters()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location ?? this.GetResourceGroupLocation(this.ResourceGroupName),
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true),
                    OsType = this.OsType ?? ContainerGroupCreationParameters.DefaultOsType,
                    IpAddressType = this.IpAddressType,
                    Port = this.Port ?? ContainerGroupCreationParameters.DefaultPort,
                    ContainerImage = this.Image,
                    ContainerCommand = this.Command,
                    EnvironmentVariables = this.ConvertHashtableToDictionary(this.EnvrionmentVariables),
                    Cpu = this.Cpu ?? ContainerGroupCreationParameters.DefaultCpu,
                    MemoryInGb = this.Memory ?? ContainerGroupCreationParameters.DefaultMemory,
                    RegistryServer = this.RegistryServer,
                    RegistryUsername = this.RegistryUsername,
                    RegistryPassword = ContainerGroupCreationParameters.ConvertToString(this.RegistryPassword)
                };

                creationParameter.Validate();

                var psContainerGroup = PSContainerGroup.FromContainerGroup(
                    this.CreateContainerGroup(creationParameter));

                this.WriteObject(psContainerGroup);
            }
        }
    }
}
