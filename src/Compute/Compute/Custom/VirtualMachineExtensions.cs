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
        private static string ifMatchProperty = null;
        private static string ifNoneMatchProperty = null;

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

        public static void SetIfMatchIfNoneMatch(this VirtualMachine vm, string ifMatch, string ifNoneMatch)
        {
            ifMatchProperty = ifMatch;
            ifNoneMatchProperty = ifNoneMatch;
        }
        public static Tuple<string,string> GetIfMatchIfNoneMatch(this VirtualMachine vm)
        {
            return Tuple.Create(ifMatchProperty, ifNoneMatchProperty);    
        }

        public static void RemoveIfMatchIfNoneMatch(this VirtualMachine vm)
        {
            ifMatchProperty = null;
            ifNoneMatchProperty = null;
        }

    }
}
