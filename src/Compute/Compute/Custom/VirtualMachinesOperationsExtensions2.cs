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
        public static async Task<VirtualMachine> CreateOrUpdateV2Async(this IVirtualMachinesOperations operations, string resourceGroupName, string vmName, VirtualMachine parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, vmName, parameters, customHeaders, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
