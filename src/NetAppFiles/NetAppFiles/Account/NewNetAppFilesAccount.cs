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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.NetAppFiles.Account
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesAccount",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesAccount))]
    [Alias("New-AnfAccount")]
    public class NewAzureRmNetAppFilesAccount : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the active directories")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesActiveDirectory[] ActiveDirectory { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }
            NetAppAccount existingAccount = null;

            try
            {
                existingAccount = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, Name);
            }
            catch
            {
                existingAccount = null;
            }
            if (existingAccount != null)
            {
                throw new AzPSResourceNotFoundCloudException($"A NetAppAccount with name '{this.Name}' in resource group '{this.ResourceGroupName}' already exists. Only one active directory allowed. Please use Set/Update-AzNetAppFilesAccount to update an existing NetAppAccount.");
            }

            var netAppAccountBody = new NetAppAccount()
            {
                Location = Location,
                ActiveDirectories = (ActiveDirectory != null) ? ActiveDirectory.ConvertFromPs() : null,
                Tags = tagPairs
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                var anfAccount = AzureNetAppFilesManagementClient.Accounts.CreateOrUpdate(netAppAccountBody, ResourceGroupName, Name);
                WriteObject(anfAccount.ToPsNetAppFilesAccount());
            }
        }
    }
}
