
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    public class Metadata
    {
        public string Endpoint { get; set; }
        public string CodeSigningAccountName { get; set; }
        public string CertificateProfileName { get; set; }      
        public List<string> ExcludeCredentials { get; set; } = new List<string>();
        public string AccessToken { get; set; }
    }
}
