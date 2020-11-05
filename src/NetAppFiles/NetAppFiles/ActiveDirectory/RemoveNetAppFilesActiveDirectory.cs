
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
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.ActiveDirectory
{
    [Cmdlet(
        "Remove",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesActiveDirectory",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesActiveDirectory))]
    [Alias("Remove-AnfActiveDirectory")]
    public class RemoveAzureRmNetAppFilesActiveDirectory: AzureNetAppFilesCmdletBase
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
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the ANF active directory",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the ANF active directory",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]        
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/activeDirectory",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string ActiveDirectoryId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Account for the Active Directory object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The active directory object to remove")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesActiveDirectory InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified Active Directory  was successfully removed")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {            
            bool success = false;
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;             
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                AccountName = InputObject.AccountName;
                ActiveDirectoryId = InputObject.ActiveDirectoryId;
            }

            if (ShouldProcess(ActiveDirectoryId, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                var anfAccount = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, AccountName);
                var activeDirectory = anfAccount.ActiveDirectories.FirstOrDefault(a => a.ActiveDirectoryId == ActiveDirectoryId);
                anfAccount.ActiveDirectories.Remove(activeDirectory);
                var updatedAnfAccount = AzureNetAppFilesManagementClient.Accounts.BeginCreateOrUpdate(anfAccount, ResourceGroupName, AccountName);
                success = true;
            }
            if (PassThru)
            {
                WriteObject(success);
            }

        }
    }
}
