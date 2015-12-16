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
    using System.Runtime.Remoting.Channels;
    using System.Text;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class Probe : NamedConfigurationElement
    {
        internal ApplicationGatewayConfigurationContext ConfigurationContext { get; set; }

        //Values taken from ARR schema
        public const string DefaultHost = "127.0.0.1";
        public const string DefaultPath = "/";
        public const uint MinInterval = 0;
        public const uint DefaultInterval = 30;
        public const uint MaxInterval = 86400;
        public const uint MinTimeout = 1;
        public const uint DefaultTimeout = 30;
        public const uint MaxTimeout = 86400;
        public const uint MinUnhealthyThreshold = 0;
        public const uint DefaultUnhealthyThreshold = 3;
        public const uint MaxUnhealthyThreshold = 20;

        //Protocol used to send probe. Http and Https are valid protocols.
        [DataMember(Order = 3, IsRequired = true)]
        public Protocol Protocol { get; set; }

        //Host name to send probe to.
        [DataMember(Order = 4, IsRequired = true)]
        public string Host { get; set; }

        //Relative path of probe. Valid path starts from '/'
        //Probe is sent to <Protocol>://<host>:<port><path>
        [DataMember(Order = 5, IsRequired = true)]
        public string Path { get; set; }

        //Probe interval in seconds
        //This is the time interval between two consecutive probes
        [DataMember(Order = 6, IsRequired = true)]
        public uint Interval { get; set; }

        //Probe timeout in seconds
        //Probe marked as failed if valid response is not received with this timeout period
        [DataMember(Order = 7, IsRequired = true)]
        public uint Timeout { get; set; }

        //Probe  retry count
        //Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold
        [DataMember(Order = 8, IsRequired = true)]
        public uint UnhealthyThreshold { get; set; }

        public override void Validate()
        {
            if (!string.Equals(this.Protocol.ToString().ToLower(), "http", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid Probe {0} protocol. Only Http is allowed as probe protocol", this.Name));
            }

            if (this.Path[0] != '/')
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid Probe {0} path. Valid path starts from '/'", this.Name));
            }

            if ((this.Interval < MinInterval) || (this.Interval > MaxInterval))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid probe {0} interval. {1} is outside valid interval (seconds) range [0, 86400]", this.Name, this.Interval));
            }

            if ((this.Timeout < MinTimeout) || (this.Timeout > MaxTimeout))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid probe {0} timeout. {1} is outside valid timeout (seconds) range [1, 86400]", this.Name, this.Timeout));
            }

            if ((this.UnhealthyThreshold < MinUnhealthyThreshold) || (this.UnhealthyThreshold > MaxUnhealthyThreshold))
            {
                throw new ApplicationGatewayConfigurationValidationException(
                    string.Format("Invalid probe {0} unhealthy threshold. {1} is outside valid unhealthy threshold range [0, 20]", this.Name, this.UnhealthyThreshold));
            }
        }
    }
}
