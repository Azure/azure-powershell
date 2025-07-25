using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute
{
    public static partial class VirtualMachinesOperationsExtensions
    {
        public static async Task<VirtualMachine> CreateOrUpdateWithCustomHeaderAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, VirtualMachine virtualMachine, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auxAuthHeader = virtualMachine.GetAuxAuthHeader();
            var ifMatchResult = virtualMachine.GetIfMatchIfNoneMatch();
            var ifMatch = ifMatchResult.Item1;
            var ifNoneMatch = ifMatchResult.Item2;
            if(auxAuthHeader == null)
            {
                return operations.CreateOrUpdate(resourceGroupName, vmName, virtualMachine, ifMatch, ifNoneMatch);
            }
            virtualMachine.RemoveAuxAuthHeader();
            virtualMachine.RemoveIfMatchIfNoneMatch();
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, vmName, virtualMachine, ifMatch, ifNoneMatch, auxAuthHeader, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
