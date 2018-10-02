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


namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSIpFilterRuleAttributes
    {
        public PSIpFilterRuleAttributes()
        { }

        public PSIpFilterRuleAttributes(Microsoft.Azure.Management.ServiceBus.Models.IpFilterRule ipfilterRule)
        {
            FilterName = ipfilterRule.FilterName;
            Action = ipfilterRule.Action;
            Name = ipfilterRule.FilterName; ;
            Id = ipfilterRule.Id;
            IpMask = ipfilterRule.IpMask;
        }

        public string Id { get; set; }

        /// <summary>
        /// Gets or sets IP Filter name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets IP Mask
        /// </summary>
        public string IpMask { get; set; }

        /// <summary>
        /// Gets or sets IP Filter name
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// Gets or sets the IP Filter Action. Possible values include:
        /// 'Accept', 'Reject'
        /// </summary>
        public string Action { get; set; }        
    }
}
