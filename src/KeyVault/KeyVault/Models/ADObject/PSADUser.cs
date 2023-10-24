using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models.ADObject
{
    internal class PSADUser : PSADObject
    {
        public string UserPrincipalName { get; set; }

        public string ObjectType => "User";

        public string UsageLocation { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public bool? AccountEnabled { get; set; }

        public string MailNickname { get; set; }

        public string Mail { get; set; }

        public string ImmutableId { get; set; }
    }
}
