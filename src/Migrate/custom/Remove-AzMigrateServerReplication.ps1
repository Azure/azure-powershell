
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
Remove Migration item. 
.Description
Remove Migration item. 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/remove-azmigrateserverreplication
#>
function Remove-AzMigrateServerReplication {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='ByMachineName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByMachineName',Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Resource group.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByMachineName',Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Migrate project.
        ${ProjectName},

        [Parameter(ParameterSetName='ByMachineName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Name of an Azure Migrate protected VM.
        ${MachineName},

        [Parameter(ParameterSetName='ByMachineId',Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Id of an Azure Migrate protected VM.
        ${MachineId},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Query')]
        [System.String]
        # The delete option.
        ${DeleteOption},

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
        try {
            # TODO PLEASE FIX BEFORE RELEASE
            Set-PSDebug -Step; foreach ($i in 1..3) {$i}
            $parameterSet = $PSCmdlet.ParameterSetName

            $hasDeleteOption = $PSBoundParameters.ContainsKey('DeleteOption')
            $null = $PSBoundParameters.Remove('DeleteOption')

            if ($parameterSet -eq 'ByMachineName') {
                # TODO
                $VaultName = "AzMigrateTestProjectPWSH02aarsvault"
                $FabricName = ""
                $ProtectionContainerName = ""
                
                $null = $PSBoundParameters.Remove('ProjectName')
                $null = $PSBoundParameters.Remove('MachineName')

                $null = $PSBoundParameters.Add('ResourceName', $VaultName)
                $allFabrics = Az.Migrate.internal\Get-AzMigrateReplicationFabric @PSBoundParameters
                if($allFabrics -and ($allFabrics.length -gt 0)){
                    $FabricName = $allFabrics[0].Name
                }
                
                $null = $PSBoundParameters.Add('FabricName', $FabricName)
                $peContainers = Az.Migrate.internal\Get-AzMigrateReplicationProtectionContainer @PSBoundParameters
                if($peContainers -and ($peContainers.length -gt 0)){
                    $ProtectionContainerName = $peContainers[0].Name
                }

                $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
                $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)
                if($hasDeleteOption){
                    $null = $PSBoundParameters.Add('DeleteOption', $DeleteOption)
                }

                return Az.Migrate.internal\Remove-AzMigrateReplicationMigrationItem @PSBoundParameters
            } 

            if($parameterSet  -eq 'ByMachineId'){
                $null = $PSBoundParameters.Remove('MachineId')

                $MachineIdArray = $MachineId.Split("/")
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
                if($hasDeleteOption){
                    $null = $PSBoundParameters.Add('DeleteOption', $DeleteOption)
                }

                return Az.Migrate.internal\Remove-AzMigrateReplicationMigrationItem @PSBoundParameters

                

                return
            }
        } catch {
           throw
        }
    }

}   