
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
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.NetAppFiles.SnapshotPolicy
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesSnapshotPolicy",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesSnapshotPolicy))]
    [Alias("New-AnfSnapshotPolicy")]
    public class NewAzureRmNetAppFilesSnapshotPolicy : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/snapshotPolicies")]
        public string Location { get; set; }

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
            HelpMessage = "The name of the ANF snapshot policy")]
        [ValidateNotNullOrEmpty]
        [Alias("SnapshotPolicyName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/snapshotPolicies",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The property to decide policy is enabled or not")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enabled { get; set; }
        
        [Parameter(
            Mandatory = true,
            HelpMessage = "A hashtable array which represents the hourly Schedule")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesHourlySchedule HourlySchedule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "A hashtable array which represents the daily Schedule")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesDailySchedule DailySchedule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "A hashtable array which represents the montly Schedule")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesWeeklySchedule WeeklySchedule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "A hashtable array which represents the montly Schedule")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesMonthlySchedule MonthlySchedule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Account for the new Snapshot Policy object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                Location = AccountObject.Location;
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }
            Management.NetApp.Models.SnapshotPolicy existingSnapshotPolicy = null;
            try
            {
                existingSnapshotPolicy = AzureNetAppFilesManagementClient.SnapshotPolicies.Get(ResourceGroupName, AccountName, Name);
            }
            catch
            {
                existingSnapshotPolicy = null;
            }
            if (existingSnapshotPolicy != null)
            {
                throw new AzPSResourceNotFoundCloudException($"A Snapshot Policy with name '{this.Name}' in resource group '{this.ResourceGroupName}' already exists. Please use Set/Update-AzNetAppFilesSnapshotPolicy to update an existing Snapshot Policy.");
            }

            var snapshotPolicyBody = new Management.NetApp.Models.SnapshotPolicy()
            {
                Location = Location,
                Enabled = Enabled,
                HourlySchedule = (HourlySchedule != null) ? HourlySchedule.ConvertFromPs() : null,
                DailySchedule = (DailySchedule != null) ? DailySchedule.ConvertFromPs() : null,
                WeeklySchedule = (WeeklySchedule != null) ? WeeklySchedule.ConvertFromPs() : null,
                MonthlySchedule = (MonthlySchedule != null) ? MonthlySchedule.ConvertFromPs() : null                
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                var anfSnapshotPolicy = AzureNetAppFilesManagementClient.SnapshotPolicies.Create(snapshotPolicyBody, ResourceGroupName, AccountName, snapshotPolicyName: Name);
                WriteObject(anfSnapshotPolicy.ConvertToPs());
            }
        }
    }
}
