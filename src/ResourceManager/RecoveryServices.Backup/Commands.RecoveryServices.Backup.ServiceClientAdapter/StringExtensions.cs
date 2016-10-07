using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            return string.Format("{0}{1}", char.ToLower(str[0]), str.Substring(1));
        }
    }
}
