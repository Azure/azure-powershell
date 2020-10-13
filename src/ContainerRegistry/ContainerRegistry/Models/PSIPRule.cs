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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSIPRule : IPSNetworkRule
    {
        public PSIPRule(string iPAddressOrRange, string action = default(string))
        {
            Action = action;
            IPAddressOrRange = iPAddressOrRange;
            Validate();
        }

        public PSIPRule(IPRule rule)
        {
            Action = rule.Action;
            IPAddressOrRange = rule.IPAddressOrRange;
            Validate();
        }

        public string Action { get; set; }

        public string NetworkRuleType
        {
            get { return "IPRule"; }
        }

        public string IPAddressOrRange { get; set; }

        public void Validate()
        {
            if (this.IPAddressOrRange == null)
            {
                throw new PSArgumentNullException("IPAddressOrRange of IPRule cannot be null");
            }
        }

        public IPRule GetIPRule()
        {
            return new IPRule { 
                Action = this.Action,
                IPAddressOrRange = this.IPAddressOrRange
            };
        }
    }
}
