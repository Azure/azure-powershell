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
        private static string ifMatchProperty = null;
        private static string ifNoneMatchProperty = null;

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

        public static void SetIfMatchIfNoneMatch(this VirtualMachineScaleSet vmss, string ifMatch, string ifNoneMatch)
        {
            ifMatchProperty = ifMatch;
            ifNoneMatchProperty = ifNoneMatch;
        }
        public static Tuple<string, string> GetIfMatchIfNoneMatch(this VirtualMachineScaleSet vmss)
        {
            return Tuple.Create(ifMatchProperty, ifNoneMatchProperty);
        }

        public static void RemoveIfMatchIfNoneMatch(this VirtualMachineScaleSet vmss)
        {
            ifMatchProperty = null;
            ifNoneMatchProperty = null;
        }

    }
}
