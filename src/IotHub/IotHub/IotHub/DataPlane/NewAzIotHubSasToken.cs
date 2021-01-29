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
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubSasToken", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class NewAzIotHubSasToken : IotHubBaseCmdlet
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

        [Parameter(Mandatory = false, HelpMessage = "Target Device Id.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Target Module Id.")]
        [ValidateNotNullOrEmpty]
        public string ModuleId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Access key name.")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Access key type.")]
        [ValidateNotNullOrEmpty]
        public PSKeyType KeyType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Future expiry (in seconds) of the token to be generated. Default is 3600.")]
        [ValidateNotNullOrEmpty]
        public int Duration { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.IotHubName, Properties.Resources.NewIotHubSasToken))
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

                if (this.IsParameterBound(c => c.ModuleId) && !this.IsParameterBound(c => c.DeviceId))
                {
                    throw new ArgumentException("You are unable to get sas token for module without device information.");
                }

                if (!this.IsParameterBound(c => c.Duration))
                {
                    this.Duration = 3600;
                }

                string resourceUri = string.Empty;
                string keyName = string.Empty;
                string key = string.Empty;

                if (this.IsParameterBound(c => c.DeviceId))
                {
                    IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
                    SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryRead);
                    PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
                    RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

                    if (this.IsParameterBound(c => c.ModuleId))
                    {
                        Module module = registryManager.GetModuleAsync(this.DeviceId, this.ModuleId).GetAwaiter().GetResult();
                        if (module != null)
                        {
                            if (module.Authentication.Type.Equals(AuthenticationType.Sas))
                            {
                                resourceUri = string.Format("{0}/devices/{1}/modules/{2}", iotHubDescription.Properties.HostName, this.DeviceId, this.ModuleId);
                                key = this.KeyType.Equals(PSKeyType.primary) ? module.Authentication.SymmetricKey.PrimaryKey : module.Authentication.SymmetricKey.SecondaryKey;
                            }
                            else
                            {
                                throw new ArgumentException("This module does not support SAS auth.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"The entered module \"{this.ModuleId}\" doesn't exist.");
                        }
                    }
                    else
                    {
                        Device device = registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult();
                        if (device != null)
                        {
                            if (device.Authentication.Type.Equals(AuthenticationType.Sas))
                            {
                                resourceUri = string.Format("{0}/devices/{1}", iotHubDescription.Properties.HostName, this.DeviceId);
                                key = this.KeyType.Equals(PSKeyType.primary) ? device.Authentication.SymmetricKey.PrimaryKey : device.Authentication.SymmetricKey.SecondaryKey;
                            }
                            else
                            {
                                throw new ArgumentException("This device does not support SAS auth.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"The entered device \"{this.DeviceId}\" doesn't exist.");
                        }
                    }
                }
                else
                {
                    if (!this.IsParameterBound(c => c.KeyName))
                    {
                        this.KeyName = "iothubowner";
                    }
                    SharedAccessSignatureAuthorizationRule authPolicy = this.IotHubClient.IotHubResource.GetKeysForKeyName(this.ResourceGroupName, this.IotHubName, this.KeyName);
                    resourceUri = iotHubDescription.Properties.HostName;
                    keyName = authPolicy.KeyName;
                    key = this.KeyType.Equals(PSKeyType.primary) ? authPolicy.PrimaryKey : authPolicy.SecondaryKey;
                }

                this.WriteObject(this.createToken(resourceUri, keyName, key, this.Duration));
            }
        }

        private string createToken(string resourceUri, string keyName, string key, int duration)
        {
            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + duration);
            string stringToSign = WebUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(key));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}", WebUtility.UrlEncode(resourceUri), WebUtility.UrlEncode(signature), expiry);
            if (!string.IsNullOrEmpty(keyName))
            {
                sasToken += String.Format(CultureInfo.InvariantCulture, "&skn={0}", keyName);
            }
            return sasToken;
        }
    }
}
