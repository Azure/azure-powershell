using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication
{
    public class SshCredential : ISshCredential
    {
        public string Credential { get; set; }

        public DateTimeOffset ExpiresOn { get; set; }
    }
}
