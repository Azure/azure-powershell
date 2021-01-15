using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.AzureFirewallPolicy
{
    class AzureFirewallPolicyRuleSourceParameterSets
    {
        public const string SourceAddress = @"SourceAddress";

        public const string SourceIpGroup = @"SourceIpGroup";

        public const string SourceAddressAndTranslatedAddress = @"SourceAddressAndTranslatedAddress";

        public const string SourceAddressAndTranslatedFqdn = @"SourceAddressAndTranslatedFqdn";

        public const string SourceIpGroupAndTranslatedAddress = @"SourceIpGroupAndTranslatedAddress";

        public const string SourceIpGroupAndTranslatedFqdn = @"SourceIpGroupAndTranslatedFqdn";
    }
}
