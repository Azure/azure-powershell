using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Compute.Models
{
    static class VirtualMachineExtensions
    {
        private static IDictionary<VirtualMachine, Dictionary<string, List<string>>> mapping = new ConcurrentDictionary<VirtualMachine, Dictionary<string, List<string>>>();

        public static void SetAuxAuthHeader(this VirtualMachine vm, Dictionary<string, List<string>> auxAuthHeader)
        {
            mapping.Add(vm, auxAuthHeader);
        }

        public static Dictionary<string, List<string>> GetAuxAuthHeader(this VirtualMachine vm)
        {
            Dictionary<string, List<string>> ret;
            mapping.TryGetValue(vm, out ret);
            return ret;
        }

        public static void RemoveAuxAuthHeader(this VirtualMachine vm)
        {
            mapping.Remove(vm);
        }

    }
}
