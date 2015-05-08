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
    using System.Globalization;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the application gateway parameters.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class UpdateApplicationGatewayParameters
    {
        /// <summary>
        /// Gateway Description.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// The vnet to which the gateway belongs.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string VnetName { get; set; }

        /// <summary>
        /// Subnets in the vnet to which the gateway belongs.
        /// </summary>
        [DataMember(IsRequired = false)]
        public SubnetCollection Subnets { get; set; }

        /// <summary>
        /// The number of instances to create for this gateway
        /// </summary>
        [DataMember(IsRequired = false)]
        public uint InstanceCount { get; set; }

        /// <summary>
        /// The size of each gateway instance.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string GatewaySize { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(CultureInfo.InvariantCulture, "Description:{0};", string.IsNullOrEmpty(Description) ? "null" : Description);

            sb.AppendFormat(CultureInfo.InvariantCulture, "VnetName:{0};", string.IsNullOrEmpty(VnetName) ? "null" : VnetName);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Subnets:");
            if (null != Subnets)
            {
                foreach (var subnet in Subnets)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, " {0},", subnet);
                }
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, "InstanceCount:{0};", InstanceCount);
            sb.AppendFormat(CultureInfo.InvariantCulture, "GatewaySize:{0}", string.IsNullOrEmpty(GatewaySize) ? "null" : GatewaySize);

            return sb.ToString();
        }
    }
}
