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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HttpLoadBalancingRule : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public string Type;

        [DataMember(Order = 3, IsRequired = true)]
        public string BackendHttpSettings;

        [DataMember(Order = 4, IsRequired = true)]
        public string Listener { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        public string BackendAddressPool { get; set; }

        public override void Validate()
        {
            if (!this.ConfigurationContext.BackendHttpSettingsList.ContainsKey(this.BackendHttpSettings.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("BackendHttpSettings: {0} reference does not exist", this.BackendHttpSettings));
            }

            if (!this.ConfigurationContext.HttpListeners.ContainsKey(this.Listener.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("HttpListener: {0} reference does not exist", this.Listener));
            }

            if (!this.ConfigurationContext.BackendAddressPools.ContainsKey(this.BackendAddressPool.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("BackendAddressPool: {0} reference does not exist", this.BackendAddressPool));
            }
        }
    }
}
