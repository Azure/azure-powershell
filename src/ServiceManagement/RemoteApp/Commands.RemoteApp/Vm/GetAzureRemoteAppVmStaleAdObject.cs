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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Management.Automation;
using System.DirectoryServices;
using System;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppVmStaleAdObject"), OutputType(typeof(string))]
    public class GetAzureRemoteAppVmStaleAdObject : RdsStaleAdObjectCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Credential with permission to query computers in Active Directory")]
        public PSCredential Credential { get; set; }

        public override void ExecuteCmdlet()
        {
            CollectionVmsListResult vmList = null;
            ActiveDirectoryConfigResult adConfig = null;

            adConfig = CallClient(() => Client.Collections.GetAd(CollectionName), Client.Collections);
            vmList = CallClient(() => Client.Collections.ListVms(CollectionName), Client.Collections);

            if (vmList != null && vmList.Vms != null)
            {
                IList<DirectoryEntry> staleEntries = GetVmAdStaleEntries(vmList.Vms, adConfig.ActiveDirectoryConfig, Credential);
                foreach(DirectoryEntry staleEntry in staleEntries)
                {
                    WriteObject(ActiveDirectoryHelper.GetCN(staleEntry));
                }
            }
        }
    }
}
