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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class BackendHttpSettings : NamedConfigurationElement
    {
        internal ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        //Values taken from ARR schemas
        public const uint MinRequestTimeout = 1;
        public const uint DefaultRequestTimeout = 30;
        public const uint MaxRequestTimeout = 86400;

        private uint _requestTimeout;

        [DataMember(Order = 2, IsRequired = true)]
        public ushort Port { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public Protocol Protocol { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public string CookieBasedAffinity { get; set; }

        //ReuestTimeout in seconds
        //ARR will fail the request if response not received within RequestTimeout
        [DataMember(Order = 5, IsRequired = false)]
        public uint RequestTimeout
        {
            get
            {
                if (0 == _requestTimeout)
                    return DefaultRequestTimeout;
                else
                    return _requestTimeout;
            }
            set
            {
                _requestTimeout = value;
            }
        }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public string Probe { get; set; }

        public BackendHttpSettings()
        {
            RequestTimeout = DefaultRequestTimeout;
        }
        public override void Validate()
        {
            if (!string.Equals(this.Protocol.ToString(), "Http", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Only Http is allowed as Protocol of BackendHttpSettings {0}", this.Name));
            }

            if (this.Port == 443)
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("443 is not allowed as Port of BackendHttpSettings {0}", this.Name));
            }

            if (!string.Equals(this.CookieBasedAffinity, "Enabled", StringComparison.InvariantCultureIgnoreCase) &&
                !string.Equals(this.CookieBasedAffinity, "Disabled", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid value for CookieBasedAffinity in BackendHttpSettings {0}. Allowed values:[Enabled/Disabled]", this.Name));
            }

            if ((this.RequestTimeout < MinRequestTimeout) || (this.RequestTimeout > MaxRequestTimeout))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid BackendHttpSettings {0} RequestTimeout. {1} is outside valid RequestTimeout (seconds) range [1, 86400]", this.Name, this.RequestTimeout));
            }
        }

        public bool IsCookieBasedAffinityEnabled()
        {
            return string.Equals(this.CookieBasedAffinity, "Enabled", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
