using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
    public class PSResourceManagerError
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public List<PSResourceManagerError> Details { get; set; }
    }
}