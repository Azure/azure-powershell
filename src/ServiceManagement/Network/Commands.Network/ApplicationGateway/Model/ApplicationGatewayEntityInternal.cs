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
    using System.Globalization;
    using System.Text;
    using System.Runtime.Serialization;

    /// <summary>
    /// This class represents the Application Gateway internal returned by diagnostics APIs.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayEntityInternal : ApplicationGateway
    {
        [DataMember]
        public string VnetId { get; set; }

        [DataMember]
        public string DeploymentId { get; set; }

        [DataMember]
        public string FabricGeoIdName { get; set; }

        [DataMember]
        public string LocationConstraint { get; set; }

        [DataMember]
        public string GatewayVersion { get; set; }

        [DataMember]
        public string GatewaySubscriptionId { get; set; }

        [DataMember]
        public string SubState { get; set; }

        [DataMember]
        public string DeploymentName { get; set; }

        [DataMember]
        public string SslCertificates { get; set; }

        [DataMember]
        public string Config { get; set; }

        [DataMember]
        public string ConfigTimestamp { get; set; }

        //Constructs partially populated ApplicationGatewayEntityInternal 
        //object from ApplicationGateway object
        public ApplicationGatewayEntityInternal(ApplicationGateway appGw)
        {
            Name = appGw.Name;
            Description = appGw.Description;
            VnetName = appGw.VnetName;
            Subnets = appGw.Subnets;
            InstanceCount = appGw.InstanceCount;
            GatewaySize = appGw.GatewaySize;
            State = appGw.State;
            VirtualIPs = appGw.VirtualIPs;
            DnsName = appGw.DnsName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat(CultureInfo.InvariantCulture, "VnetId:{0} ", string.IsNullOrEmpty(VnetId) ? "null" : VnetId);
            sb.AppendFormat(CultureInfo.InvariantCulture, "DeploymentId:{0} ", string.IsNullOrEmpty(DeploymentId) ? "null" : DeploymentId);
            sb.AppendFormat(CultureInfo.InvariantCulture, "FabricGeoIdName:{0} ", string.IsNullOrEmpty(FabricGeoIdName) ? "null" : FabricGeoIdName);
            sb.AppendFormat(CultureInfo.InvariantCulture, "LocationConstraint:{0} ", string.IsNullOrEmpty(LocationConstraint) ? "null" : LocationConstraint);
            sb.AppendFormat(CultureInfo.InvariantCulture, "GatewayVersion:{0} ", string.IsNullOrEmpty(GatewayVersion) ? "null" : GatewayVersion);
            sb.AppendFormat(CultureInfo.InvariantCulture, "GatewaySubscriptionId:{0} ", string.IsNullOrEmpty(GatewaySubscriptionId) ? "null" : GatewaySubscriptionId);
            sb.AppendFormat(CultureInfo.InvariantCulture, "SubState:{0} ", string.IsNullOrEmpty(SubState) ? "null" : SubState);
            sb.AppendFormat(CultureInfo.InvariantCulture, "DeploymentName:{0} ", string.IsNullOrEmpty(DeploymentName) ? "null" : DeploymentName);
            sb.AppendFormat(CultureInfo.InvariantCulture, "SslCertificates:{0} ", string.IsNullOrEmpty(SslCertificates) ? "null" : SslCertificates);
            sb.AppendFormat(CultureInfo.InvariantCulture, "Config:{0} ", string.IsNullOrEmpty(Config) ? "null" : Config);
            sb.AppendFormat(CultureInfo.InvariantCulture, "ConfigTimestamp:{0} ", string.IsNullOrEmpty(ConfigTimestamp) ? "null" : ConfigTimestamp);

            return sb.ToString();
        }

        public static void ShowDetails(ApplicationGatewayEntityInternal applicationGateway)
        {
            ApplicationGateway.ShowDetails(applicationGateway);

            Console.WriteLine("VnetId:{0}", applicationGateway.VnetId);
            Console.WriteLine("DeploymentId:{0}", applicationGateway.DeploymentId);
            Console.WriteLine("FabricGeoIdName:{0}", applicationGateway.FabricGeoIdName);
            Console.WriteLine("LocationConstraint:{0}", applicationGateway.LocationConstraint);
            Console.WriteLine("GatewayVersion:{0}", applicationGateway.GatewayVersion);
            Console.WriteLine("GatewaySubscriptionId:{0}", applicationGateway.GatewaySubscriptionId);
            Console.WriteLine("SubState:{0}", applicationGateway.SubState);
            Console.WriteLine("DeploymentName:{0}", applicationGateway.DeploymentName);
            Console.WriteLine("SslCertificates:{0}", applicationGateway.SslCertificates);
            Console.WriteLine("Config:{0}", applicationGateway.Config);
            Console.WriteLine("ConfigTimestamp:{0}", applicationGateway.ConfigTimestamp);
        }
    }
}
