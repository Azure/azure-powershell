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
    using System;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HttpListener : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string FrontendIP { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public string FrontendPort { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public Protocol Protocol { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string SslCert { get; set; }

        public override void Validate()
        {
            if (this.FrontendIP != null && !this.ConfigurationContext.FrontendIPConfigurations.ContainsKey(this.FrontendIP.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("FrontendIPConfiguration: {0} reference does not exist", this.FrontendIP));
            }

            if (!this.ConfigurationContext.FrontendPorts.ContainsKey(this.FrontendPort.ToLower()))
            {
                throw new ApplicationGatewayConfigurationValidationException(string.Format("FrontendPort: {0} reference does not exist", this.FrontendPort));
            }

            if (this.Protocol == Protocol.Https)
            {
                if (String.IsNullOrEmpty(this.SslCert) || String.IsNullOrWhiteSpace(this.SslCert))
                {
                    throw new ApplicationGatewayConfigurationValidationException(string.Format("SSL certificate not specified for listener: {0}", this.Name));
                }                
            }
        }
    }
}