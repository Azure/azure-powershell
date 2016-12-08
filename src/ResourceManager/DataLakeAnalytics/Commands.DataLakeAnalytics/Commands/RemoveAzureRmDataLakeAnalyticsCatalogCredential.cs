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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmDataLakeAnalyticsCatalogCredential", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlCatalogCredential")]
    public class RemoveAzureDataLakeAnalyticsCredential : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The account name that contains the catalog to remove the credential from.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the database to remove the credential from.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage =
                "Name of credential to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "The password for the credential. This is required if the caller is not the owner of the account.")]
        [ValidateNotNull]
        public PSCredential Password { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that this delete operation should go through and also delete and drop all resources dependent on this credential")]
        [ValidateNotNull]
        public SwitchParameter Recurse { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!Recurse)
            {
                ConfirmAction(
                    string.Format(Resources.RemoveDataLakeAnalyticsCatalogCredential, Name),
                    Name,
                    () =>
                    {
                        DataLakeAnalyticsClient.DeleteCredential(
                            Account,
                            DatabaseName,
                            Name,
                            Password != null ? Password.GetNetworkCredential().Password : null);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
            else // in the recursive case there are other objects deleted, so the user must take action
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeAnalyticsCatalogCredentialCascade, Name),
                    string.Format(Resources.RemoveDataLakeAnalyticsCatalogCredentialCascade, Name),
                    Name,
                    () =>
                    {
                        DataLakeAnalyticsClient.DeleteCredential(
                            Account,
                            DatabaseName,
                            Name, Password != null ? Password.GetNetworkCredential().Password : null,
                            Recurse);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
        }
    }
}