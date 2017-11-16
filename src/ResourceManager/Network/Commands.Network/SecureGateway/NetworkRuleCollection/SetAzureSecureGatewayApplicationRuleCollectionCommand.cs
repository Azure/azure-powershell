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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    using System.Linq;

    [Cmdlet(VerbsCommon.Set, "AzureRmSecureGatewayNetworkRuleCollection"), OutputType(typeof(PSSecureGateway))]
    public class SetAzureSecureGatewayNetworkRuleCollectionCommand : AzureSecureGatewayNetworkRuleCollectionBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecureGateway")]
        public PSSecureGateway SecureGateway { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.Rules == null || this.Rules.Count == 0)
            {
                throw new ArgumentException("At least one network rule should be specified!");
            }

            // Verify if the networkRuleCollection exists in the SecureGateway
            var networkRuleCollection = this.SecureGateway.NetworkRuleCollections.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (networkRuleCollection == null)
            {
                throw new ArgumentException("Network rule collection with the specified name does not exist");
            }

            networkRuleCollection.Name = this.Name;
            networkRuleCollection.Rules = this.Rules;
            WriteObject(this.SecureGateway);
        }
    }
}
