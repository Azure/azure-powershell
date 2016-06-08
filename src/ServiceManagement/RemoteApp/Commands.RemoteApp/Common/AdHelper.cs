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
    class AdHelper : IAdHelper
    {
        internal const int VMNameLength = 12;
        internal const string CN = "cn";

        public IList<DirectoryEntry> GetVmAdEntries(string domainName, string OU, string vmNamePrefix, PSCredential credential)
        {
            // may throw InvalidOperationException and NotSupportedException

            List<DirectoryEntry> results = null;
            string userName = null;
            string password = null;
            DirectoryEntry directoryEntry = null;
            DirectorySearcher directorySearcher = null;
            SearchResultCollection searchResults = null;
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domainName);

            Domain domain = Domain.GetDomain(context);
            DomainController dc = domain.PdcRoleOwner;

            string path = String.Format(
                "LDAP://{0}{1}",
                dc.Name,
                (String.IsNullOrWhiteSpace(OU) ? "" : "/" + OU)
                );


            if ((credential != null) && (credential.UserName != null))
            {
                userName = credential.UserName;
                password = ConvertToUnsecureString(credential.Password);
            }

            directoryEntry = new DirectoryEntry(path, userName, password);
            directorySearcher = new DirectorySearcher(directoryEntry)
            {
                Filter = String.Format("(&(objectClass=computer)(name={0}*))", vmNamePrefix)
            };

            searchResults = directorySearcher.FindAll();

            results = new List<DirectoryEntry>();

            foreach (SearchResult searchResult in searchResults)
            {
                DirectoryEntry entry = searchResult.GetDirectoryEntry();
                results.Add(entry);
            }

            return results;
        }

        protected string ConvertToUnsecureString(SecureString securePassword)
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

        public string GetCN(DirectoryEntry dirEntry)
        {
            return dirEntry.Properties[AdHelper.CN][0].ToString();
        }
        
        public void DeleteEntry(DirectoryEntry dirEntry)
        {
            dirEntry.DeleteTree();
            dirEntry.CommitChanges();
        }
    }
}
