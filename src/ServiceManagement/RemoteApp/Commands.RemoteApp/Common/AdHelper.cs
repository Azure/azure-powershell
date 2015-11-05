// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.ActiveDirectory;
using System.Management.Automation;
using System.Security;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    class AdHelper
    {
        internal const int VMNameLength = 12;
        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            string password = null;

            if (securePassword != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                    password = Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }

            return password;
        }

        public static IList<DirectoryEntry> GetVmAdEntries(string domainName, string OU, string vmNamePrefix, string maxName, PSCredential credential)
        {
            // may throw InvalidOperationException and NotSupportedException

            List<DirectoryEntry> results = null;

            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domainName);

            Domain domain = Domain.GetDomain(context);
            DomainController dc = domain.PdcRoleOwner;

            string path = String.Format(
                "LDAP://{0}{1}",
                dc.Name,
                (String.IsNullOrWhiteSpace(OU) ? "" : "/" + OU)
                );

            string userName = null;
            string password = null;

            if ((credential != null) && (credential.UserName != null))
            {
                userName = credential.UserName;
                password = ConvertToUnsecureString(credential.Password);
            }

            DirectoryEntry directoryEntry = new DirectoryEntry(path, userName, password);
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                Filter = String.Format("(&(objectClass=computer)(name={0}*))", vmNamePrefix)
            };

            SearchResultCollection searchResults = directorySearcher.FindAll();

            results = new List<DirectoryEntry>();

            foreach (SearchResult searchResult in searchResults)
            {
                string name = searchResult.Properties["cn"][0].ToString();

                if ((name.Length == AdHelper.VMNameLength) && ((maxName == null) || (String.Compare(name, maxName, true) < 0)))
                {
                    DirectoryEntry computerToDel = searchResult.GetDirectoryEntry();
                    results.Add(computerToDel);
                }
            }

            return results;
        }

        public static IList<DirectoryEntry> GetVmAdStaleEntries(IList<RemoteAppVm> vmList, ActiveDirectoryConfig adConfig, PSCredential credential)
        {
            Dictionary<string, string> vmPrefixes = new Dictionary<string, string>();
            foreach (RemoteAppVm vm in vmList)
            {
                string vmNamePrefix = vm.VirtualMachineName.Substring(0, 8);
                if (vmPrefixes.ContainsKey(vmNamePrefix))
                {
                    if (String.Compare(vm.VirtualMachineName, vmPrefixes[vmNamePrefix], true) < 0)
                    {
                        vmPrefixes[vmNamePrefix] = vm.VirtualMachineName;
                    }
                }
                else
                {
                    vmPrefixes.Add(vmNamePrefix, vm.VirtualMachineName);
                }
            }

            List<DirectoryEntry> staleVmEntries = new List<DirectoryEntry>();

            foreach (string vmNamePrefix in vmPrefixes.Keys)
            {
                IList<DirectoryEntry> adEntries = AdHelper.GetVmAdEntries(
                    adConfig.DomainName,
                    adConfig.OrganizationalUnit,
                    vmNamePrefix,
                    vmPrefixes[vmNamePrefix],
                    credential);

                foreach (DirectoryEntry adEntry in adEntries)
                {
                    staleVmEntries.Add(adEntry);
                }
            }

            return staleVmEntries;
        }

    }
}
