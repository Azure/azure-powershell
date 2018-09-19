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

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{

    public class InstanceEndpoint
    {
        public InstanceEndpoint()
        {
            
        }

        public InstanceEndpoint(Management.Compute.Models.InstanceEndpoint endpoint)
        {
            Name = endpoint.Name;
            Vip = endpoint.VirtualIPAddress.ToString();
            PublicPort = endpoint.Port;
            LocalPort = endpoint.LocalPort.GetValueOrDefault(0);
            Protocol = endpoint.Protocol;
            IdleTimeoutInMinutes = endpoint.IdleTimeoutInMinutes;
        }

        public string Name { get; set; }
        public string Vip { get; set; }
        public int PublicPort { get; set; }
        public int LocalPort { get; set; }
        public string Protocol { get; set; }
        public int? IdleTimeoutInMinutes { get; set; } 
    }
}
