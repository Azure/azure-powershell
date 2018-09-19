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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class NetworkAclRule
    {
        public int RuleId { get; set; }
        public int Order { get; set; }
        public string Action { get; set; }
        public string RemoteSubnet { get; set; }
        public string Description { get; set; }

        public NetworkAclRule()
        {
            this.RuleId = -1;
            this.Order = 0;
            this.Action = string.Empty;
            this.RemoteSubnet = string.Empty;
            this.Description = string.Empty;
        }

        public override string ToString()
        {
            return this.Description ?? string.Format("{0} {1}", this.Action, this.RemoteSubnet);
        }

        public static implicit operator NetworkAclRule(AccessControlListRule o)
        {
            return new NetworkAclRule() {
                Order = o.Order ?? 0,
                Action = o.Action,
                RemoteSubnet = o.RemoteSubnet,
                Description = o.Description };
        }

        public static implicit operator AccessControlListRule(NetworkAclRule o)
        {
            return new AccessControlListRule() {
                Order = o.Order,
                Action = o.Action,
                RemoteSubnet = o.RemoteSubnet,
                Description = o.Description }; 
        }
    }
}
