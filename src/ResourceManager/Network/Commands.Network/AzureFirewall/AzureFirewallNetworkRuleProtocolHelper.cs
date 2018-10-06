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

using System;
using System.Collections.Generic;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public static class AzureFirewallNetworkRuleProtocolHelper
    {
        private static readonly IDictionary<string, string> SupportedNetworkProtocols = new Dictionary<string, string>
        {
            { MNM.AzureFirewallNetworkRuleProtocol.Any.ToUpper(), MNM.AzureFirewallNetworkRuleProtocol.Any },
            { MNM.AzureFirewallNetworkRuleProtocol.TCP.ToUpper(), MNM.AzureFirewallNetworkRuleProtocol.TCP },
            { MNM.AzureFirewallNetworkRuleProtocol.UDP.ToUpper(), MNM.AzureFirewallNetworkRuleProtocol.UDP },
        };

        internal static string MapUserInputToNetworkProtocol(string protocolType)
        {
            if (protocolType == null)
            {
                throw new ArgumentException("A protocol must be provided", nameof(protocolType));
            }

            var userInputKey = protocolType.ToUpper();
            if (!SupportedNetworkProtocols.ContainsKey(userInputKey))
            {
                throw new ArgumentException(
                    $"Invalid protocol {protocolType}. Accepted values are {string.Join(", ", SupportedNetworkProtocols.Values)}.",
                    nameof(protocolType));
            }

            return SupportedNetworkProtocols[userInputKey];
        }
    }
}
