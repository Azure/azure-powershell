
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
Initializes Restore Request object for triggering restore on a protected backup instance.
.Description
Initializes Restore Request object for triggering restore on a protected backup instance.
.Example
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault"
PS C:\> $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault" -BackupInstanceName $instance.Name
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "westus"  -RestoreType AlternateLocation -TargetResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{DiskName}" -RecoveryPoint "892e5c5014dc4a96807d22924f5745c9"
PS C:\> $restoreRequest

ObjectType                                  RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointI
                                                                                                                                                             d
----------                                  --------------------------- ------------------------------- -------------------------------- ------------------- --------------
AzureBackupRecoveryPointBasedRestoreRequest RestoreTargetInfo           FailIfExists                    westus                           OperationalStore    892e5c5014dc4a96807d22924f5745c9
.Example
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instance[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)
PS C:\> $restoreRequest

ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest restoreTargetInfo           FailIfExists                    eastus2euap                      OperationalStore    2021-04-24T13:32:41.7018481Z

.Example
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -ContainersList "containerName1","containerName2"
PS C:\> $restoreRequest

ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest itemLevelRestoreTargetInfo  FailIfExists                    eastus2euap                      OperationalStore    2021-04-23T02:47:02.9500000Z

.Example
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -FromPrefixPattern "container1/aaa","container1/ccc", "container2/aab", "container3" -ToPrefixPattern "container1/bbb","container1/ddd", "container2/abc", "container3-0"
PS C:\> $restoreRequest

ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest itemLevelRestoreTargetInfo  FailIfExists                    eastus2euap                      OperationalStore    2021-04-23T02:47:02.9500000Z


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

BACKUPINSTANCE <BackupInstanceResource>: Backup Instance object to trigger original localtion restore.
  [Property <IBackupInstance>]: BackupInstanceResource properties
    DataSourceInfo <IDatasource>: Gets or sets the data source information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.
      [Type <String>]: DatasourceType of the resource.
    FriendlyName <String>: Gets or sets the Backup Instance friendly name.
    ObjectType <String>: 
    PolicyInfo <IPolicyInfo>: Gets or sets the policy information.
      PolicyId <String>: 
      [PolicyParameter <IPolicyParameters>]: Policy parameters for the backup instance
        [DataStoreParametersList <IDataStoreParameters[]>]: Gets or sets the DataStore Parameters
          DataStoreType <DataStoreTypes>: type of datastore; Operational/Vault/Archive
          ObjectType <String>: Type of the specific object - used for deserializing
    [DataSourceSetInfo <IDatasourceSet>]: Gets or sets the data source set information.
      ResourceId <String>: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      [DatasourceType <String>]: DatasourceType of the resource.
      [ObjectType <String>]: Type of Datasource object, used to initialize the right inherited type
      [ResourceLocation <String>]: Location of datasource.
      [ResourceName <String>]: Unique identifier of the resource in the context of parent.
      [ResourceType <String>]: Resource Type of Datasource.
      [ResourceUri <String>]: Uri of the resource.
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/initialize-azdataprotectionrestorerequest
#>
function Initialize-AzDataProtectionRestoreRequest {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest])]
[CmdletBinding(DefaultParameterSetName='AlternateLocationFullRecovery', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
    # Datasource Type
    ${DatasourceType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType]
    # DataStore Type of the Recovery point
    ${SourceDataStore},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Target Restore Location
    ${RestoreLocation},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetType]
    # Restore Target Type
    ${RestoreType},

    [Parameter(ParameterSetName='OriginalLocationILR', Mandatory)]
    [Parameter(ParameterSetName='OriginalLocationFullRecovery', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstanceResource]
    # Backup Instance object to trigger original localtion restore.
    # To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.
    ${BackupInstance},

    [Parameter(ParameterSetName='OriginalLocationILR', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Switch Parameter to enable item level recovery.
    ${ItemLevelRecovery},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Id of the recovery point to be restored.
    ${RecoveryPoint},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.DateTime]
    # Point In Time for restore.
    ${PointInTime},

    [Parameter(ParameterSetName='OriginalLocationILR')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Container names for Item Level Recovery.
    ${ContainersList},

    [Parameter(ParameterSetName='OriginalLocationILR')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Minimum matching value for Item Level Recovery.
    ${FromPrefixPattern},

    [Parameter(ParameterSetName='OriginalLocationILR')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Maximum matching value for Item Level Recovery.
    ${ToPrefixPattern},

    [Parameter(ParameterSetName='AlternateLocationFullRecovery', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # Target resource Id to which backup data will be restored.
    ${TargetResourceId}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            OriginalLocationILR = 'Az.DataProtection.custom\Initialize-AzDataProtectionRestoreRequest';
            AlternateLocationFullRecovery = 'Az.DataProtection.custom\Initialize-AzDataProtectionRestoreRequest';
            OriginalLocationFullRecovery = 'Az.DataProtection.custom\Initialize-AzDataProtectionRestoreRequest';
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
