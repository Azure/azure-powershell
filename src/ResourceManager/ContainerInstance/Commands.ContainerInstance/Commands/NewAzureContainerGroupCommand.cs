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
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerInstance.Models;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// New-AzureRmContainerGroup
    /// </summary>
    [Cmdlet(VerbsCommon.New, ContainerGroupNoun, SupportsShouldProcess = true), OutputType(typeof(PSContainerGroup))]
    public class NewAzureContainerGroupCommand : ContainerInstanceCmdletBase
    {
        protected const string CreateContainerGroupBaseParamSet = "CreateContainerGroupBaseParamSet";
        protected const string CreateContainerGroupWithRegistryParamSet = "CreateContainerGroupWithRegistryParamSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = CreateContainerGroupBaseParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = CreateContainerGroupWithRegistryParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = CreateContainerGroupBaseParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The container group name.")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = CreateContainerGroupWithRegistryParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The container group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupBaseParamSet,
            HelpMessage = "The container image.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithRegistryParamSet,
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
        [ValidateRange(1, 16)]
        public int? Cpu { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The required memory in GB. Default: 1.5")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, 64)]
        [Alias("Memory")]
        public double? MemoryInGB { get; set; }

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
            HelpMessage = "The port to open. Default: 80")]
        [ValidateNotNullOrEmpty]
        public int? Port { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The command to run in the container.")]
        [ValidateNotNullOrEmpty]
        public string Command { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container environment variables.")]
        [ValidateNotNullOrEmpty]
        public Hashtable EnvironmentVariable { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CreateContainerGroupWithRegistryParamSet,
            HelpMessage = "The custom container registry login server.")]
        [ValidateNotNullOrEmpty]
        [Alias("RegistryServer")]
        public string RegistryServerDomain { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithRegistryParamSet,
            HelpMessage = "The custom container registry credential.")]
        [ValidateNotNullOrEmpty]
        public PSCredential RegistryCredential { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        protected override void ExecuteCmdletInternal()
        {
            if (this.ShouldProcess(this.Name, "Create Container Group"))
            {
                var creationParameter = new ContainerGroupCreationParameters()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location ?? this.GetResourceGroupLocation(this.ResourceGroupName),
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                    OsType = this.OsType ?? ContainerGroupCreationParameters.DefaultOsType,
                    IpAddressType = this.IpAddressType,
                    Port = this.Port ?? ContainerGroupCreationParameters.DefaultPort,
                    ContainerImage = this.Image,
                    EnvironmentVariables = this.ConvertHashtableToDictionary(this.EnvironmentVariable),
                    Cpu = this.Cpu ?? ContainerGroupCreationParameters.DefaultCpu,
                    MemoryInGb = this.MemoryInGB ?? ContainerGroupCreationParameters.DefaultMemory,
                    RegistryServer = this.RegistryServerDomain,
                    RegistryUsername = this.RegistryCredential?.UserName,
                    RegistryPassword = ContainerGroupCreationParameters.ConvertToString(this.RegistryCredential?.Password)
                };

                if (!string.IsNullOrWhiteSpace(this.Command))
                {
                    var commandTokens = PSParser.Tokenize(this.Command, out Collection<PSParseError> errors);
                    if (errors.Any())
                    {
                        throw new ArgumentException($"Invalid 'Command' parameter: {string.Join("; ", errors.Select(err => err.Message))}");
                    }
                    creationParameter.ContainerCommand = commandTokens.Select(token => token.Content).ToList();
                }

                creationParameter.Validate();

                var psContainerGroup = PSContainerGroup.FromContainerGroup(
                    this.CreateContainerGroup(creationParameter));

                this.WriteObject(psContainerGroup);
            }
        }
    }
}
