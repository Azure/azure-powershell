using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public enum PSLockMode
    {
        None = 0,
        AllResourcesReadOnly = 1,
        AllResourcesDoNotDelete = 2
    }
}
