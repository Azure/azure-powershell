
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
Adds or removes Retention Rule to existing Policy
.Description
Adds or removes Retention Rule to existing Policy
.Example
PS C:\> $pol = Get-AzDataProtectionPolicyTemplate
PS C:\> $lifecycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 5
PS C:\> Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $lifecycle -IsDefault $false

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
.Example
PS C:\>  Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -RemoveRule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

LIFECYCLES <ISourceLifeCycle[]>: Life cycles associated with the retention rule.
  DeleteAfterDuration <String>: Duration of deletion after given timespan
  DeleteAfterObjectType <String>: Type of the specific object - used for deserializing
  SourceDataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
  SourceDataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
  [TargetDataStoreCopySetting <ITargetCopySetting[]>]: 
    CopyAfterObjectType <String>: Type of the specific object - used for deserializing
    DataStoreObjectType <String>: Type of Datasource object, used to initialize the right inherited type
    DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive

POLICY <IBackupPolicy>: Backup Policy Object
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
https://docs.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicyretentionruleclientobject
#>
function Edit-AzDataProtectionPolicyRetentionRuleClientObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy])]
[CmdletBinding(DefaultParameterSetName='RemoveRetention', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy]
    # Backup Policy Object
    # To construct, see NOTES section for POLICY properties and create a hash table.
    ${Policy},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName]
    # Retention Rule Name
    ${Name},

    [Parameter(ParameterSetName='RemoveRetention', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether to remove the retention rule.
    ${RemoveRule},

    [Parameter(ParameterSetName='AddRetention', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Boolean]
    # Specifies if retention rule is default retention rule.
    ${IsDefault},

    [Parameter(ParameterSetName='AddRetention', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISourceLifeCycle[]]
    # Life cycles associated with the retention rule.
    # To construct, see NOTES section for LIFECYCLES properties and create a hash table.
    ${LifeCycles}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            RemoveRetention = 'Az.DataProtection.custom\Edit-AzDataProtectionPolicyRetentionRuleClientObject';
            AddRetention = 'Az.DataProtection.custom\Edit-AzDataProtectionPolicyRetentionRuleClientObject';
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
