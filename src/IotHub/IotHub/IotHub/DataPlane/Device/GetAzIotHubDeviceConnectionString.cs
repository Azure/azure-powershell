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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Newtonsoft.Json;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeviceConnectionString", DefaultParameterSetName = ResourceParameterSet)]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDCS")]
    [OutputType(typeof(PSDeviceConnectionString))]
    public class GetAzIotHubDeviceConnectionString : IotHubBaseCmdlet
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

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Target Device Id.")]
        public string DeviceId { get; set; }

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
            if (this.DeviceId != null)
            {
                Device device = registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult();
                if (device != null)
                {
                    this.WriteObject(GetDeviceConnectionString(device, iotHubDescription.Properties.HostName));
                }
            }
            else
            {
                IEnumerable<string> deviceResults = registryManager.CreateQuery("Select * from Devices").GetNextAsJsonAsync().GetAwaiter().GetResult();
                IList<PSDeviceConnectionString> psDeviceConnectionStringCollection = new List<PSDeviceConnectionString>();
                foreach (string deviceResult in deviceResults)
                {
                    Device device = registryManager.GetDeviceAsync(JsonConvert.DeserializeObject<Device>(deviceResult).Id).GetAwaiter().GetResult();
                    psDeviceConnectionStringCollection.Add(GetDeviceConnectionString(device, iotHubDescription.Properties.HostName));
                }

                this.WriteObject(psDeviceConnectionStringCollection, true);
            }
        }

        private PSDeviceConnectionString GetDeviceConnectionString(Device device, string hostName)
        {
            string key;
            switch (device.Authentication.Type)
            {
                case AuthenticationType.Sas:
                    key = string.Format("SharedAccessKey={0}", this.KeyType.Equals(PSKeyType.primary) ? device.Authentication.SymmetricKey.PrimaryKey : device.Authentication.SymmetricKey.SecondaryKey);
                    break;
                case AuthenticationType.SelfSigned:
                case AuthenticationType.CertificateAuthority:
                    key = "x509=true";
                    break;
                default:
                    throw new ArgumentNullException("Unable to get authentication type of device.");
            }

            PSDeviceConnectionString psDeviceConnectionString = new PSDeviceConnectionString
            {
                DeviceId = device.Id,
                ConnectionString = $"HostName={hostName};DeviceId={device.Id};{key}"
            };

            return psDeviceConnectionString;
        }
    }
}
