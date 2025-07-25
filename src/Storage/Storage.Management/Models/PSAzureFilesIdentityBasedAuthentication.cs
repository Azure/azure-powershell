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

using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSAzureFilesIdentityBasedAuthentication
    {
        public PSAzureFilesIdentityBasedAuthentication(AzureFilesIdentityBasedAuthentication auth)
        {
            if (auth != null)
            {
                this.DirectoryServiceOptions = auth.DirectoryServiceOptions;
                this.ActiveDirectoryProperties = auth.ActiveDirectoryProperties != null ? new PSActiveDirectoryProperties(auth.ActiveDirectoryProperties) : null;
                this.DefaultSharePermission = auth.DefaultSharePermission;
            }
        }
        // Gets or sets indicates the directory service used. Possible values include: 'None','AADDS', 'AD'
        public string DirectoryServiceOptions { get; set; }
        public PSActiveDirectoryProperties ActiveDirectoryProperties { get; set; }
        public string DefaultSharePermission { get; set; }
    }

    public class PSActiveDirectoryProperties
    {
        public PSActiveDirectoryProperties(ActiveDirectoryProperties properties)
        {
            if (properties != null)
            {
                this.DomainName = properties.DomainName;
                this.NetBiosDomainName = properties.NetBiosDomainName;
                this.ForestName = properties.ForestName;
                this.DomainGuid = properties.DomainGuid;
                this.DomainSid = properties.DomainSid;
                this.AzureStorageSid = properties.AzureStorageSid;
                this.SamAccountName = properties.SamAccountName;
                this.AccountType = properties.AccountType;
            }
        }
        public string DomainName { get; set; }
        public string NetBiosDomainName { get; set; }
        public string ForestName { get; set; }
        public string DomainGuid { get; set; }
        public string DomainSid { get; set; }
        public string AzureStorageSid { get; set; }
        public string SamAccountName { get; set; }
        public string AccountType { get; set; }
    }
}
