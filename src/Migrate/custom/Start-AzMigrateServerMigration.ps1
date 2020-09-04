
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
Starts the migration for the replicating server.
.Description
Starts the migration for the replicating server.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/start-azmigraterservermigration
#>
function Start-AzMigrateServerMigration {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem])]
    [CmdletBinding(DefaultParameterSetName='ByNameVMwareCbt', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByIDVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the test migration needs to be initiated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter(ParameterSetName='ByNameVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the resource group of the replicating server.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByNameVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the migrate project name of the replicating server.
        ${ProjectName},

        [Parameter(ParameterSetName='ByNameVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine name of the replicating server.
        ${MachineName},

        [Parameter(ParameterSetName='ByInputObjectVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem]
        # Specifies the machine object of the replicating server.
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the source server should be turned off post migration.
        ${TurnOffSourceServer},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
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
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
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
    
    process {
            $null = $PSBoundParameters.Remove('TargetObjectID')
            $hasTurnOffSourceServer = $PSBoundParameters.ContainsKey('TurnOffSourceServer')
            $null = $PSBoundParameters.Remove('TurnOffSourceServer')

            $MachineIdArray = $TargetObjectID.Split("/")
            $ResourceGroupName = $MachineIdArray[4]
            $VaultName = $MachineIdArray[8]
            $FabricName = $MachineIdArray[10]
            $ProtectionContainerName = $MachineIdArray[12]
            $MachineName = $MachineIdArray[14] 

            $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
            $null = $PSBoundParameters.Add("ResourceName", $VaultName)
            $null = $PSBoundParameters.Add("FabricName", $FabricName)
            $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
            $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)

            $ReplicationMigrationItem = Az.Migrate.internal\Get-AzMigrateReplicationMigrationItem @PSBoundParameters
            if($ReplicationMigrationItem -and ($ReplicationMigrationItem.ProviderSpecificDetail.InstanceType -eq 'VMwarecbt') -and ($ReplicationMigrationItem.AllowedOperation -contains 'Migrate' )){
                $ProviderSpecificDetailInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtMigrateInput]::new()
                $ProviderSpecificDetailInput.InstanceType = 'VMwareCbt'
                if($hasTurnOffSourceServer){
                    $null = $ProviderSpecificDetailInput.Add('TurnOffSourceServer', $TurnOffSourceServer)
                }
                $null = $PSBoundParameters.Add('ProviderSpecificDetail', $ProviderSpecificDetailInput)
                return Az.Migrate.internal\Move-AzMigrateReplicationMigrationItem @PSBoundParameters
            }else{
                Write-Host "Either machine doesn't exist or provider/action isn't supported for this machine"
            }        
    }
}   