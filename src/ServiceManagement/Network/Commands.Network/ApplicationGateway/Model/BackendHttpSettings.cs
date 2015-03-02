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

using System.Runtime.Remoting.Channels;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class BackendHttpSettings : NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public ushort Port { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public Protocol Protocol { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public string CookieBasedAffinity { get; set; }

        public override void Validate()
        {
            if (!string.Equals(this.Protocol.ToString(), "Http", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Only Http is allowed as Protocol of BackendHttpSettings {0}", this.Name));
            }

            if (!string.Equals(this.CookieBasedAffinity, "Enabled", StringComparison.InvariantCultureIgnoreCase) &&
                !string.Equals(this.CookieBasedAffinity, "Disabled", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid value for CookieBasedAffinity in BackendHttpSettings {0}. Allowed values:[Enabled/Disabled]", this.Name));
            }
        }
    }
}
