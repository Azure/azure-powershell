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

using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSIpRule
    {
        public string Value { get; set; }
        public string Action { get; set; }

        public PSIpRule() { }
        public PSIpRule(IPRule rule)
        {
            Value = rule.Value;
            Action = rule.Action;
        }

        public IPRule ToSdkModel()
        {
            return new IPRule(value: Value, action: Action);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Action) ? Value : $"{Action}:{Value}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj is PSIpRule other)
            {
                return Action.Equals(other.Action, System.StringComparison.OrdinalIgnoreCase) && Value.Equals(other.Value);
            }
            if (obj is IPRule ipRuleModule)
            {
                return Action.Equals(ipRuleModule.Action, System.StringComparison.OrdinalIgnoreCase) && Value.Equals(ipRuleModule.Value);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
