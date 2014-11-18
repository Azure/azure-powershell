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

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class NetworkAclObject : IEnumerable<NetworkAclRule>
    {
        private int nextId = 0;

        private List<NetworkAclRule> rules;
        public ReadOnlyCollection<NetworkAclRule> Rules
        {
            get
            {
                return this.rules.AsReadOnly();
            }
        }
    
        public NetworkAclObject()
        {
            this.rules = new List<NetworkAclRule>();
        }
        
        public void AddRule(NetworkAclRule rule)
        {
            rule.RuleId = this.nextId;
            this.nextId++;

            this.rules.Add(rule);
        }

        public NetworkAclRule GetRule(int ruleId)
        {
            return this.rules.Find((r) => { return r.RuleId == ruleId; });
        }

        public bool RemoveRule(int ruleId)
        {
            return this.rules.RemoveAll((r) => { return r.RuleId == ruleId; }) > 0;
        }

        public IEnumerator<NetworkAclRule> GetEnumerator()
        {
            return this.rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.rules.GetEnumerator();
        }

        public static implicit operator NetworkAclObject(EndpointAccessControlList other)
        {
            var acl = new NetworkAclObject();

            if (other != null)
            {
                foreach (var rule in other.Rules)
                {
                    acl.AddRule(rule);
                }
            }

            return acl;
        }

        public static implicit operator EndpointAccessControlList(NetworkAclObject other)
        {
            if (other == null
               || other.Rules.Count == 0)
            {
                return null;
            }

            var acl = new EndpointAccessControlList();
            acl.Rules = new Collection<AccessControlListRule>();

            if (other != null)
            {
                foreach (var rule in other.Rules)
                {
                    acl.Rules.Add(rule);
                }
            }

            return acl;
        }
    }
}
