using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public interface ICacheable
    {
        bool ShouldCache();
        bool IsExpired();
    }
}
