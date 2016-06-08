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
    public class FrontendIPConfiguration: NamedConfigurationElement
    {
        internal  ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        public static readonly string Type_Private = "Private";

        [DataMember(Order = 2, IsRequired = true)]
        public string Type { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string StaticIPAddress { get; set; }

        public override void Validate()
        {
            if (!string.Equals(this.Type.ToString(), Type_Private, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Only 'Private' is allowed as Type of FrontendIPConfiguration {0}", this.Name));
            }
        }
    }
}
