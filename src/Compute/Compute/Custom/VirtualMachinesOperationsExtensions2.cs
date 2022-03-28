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
        public static async Task<VirtualMachineWrapper> CreateOrUpdateWithCustomHeaderAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, VirtualMachineWrapper virtualMachineWrapper, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, vmName, virtualMachineWrapper.VirtualMachine, virtualMachineWrapper.CustomHeaders, cancellationToken).ConfigureAwait(false))
            {
                var ret = new VirtualMachineWrapper();
                ret.VirtualMachine = _result.Body;
                return ret;
            }
        }

        public static async Task<VirtualMachineWrapper> GetVMWrapperAsync(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, InstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, vmName, expand, null, cancellationToken).ConfigureAwait(false))
            {
                var ret = new VirtualMachineWrapper();
                ret.VirtualMachine = _result.Body;
                return ret;
            }
        }
    }
}
