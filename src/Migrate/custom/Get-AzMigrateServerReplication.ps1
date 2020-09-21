
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
Retrieves the details of the replicating server.
.Description
The Get-AzMigrateServerReplication cmdlet retrieves the object for the replicating server.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/get-azmigrateserverreplication
#>
function Get-AzMigrateServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem])]
    [CmdletBinding(DefaultParameterSetName='ListByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='GetByID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server.
        ${TargetObjectID},

        [Parameter(ParameterSetName='GetByName', Mandatory)]
        [Parameter(ParameterSetName='ListByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='GetByName', Mandatory)]
        [Parameter(ParameterSetName='ListByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate project  in the current subscription.
        ${ProjectName},

        [Parameter(ParameterSetName='GetByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the server for which the details needs to be retrieved.
        ${MachineName},

        [Parameter(ParameterSetName='GetByInputObject', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem]
        # Specifies the machine object of the replicating server.
        ${InputObject},

        [Parameter(ParameterSetName='ListById', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupID},

        [Parameter(ParameterSetName='ListById', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate Project in which servers are replicating.
        ${ProjectID},

        [Parameter(ParameterSetName='ListByName')]
        [Parameter(ParameterSetName='ListById')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Query')]
        [System.String]
        # OData filter options.
        ${Filter},
    
        [Parameter(ParameterSetName='ListByName')]
        [Parameter(ParameterSetName='ListById')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Query')]
        [System.String]
        # The pagination token.
        ${SkipToken},
    
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
            $parameterSet = $PSCmdlet.ParameterSetName
            $null = $PSBoundParameters.Remove('TargetObjectID')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('ProjectName')
            $null = $PSBoundParameters.Remove('MachineName')
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupID')
            $null = $PSBoundParameters.Remove('ProjectID')
            $HasFilter = $PSBoundParameters.ContainsKey('Filter')
            $HasSkipToken = $PSBoundParameters.ContainsKey('SkipToken')
            $null = $PSBoundParameters.Remove('Filter')
            $null = $PSBoundParameters.Remove('SkipToken')
           
            if(($parameterSet -eq 'GetByName') -or ($parameterSet -match 'List')){
                if($parameterSet -eq 'ListById'){
                    $ProjectName = $ProjectID.Split("/")[8]
                    $ResourceGroupName = $ResourceGroupID.Split("/")[4]
                }
                $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
                $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration")
                $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
                
                $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
                if($solution -and ($solution.Count -ge 1)){
                    $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
                    $applianceObj =  ConvertFrom-Json $solution.DetailExtendedDetail.AdditionalProperties.applianceNameToSiteIdMapV2
                    $applianceName = $applianceObj[0].ApplianceName
                }else{
                    throw "Solution not found."
                }
                $null = $PSBoundParameters.Remove("Name")
                $null = $PSBoundParameters.Remove("MigrateProjectName")
                $null = $PSBoundParameters.Add('ResourceName', $VaultName)
                $allFabrics = Az.Migrate.internal\Get-AzMigrateReplicationFabric @PSBoundParameters
                $FabricName = ""
                if($allFabrics -and ($allFabrics.length -gt 0)){
                    foreach ($fabric in $allFabrics) {
                        if($fabric.Name -match $applianceName){
                            $FabricName = $fabric.Name
                            break
                        }
                    }
                }
                if($FabricName -eq ""){
                    throw "Fabric not found for given resource group"
                }

                $null = $PSBoundParameters.Add('FabricName', $FabricName)
                $peContainers = Az.Migrate.internal\Get-AzMigrateReplicationProtectionContainer @PSBoundParameters
                $ProtectionContainerName = ""
                if($peContainers -and ($peContainers.length -gt 0)){
                    foreach ($peContainer in $peContainers) {
                        if($peContainer.Name -match $applianceName){
                            $ProtectionContainerName = $peContainer.Name
                            break
                        }
                    }
                }

                if($ProtectionContainerName -eq ""){
                    throw "Container not found for given resource group"
                }

                $null = $PSBoundParameters.Remove('ResourceGroupName')
                $null = $PSBoundParameters.Remove('ResourceName')
                $null = $PSBoundParameters.Remove('FabricName')
            }else {
                if($parameterSet -eq 'GetByInputObject'){
                    $TargetObjectID = $InputObject.Id
                }
                $MachineIdArray = $TargetObjectID.Split("/")
                $ResourceGroupName = $MachineIdArray[4]
                $VaultName = $MachineIdArray[8]
                $FabricName = $MachineIdArray[10]
                $ProtectionContainerName = $MachineIdArray[12]
                $MachineName = $MachineIdArray[14]
            }
            if($parameterSet -match 'Get'){
                $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
                $null = $PSBoundParameters.Add("ResourceName", $VaultName)
                $null = $PSBoundParameters.Add("FabricName", $FabricName)
                $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
                $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)
    
                return Az.Migrate.internal\Get-AzMigrateReplicationMigrationItem @PSBoundParameters
            }else{
                $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
                $null = $PSBoundParameters.Add("ResourceName", $VaultName)
                $null = $PSBoundParameters.Add("FabricName", $FabricName)
                $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)
                if($HasFilter){$null = $PSBoundParameters.Add("Filter", $Filter)}
                if($HasSkipToken){$null = $PSBoundParameters.Add("SkipToken", $SkipToken)}
                
                return Az.Migrate.internal\Get-AzMigrateReplicationMigrationItem @PSBoundParameters
            }
               
        } 
}   