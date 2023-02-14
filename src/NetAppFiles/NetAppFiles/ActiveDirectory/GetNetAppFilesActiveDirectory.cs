
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
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesActiveDirectory",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesActiveDirectory))]
    [Alias("Get-AnfActicedirectory")]
    public class GetAzureRmNetAppFilesActiceDirectory : AzureNetAppFilesCmdletBase
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
            Mandatory = false,
            HelpMessage = "The ActiveDirectoryId of the ANF Active Directory")]
        [ValidateNotNullOrEmpty]
        [Alias("ActiveDirectoryName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/activedirectory",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string ActiveDirectoryId { get; set; }


        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Account for the new Active Directory object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }

            if (ActiveDirectoryId != null)
            {
                var anfActiveDirectory = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, AccountName).ActiveDirectories?.FirstOrDefault<Management.NetApp.Models.ActiveDirectory>(e => e.ActiveDirectoryId == ActiveDirectoryId);
                WriteObject(anfActiveDirectory?.ConvertToPs(ResourceGroupName, AccountName));
            }
            else
            {
                var anfActiveDirectories = AzureNetAppFilesManagementClient.Accounts.Get(ResourceGroupName, AccountName).ActiveDirectories?.ConvertToPs(ResourceGroupName, AccountName);
                WriteObject(anfActiveDirectories, true);
            }
        }
    }
}
