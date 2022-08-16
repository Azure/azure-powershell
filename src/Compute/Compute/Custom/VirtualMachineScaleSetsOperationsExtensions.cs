using System;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute
{
    public static partial class VirtualMachineScaleSetsOperationsExtensions
    {
        public static async Task<VirtualMachineScaleSet> CreateOrUpdateWithCustomHeaderAsync(this IVirtualMachineScaleSetsOperations operations, string resourceGroupName, string vmssName, VirtualMachineScaleSet virtualMachineScaleSet, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auxAuthHeader = virtualMachineScaleSet.GetAuxAuthHeader();
            if (auxAuthHeader == null)
            {
                return operations.CreateOrUpdate(resourceGroupName, vmssName, virtualMachineScaleSet);
            }
            virtualMachineScaleSet.RemoveAuxAuthHeader();
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, vmssName, virtualMachineScaleSet, auxAuthHeader, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
