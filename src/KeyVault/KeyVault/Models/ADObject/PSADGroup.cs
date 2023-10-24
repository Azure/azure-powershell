using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models.ADObject
{
    internal class PSADGroup : PSADObject
    {
        public bool? SecurityEnabled { get; set; }

        public bool? MailEnabled { get; set; }

        public string MailNickname { get; set; }

        public string ObjectType => "Group";

        public string Description { get; set; }
    }
}
