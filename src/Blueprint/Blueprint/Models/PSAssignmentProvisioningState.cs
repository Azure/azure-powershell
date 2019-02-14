using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public enum PSAssignmentProvisioningState
    {
        Unknown = 0,
        Creating = 1,
        Validating = 2,
        Waiting = 3,
        Deploying = 4,
        Cancelling = 5,
        Locking = 6,
        Succeeded = 7,
        Failed = 8,
        Canceled = 9,
        Deleting = 10
    }
}
