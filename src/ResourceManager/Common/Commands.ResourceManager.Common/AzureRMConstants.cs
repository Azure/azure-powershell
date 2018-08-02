using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRMConstants
    {
#if NETSTANDARD
        public const string AzurePrefix = "";
        public const string AzureRMPrefix = "";
#else
        public const string AzurePrefix = "Azure";
        public const string AzureRMPrefix = "AzureRM";
#endif
    }
}
