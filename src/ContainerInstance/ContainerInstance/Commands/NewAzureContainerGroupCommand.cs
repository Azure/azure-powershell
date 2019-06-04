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
using System.Management.Automation.Language;
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// New-AzContainerGroup
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerGroup", SupportsShouldProcess = true, DefaultParameterSetName = CreateContainerGroupBaseParamSet)]
    [OutputType(typeof(PSContainerGroup))]
    public class NewAzureContainerGroupCommand : ContainerInstanceCmdletBase
    {
        private const string CreateContainerGroupBaseWithExplicitIdentityParameterSet = "ExplicitIdentityParameterSet";
        protected const string CreateContainerGroupBaseParamSet = "CreateContainerGroupBaseParamSet";
        protected const string CreateContainerGroupWithAzureFileVolumeParamSet = "CreateContainerGroupWithAzureFileMountParamSet";
        protected const string CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet = "CreateContainerGroupWithAzureFileMountAndExplicitIdentityParamSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
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
            Position = 2,
            HelpMessage = "The container image.")]
        [ValidateNotNullOrEmpty]
        public string Image { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The custom container registry credential.")]
        [ValidateNotNullOrEmpty]
        public PSCredential RegistryCredential { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeParamSet,
            HelpMessage = "The name of the Azure File share to mount.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet,
            HelpMessage = "The name of the Azure File share to mount.")]
        [ValidateNotNullOrEmpty]
        public string AzureFileVolumeShareName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeParamSet,
            HelpMessage = "The storage account credential of the Azure File share to mount where the username is the storage account name and the key is the storage account key.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet,
            HelpMessage = "The storage account credential of the Azure File share to mount where the username is the storage account name and the key is the storage account key.")]
        [ValidateNotNullOrEmpty]
        public PSCredential AzureFileVolumeAccountCredential { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeParamSet,
            HelpMessage = "The mount path for the Azure File volume.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet,
            HelpMessage = "The mount path for the Azure File volume.")]
        [ValidateNotNullOrEmpty]
        public string AzureFileVolumeMountPath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container group Location. Default to the location of the resource group.")]
        [LocationCompleter("Microsoft.ContainerInstance/containerGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupBaseWithExplicitIdentityParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The managed identity type")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The managed identity type")]
        [ValidateNotNullOrEmpty]
        public ResourceIdentityType IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CreateContainerGroupBaseWithExplicitIdentityParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The user assigned identity IDs")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeAndExplicitIdentityParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user assigned identity IDs")]
        [ValidateNotNullOrEmpty]
        public string[] IdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CreateContainerGroupBaseParamSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Enable system assigned identity")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CreateContainerGroupWithAzureFileVolumeParamSet,
            HelpMessage = "Enable system assigned identity")]
        public SwitchParameter AssignIdentity { get; set; }

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
            HelpMessage = "The container restart policy. Default: Always")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            ContainerGroupRestartPolicy.Always,
            ContainerGroupRestartPolicy.Never,
            ContainerGroupRestartPolicy.OnFailure,
            IgnoreCase = true)]
        public string RestartPolicy { get; set; }

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
            HelpMessage = "The DNS name label for the IP address.")]
        [ValidateNotNullOrEmpty]
        public string DnsNameLabel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The port(s) to open. Default: [80]")]
        [ValidateNotNullOrEmpty]
        public int[] Port { get; set; }

       [Parameter(
            Mandatory = false,
            HelpMessage = "The command to run in the container.")]
        public string Command { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container environment variables.")]
        [ValidateNotNullOrEmpty]
        public Hashtable EnvironmentVariable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The custom container registry login server.")]
        [ValidateNotNullOrEmpty]
        [Alias("RegistryServer")]
        public string RegistryServerDomain { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "Create Container Group"))
            {
                var creationParameter = new ContainerGroupCreationParameters
                {
                    Name = Name,
                    ResourceGroupName = ResourceGroupName,
                    Location = Location ?? GetResourceGroupLocation(ResourceGroupName),
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                    OsType = OsType ?? ContainerGroupCreationParameters.DefaultOsType,
                    RestartPolicy = RestartPolicy ?? ContainerGroupRestartPolicy.Always,
                    IpAddressType = IpAddressType,
                    DnsNameLabel = DnsNameLabel,
                    Ports = Port ?? ContainerGroupCreationParameters.DefaultPorts,
                    ContainerImage = Image,
                    EnvironmentVariables = ConvertHashtableToDictionary(EnvironmentVariable),
                    Cpu = Cpu ?? ContainerGroupCreationParameters.DefaultCpu,
                    MemoryInGb = MemoryInGB ?? ContainerGroupCreationParameters.DefaultMemory,
                    RegistryServer = RegistryServerDomain,
                    RegistryUsername = RegistryCredential?.UserName,
                    RegistryPassword = ContainerGroupCreationParameters.ConvertToString(RegistryCredential?.Password),
                    AzureFileVolumeShareName = AzureFileVolumeShareName,
                    AzureFileVolumeAccountName = AzureFileVolumeAccountCredential?.UserName,
                    AzureFileVolumeAccountKey = ContainerGroupCreationParameters.ConvertToString(AzureFileVolumeAccountCredential?.Password),
                    AzureFileVolumeMountPath = AzureFileVolumeMountPath,
                    Identity = ParseIdentity()
                };

                if (!string.IsNullOrWhiteSpace(this.Command))
                {
                    ParseError[] errors;
                    Token[] tokens;
                    Parser.ParseInput(this.Command, out tokens, out errors);
                    if (errors.Any())
                    {
                        throw new ArgumentException($"Invalid 'Command' parameter: {string.Join("; ", errors.Select(err => err.Message))}");
                    }
                    creationParameter.ContainerCommand = tokens.Select(token => token.Text.Trim('\'', '"')).Where(token => !string.IsNullOrEmpty(token)).ToList();
                }

                creationParameter.Validate();

                var psContainerGroup = PSContainerGroup.FromContainerGroup(
                    CreateContainerGroup(creationParameter));

                WriteObject(psContainerGroup);
            }
        }

        /// <summary>
        /// Parse the identity
        /// </summary>
        private ContainerGroupIdentity ParseIdentity()
        {
            if (this.AssignIdentity.IsPresent)
            {
                return new ContainerGroupIdentity { Type = ResourceIdentityType.SystemAssigned };
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("IdentityType"))
            {
                var identity = new ContainerGroupIdentity { Type = this.IdentityType };

                if (this.MyInvocation.BoundParameters.ContainsKey("IdentityId"))
                {
                    identity.UserAssignedIdentities = new Dictionary<string, ContainerGroupIdentityUserAssignedIdentitiesValue>();
                    foreach (var id in this.IdentityId)
                    {
                        identity.UserAssignedIdentities.Add(id, new ContainerGroupIdentityUserAssignedIdentitiesValue());
                    }
                }

                return identity;
            }

            return null;
        }
    }
}
