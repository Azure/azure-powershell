using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Compute.Models
{
    static class VirtualMachineScaleSetExtensions
    {
        private static IDictionary<VirtualMachineScaleSet, Dictionary<string, List<string>>> mapping = new ConcurrentDictionary<VirtualMachineScaleSet, Dictionary<string, List<string>>>();

        public static void SetAuxAuthHeader(this VirtualMachineScaleSet vmss, Dictionary<string, List<string>> auxAuthHeader)
        {
            mapping.Add(vmss, auxAuthHeader);
        }

        public static Dictionary<string, List<string>> GetAuxAuthHeader(this VirtualMachineScaleSet vmss)
        {
            Dictionary<string, List<string>> ret;
            mapping.TryGetValue(vmss, out ret);
            return ret;
        }

        public static void RemoveAuxAuthHeader(this VirtualMachineScaleSet vmss)
        {
            mapping.Remove(vmss);
        }

    }
}
