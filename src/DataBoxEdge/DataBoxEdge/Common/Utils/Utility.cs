using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Utils
{
    class Utility
    {
        public static bool IsOneOf<T>(T value, params T[] items)
        {
            return items.Contains(value);
        }
    }
}