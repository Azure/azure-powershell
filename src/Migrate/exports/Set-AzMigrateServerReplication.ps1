
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
Updates the target properties for the replicating server.
.Description
The Set-AzMigrateServerReplication cmdlet updates the target properties for the replicating server.
.Example
PS C:\> Set-AzMigrateServerReplication -TargetObjectID '/Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationFabrics/AzMigratePWSHTc8d1replicationfabric/replicationProtectionContainers/AzMigratePWSHTc8d1replicationcontainer/replicationMigrationItems/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_500f44f8-2aa3-587b-8958-ead358639629' -TargetVMName 'rb-w2k12r2-1'

ActivityId                       : da958651-96b3-4e65-a41e-897d4b06f7dd ActivityId: 3a4c8d4d-920a-47cd-82c3-f3dcce90a588
AllowedAction                    : {Cancel}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          :
Error                            : {}
FriendlyName                     : Update
Id                               : /Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Recover
                                   yServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/931dde9a-de67-4a30-a045-bb9d6162f8ab
Location                         :
Name                             : 931dde9a-de67-4a30-a045-bb9d6162f8ab
ScenarioName                     : Update
StartTime                        : 9/25/20 9:20:08 PM
State                            : InProgress
StateDescription                 : InProgress
TargetInstanceType               : ProtectionEntity
TargetObjectId                   : 101883a0-23f7-538a-bbd5-6d8b4fa900e2
TargetObjectName                 : prsadhu-TestVM
Task                             : {DisableProtectionOnPrimary, UpdateDraState}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMigrationItem>: Specifies the replicating server for which the properties need to be updated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet.
  [Location <String>]: Resource Location
  [CurrentJobId <String>]: The ARM Id of the job being executed.
  [CurrentJobName <String>]: The job name.
  [CurrentJobStartTime <DateTime?>]: The start time of the job.
  [ProviderSpecificDetail <IMigrationProviderSpecificSettings>]: The migration provider custom settings.

NICTOUPDATE <IVMwareCbtNicInput[]>: Updates the NIC for the Azure VM to be created.
  IsPrimaryNic <String>: A value indicating whether this is the primary NIC.
  NicId <String>: The NIC Id.
  [IsSelectedForMigration <String>]: A value indicating whether this NIC is selected for migration.
  [TargetStaticIPAddress <String>]: The static IP address.
  [TargetSubnetName <String>]: Target subnet name.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/set-azmigrateserverreplication
#>
function Set-AzMigrateServerReplication {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJob])]
[CmdletBinding(DefaultParameterSetName='ByIDVMwareCbt', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='ByIDVMwareCbt', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the replcating server for which the properties need to be updated.
    # The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
    ${TargetObjectID},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the replcating server for which the properties need to be updated.
    # The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
    ${TargetVMName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Updates the SKU of the Azure VM to be created.
    ${TargetVMSize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Updates the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.
    ${TargetNetworkId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Updates the Resource Group id within the destination Azure subscription to which the server needs to be migrated.
    ${TargetResourceGroupID},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicInput[]]
    # Updates the NIC for the Azure VM to be created.
    # To construct, see NOTES section for NICTOUPDATE properties and create a hash table.
    ${NicToUpdate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Specifies the Availability Set to be used for VM creation.
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByInputObjectVMwareCbt', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem]
    # Specifies the replicating server for which the properties need to be updated.
    # The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet.
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
            ByIDVMwareCbt = 'Az.Migrate.custom\Set-AzMigrateServerReplication';
            ByInputObjectVMwareCbt = 'Az.Migrate.custom\Set-AzMigrateServerReplication';
        }
        if (('ByIDVMwareCbt', 'ByInputObjectVMwareCbt') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
