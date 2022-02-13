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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubModuleConnectionString", DefaultParameterSetName = ResourceParameterSet)]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubMCS")]
    [OutputType(typeof(PSModuleConnectionString))]
    public class GetAzIotHubModuleConnectionString : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Target Device Id.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Target Module Id.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Target Module Id.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Target Module Id.")]
        [ValidateNotNullOrEmpty]
        public string ModuleId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Shared access policy key type for auth.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Shared access policy key type for auth.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Shared access policy key type for auth.")]
        public PSKeyType KeyType { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.IotHubName = this.InputObject.Name;
                iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                    this.IotHubName = IotHubUtils.GetIotHubName(this.ResourceId);
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.IotHubName);
            }

            IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
            SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryRead);
            PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);
            Device device = registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult();
            if (device != null)
            {
                List<Module> modules = registryManager.GetModulesOnDeviceAsync(this.DeviceId).GetAwaiter().GetResult().ToList();
                if (this.ModuleId != null)
                {
                    if (modules.Any(m => m.Id.Equals(this.ModuleId)))
                    {
                        this.WriteObject(GetModuleConnectionString(modules.FirstOrDefault(m => m.Id.Equals(this.ModuleId)), iotHubDescription.Properties.HostName));
                    }
                }
                else
                {
                    IList<PSModuleConnectionString> psModuleConnectionStringCollection = new List<PSModuleConnectionString>();
                    foreach (Module module in modules)
                    {
                        psModuleConnectionStringCollection.Add(GetModuleConnectionString(module, iotHubDescription.Properties.HostName));
                    }

                    this.WriteObject(psModuleConnectionStringCollection, true);
                }
            }
        }

        private PSModuleConnectionString GetModuleConnectionString(Module module, string hostName)
        {
            string key;
            switch (module.Authentication.Type)
            {
                case Devices.AuthenticationType.Sas:
                    key = string.Format("SharedAccessKey={0}", this.KeyType.Equals(PSKeyType.primary) ? module.Authentication.SymmetricKey.PrimaryKey : module.Authentication.SymmetricKey.SecondaryKey);
                    break;
                case Devices.AuthenticationType.SelfSigned:
                case Devices.AuthenticationType.CertificateAuthority:
                    key = "x509=true";
                    break;
                default:
                    throw new ArgumentNullException("Unable to get authentication type of device.");
            }

            PSModuleConnectionString psModuleConnectionString = new PSModuleConnectionString
            {
                ModuleId = module.Id,
                ConnectionString = $"HostName={hostName};DeviceId={module.DeviceId};ModuleId={module.Id};{key}"
            };

            return psModuleConnectionString;
        }
    }
}
