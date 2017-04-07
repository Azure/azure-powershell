using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public struct UserAgentSettings
    {
        string Product { get; set; }

        string Value { get; set; }

        IDictionary<string, string> Settings { get; }
    }
}
