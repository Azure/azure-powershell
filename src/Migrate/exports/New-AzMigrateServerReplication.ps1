
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
Starts replication for the specified server.
.Description
The New-AzMigrateServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.
.Example
PS C:\> New-AzMigrateServerReplication -MachineId "/subscriptions/xxx-xxx-xxx4/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskType "Standard_LRS" -OSDiskID "6000C299-343d-7bcd-c05e-a94bd63316dd"

ActivityId                       : 68af14b4-46ae-48d1-b3e9-cdcffb9e8a93 ActivityId: 74d1a396-1d37-4264-8a5b-b727aaef0171
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          : 9/16/20 11:57:33 AM
Error                            : {}
FriendlyName                     : Enable
Id                               : /Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Recover
                                   yServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/997e2a92-5afe-49c7-a81a-89660aec9b7b
Location                         :
Name                             : 997e2a92-5afe-49c7-a81a-89660aec9b7b
ScenarioName                     : Enable
StartTime                        : 9/16/20 11:57:32 AM
State                            : Succeeded
StateDescription                 : Completed
TargetInstanceType               : ProtectionProfile
TargetObjectId                   : 42752b89-5fad-52fd-bf93-679fbdb6fed9
TargetObjectName                 : migrateAzMigratePWSHTc8d1sitepolicy
Task                             : {CloudPairingPrerequisitesCheck, CloudPairingPrepareSite}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
.Example
PS C:\> $OSDisk = New-AzMigrateDiskMapping -DiskID '6000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'true'
PS C:\> $DataDisk = New-AzMigrateDiskMapping -DiskID '7000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'false'
PS C:\> $DisksToInclude += $OSDisk
PS C:\> $DisksToInclude += $DataDisk
PS C:\> New-AzMigrateServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskToInclude $DisksToInclude -PerformAutoResync true

ActivityId                       : 68af14b4-46ae-48d1-b3e9-cdcffb9e8a93 ActivityId: 74d1a396-1d37-4264-8a5b-b727aaef0171
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          : 9/16/20 11:57:33 AM
Error                            : {}
FriendlyName                     : Enable
Id                               : /Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Recover
                                   yServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/997e2a92-5afe-49c7-a81a-89660aec9b7b
Location                         :
Name                             : 997e2a92-5afe-49c7-a81a-89660aec9b7b
ScenarioName                     : Enable
StartTime                        : 9/16/20 11:57:32 AM
State                            : Succeeded
StateDescription                 : Completed
TargetInstanceType               : ProtectionProfile
TargetObjectId                   : 42752b89-5fad-52fd-bf93-679fbdb6fed9
TargetObjectName                 : migrateAzMigratePWSHTc8d1sitepolicy
Task                             : {CloudPairingPrerequisitesCheck, CloudPairingPrepareSite}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DISKTOINCLUDE <IVMwareCbtDiskInput[]>: Specifies the disks on the source server to be included for replication.
  DiskId <String>: The disk Id.
  IsOSDisk <String>: A value indicating whether the disk is the OS disk.
  LogStorageAccountId <String>: The log storage account ARM Id.
  LogStorageAccountSasSecretName <String>: The key vault secret name of the log storage account.
  [DiskEncryptionSetId <String>]: The DiskEncryptionSet ARM Id.
  [DiskType <DiskAccountType?>]: The disk type.

INPUTOBJECT <IVMwareMachine>: Specifies the discovered server to be migrated. The server object can be retrieved using the Get-AzMigrateServer cmdlet.
  [GuestOSDetailOstype <String>]: Type of the operating system.
.Link
https://docs.microsoft.com/powershell/module/az.migrate/new-azmigrateserverreplication
#>
function New-AzMigrateServerReplication {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob])]
[CmdletBinding(DefaultParameterSetName='ByIdDefaultUser', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [ArgumentCompleter({ "NoLicenseType" , "WindowsServer" })]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies if Azure Hybrid benefit is applicable for the source server to be migrated.
    ${LicenseType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Resource Group id within the destination Azure subscription to which the server needs to be migrated.
    ${TargetResourceGroupId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.
    ${TargetNetworkId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Subnet name within the destination Virtual Netowk to which the server needs to be migrated.
    ${TargetSubnetName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the name of the Azure VM to be created.
    ${TargetVMName},

    [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
    [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the machine ID of the discovered server to be migrated.
    ${MachineId},

    [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
    [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
    [ArgumentCompleter({ "Standard_LRS" , "Premium_LRS", "StandardSSD_LRS" })]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the type of disks to be used for the Azure VM.
    ${DiskType},

    [Parameter(ParameterSetName='ByIdDefaultUser', Mandatory)]
    [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Operating System disk for the source server to be migrated.
    ${OSDiskID},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Mapping.
    ${ReplicationContainerMapping},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Account id.
    ${VMWarerunasaccountID},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the SKU of the Azure VM to be created.
    ${TargetVMSize},

    [Parameter()]
    [ArgumentCompleter({ "true" , "false" })]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies if replication be auto-repaired in case change tracking is lost for the source server under replication.
    ${PerformAutoResync},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Availability Set to be used for VM creationSpecifies the Availability Set to be used for VM creation.
    ${TargetAvailabilitySet},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Availability Zone to be used for VM creation.
    ${TargetAvailabilityZone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the storage account to be used for boot diagnostics.
    ${TargetBootDiagnosticsStorageAccount},

    [Parameter(ParameterSetName='ByIdDefaultUser')]
    [Parameter(ParameterSetName='ByInputObjectDefaultUser')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the disk encyption set to be used.
    ${DiskEncryptionSetID},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Azure Subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByIdPowerUser', Mandatory)]
    [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]]
    # Specifies the disks on the source server to be included for replication.
    # To construct, see NOTES section for DISKTOINCLUDE properties and create a hash table.
    ${DiskToInclude},

    [Parameter(ParameterSetName='ByInputObjectPowerUser', Mandatory)]
    [Parameter(ParameterSetName='ByInputObjectDefaultUser', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine]
    # Specifies the discovered server to be migrated.
    # The server object can be retrieved using the Get-AzMigrateServer cmdlet.
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            ByIdDefaultUser = 'Az.Migrate.custom\New-AzMigrateServerReplication';
            ByIdPowerUser = 'Az.Migrate.custom\New-AzMigrateServerReplication';
            ByInputObjectPowerUser = 'Az.Migrate.custom\New-AzMigrateServerReplication';
            ByInputObjectDefaultUser = 'Az.Migrate.custom\New-AzMigrateServerReplication';
        }
        if (('ByIdDefaultUser', 'ByIdPowerUser', 'ByInputObjectPowerUser', 'ByInputObjectDefaultUser') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
