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

using Microsoft.Azure.Management.Search.Models;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSIpRule
    {
        public string Value { get; set; }

        public static implicit operator PSIpRule(IpRule ipRule)
        {
            return new PSIpRule()
            {
                Value = ipRule.Value
            };
        }

        public static implicit operator IpRule(PSIpRule ipRule)
        {
            return new IpRule(value: ipRule.Value);
        }

        public static implicit operator PSIpRule(string ipRule)
        {
            return new PSIpRule()
            {
                Value = ipRule
            };
        }

        public override string ToString()
        {
            return Value;
        }
    }
}