//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network.Models
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Text.RegularExpressions;

    public class PSAzureFirewallThreatIntelWhitelist
    {
        private string[] fqdns;

        private string[] ipAddresses;

        public string[] FQDNs
        {
            get { return this.fqdns; }
            set
            {
                ValidateFqdns(value);
                fqdns = value;
            }
        }

        public string[] IpAddresses
        {
            get { return this.ipAddresses; }
            set
            {
                ValidateIpAddresses(value);
                ipAddresses = value;
            }
        }

        private const string SecureGatewayThreatIntelFqdnRegex = "^\\*?([a-zA-Z0-9\\-\\.]?[a-zA-Z0-9])*$";

        private void ValidateFqdns(string[] fqdns)
        {
            if (fqdns == null)
                return;

            var matchingRegEx = new Regex(SecureGatewayThreatIntelFqdnRegex);
            foreach (var fqdn in fqdns)
            {
                if (!matchingRegEx.IsMatch(fqdn))
                {
                    throw new PSArgumentException(String.Format("\'{0}\' is not a valid threat intel whitelist FQDN", fqdn));
                }
            }
        }

        private void ValidateIpAddresses(string[] ipAddresses)
        {
            if (ipAddresses == null)
                return;

            foreach (var ip in ipAddresses)
            {
                IPAddress ipVal;
                if (!IPAddress.TryParse(ip, out ipVal) || ipVal.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    throw new PSArgumentException(String.Format("\'{0}\' is not a valid threat intel whitelist Ip Address", ip));
                }
            }
        }
    }
}
