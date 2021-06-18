
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Adds or removes schedule tag in an existing backup policy.
.Description
Adds or removes schedule tag in an existing backup policy.
.Example
PS C:\> $criteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
PS C:\> Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -Criteria $criteria

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
.Example
PS C:\> Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -RemoveRule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CRITERIA <IScheduleBasedBackupCriteria[]>: Criterias to be associated with the schedule tag.
  ObjectType <String>: Type of the specific object - used for deserializing
  [AbsoluteCriterion <AbsoluteMarker[]>]: it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"         and should be part of AbsoluteMarker enum
  [DaysOfMonth <IDay[]>]: This is day of the month from 1 to 28 other wise last of month
    [Date <Int32?>]: Date of the month
    [IsLast <Boolean?>]: Whether Date is last date of month
  [DaysOfTheWeek <DayOfWeek[]>]: It should be Sunday/Monday/T..../Saturday
  [MonthsOfYear <Month[]>]: It should be January/February/....../December
  [ScheduleTime <DateTime[]>]: List of schedule times for backup
  [WeeksOfTheMonth <WeekNumber[]>]: It should be First/Second/Third/Fourth/Last

POLICY <IBackupPolicy>: Backup Policy Object.
  DatasourceType <String[]>: Type of datasource for the backup management
  ObjectType <String>: 
  PolicyRule <IBasePolicyRule[]>: Policy rule dictionary that contains rules for each backuptype i.e Full/Incremental/Logs etc
    Name <String>: 
    ObjectType <String>: 
    DataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
    DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
    TriggerObjectType <String>: Type of the specific object - used for deserializing
    Lifecycle <ISourceLifeCycle[]>: 
      DeleteAfterDuration <String>: Duration of deletion after given timespan
      DeleteAfterObjectType <String>: Type of the specific object - used for deserializing
      SourceDataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
      SourceDataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
      [TargetDataStoreCopySetting <ITargetCopySetting[]>]: 
        CopyAfterObjectType <String>: Type of the specific object - used for deserializing
        DataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
        DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
    [BackupParameterObjectType <String>]: Type of the specific object - used for deserializing
    [IsDefault <Boolean?>]: 
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicytagclientobject
#>
function Edit-AzDataProtectionPolicyTagClientObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy])]
[CmdletBinding(DefaultParameterSetName='RemoveTag', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy]
    # Backup Policy Object.
    # To construct, see NOTES section for POLICY properties and create a hash table.
    ${Policy},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.TagName]
    # Name of the Schedule tag.
    ${Name},

    [Parameter(ParameterSetName='RemoveTag', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specify whether to remove the tag from the given policy object.
    ${RemoveRule},

    [Parameter(ParameterSetName='updateTag', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IScheduleBasedBackupCriteria[]]
    # Criterias to be associated with the schedule tag.
    # To construct, see NOTES section for CRITERIA properties and create a hash table.
    ${Criteria}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            RemoveTag = 'Az.DataProtection.custom\Edit-AzDataProtectionPolicyTagClientObject';
            updateTag = 'Az.DataProtection.custom\Edit-AzDataProtectionPolicyTagClientObject';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
