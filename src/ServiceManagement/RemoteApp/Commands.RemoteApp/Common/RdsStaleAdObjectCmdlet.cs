using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    public abstract class RdsStaleAdObjectCmdlet : RdsCmdlet
    {
        public IList<DirectoryEntry> GetVmAdStaleEntries(IList<RemoteAppVm> vmList, ActiveDirectoryConfig adConfig, PSCredential credential)
        {
            
            Dictionary<string, string> vmPrefixes = new Dictionary<string, string>();
            List<DirectoryEntry> staleVmEntries = null;

            foreach (RemoteAppVm vm in vmList)
            {
                string vmNamePrefix = vm.VirtualMachineName.Substring(0, 8);

                // for each VM group with the same 8-character prefix, find the "minimum" VM name.
                // i.g, for VMs "abcdefgh0004", "abcdefgh0002", "abcdefgh0005", "abcdefgh0003" the minimum will be "abcdefgh0002"
                // this will be used later to determine which AD entries are stale
                // because each staleVMName < MIN(existingVMName) using regular case-insensitive alphanumerical comparison
                if (vmPrefixes.ContainsKey(vmNamePrefix))
                {
                    if (String.Compare(vm.VirtualMachineName, vmPrefixes[vmNamePrefix], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        vmPrefixes[vmNamePrefix] = vm.VirtualMachineName;
                    }
                }
                else
                {
                    vmPrefixes.Add(vmNamePrefix, vm.VirtualMachineName);
                }
            }

            staleVmEntries = new List<DirectoryEntry>();

            foreach (string vmNamePrefix in vmPrefixes.Keys)
            {
                IList<DirectoryEntry> adEntries = ActiveDirectoryHelper.GetVmAdEntries(
                    adConfig.DomainName,
                    adConfig.OrganizationalUnit,
                    vmNamePrefix,
                    credential);

                string maxName = vmPrefixes[vmNamePrefix];

                foreach (DirectoryEntry adEntry in adEntries)
                {
                    string name = ActiveDirectoryHelper.GetCN(adEntry);

                    if ((name.Length == AdHelper.VMNameLength) && (String.Compare(name, maxName, StringComparison.OrdinalIgnoreCase) < 0))
                    {
                        staleVmEntries.Add(adEntry);
                    }
                }
            }

            return staleVmEntries;
        }

    }
}
