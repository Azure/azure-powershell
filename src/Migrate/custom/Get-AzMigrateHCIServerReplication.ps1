
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
The Get-AzMigrateHCIServerReplication cmdlet retrieves the object for the replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehciserverreplication
#>
function Get-AzMigrateHCIServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IProtectedItemModel])]
    [CmdletBinding(DefaultParameterSetName = 'ListByName', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'GetByItemID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server ARM ID.
        ${TargetObjectID},

        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate project  in the current subscription.
        ${ProjectName},

        [Parameter(ParameterSetName = 'GetBySDSID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the machine ID of the discovered server.
        ${DiscoveredMachineId},

        [Parameter(ParameterSetName = 'GetByInputObject', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity]
        # Specifies the machine object of the replicating server.
        ${InputObject},

        [Parameter(ParameterSetName = 'ListById', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupID},

        [Parameter(ParameterSetName = 'ListById', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate Project in which servers are replicating.
        ${ProjectID},

        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the replicating machine.
        ${MachineName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
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
    
    process {
        Import-Module $PSScriptRoot\Helper\AzStackHCICommonSettings.ps1

        $parameterSet = $PSCmdlet.ParameterSetName
        $null = $PSBoundParameters.Remove('TargetObjectID')
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('ProjectName')
        $null = $PSBoundParameters.Remove('DiscoveredMachineId')
        $null = $PSBoundParameters.Remove('InputObject')
        $null = $PSBoundParameters.Remove('ResourceGroupID')
        $null = $PSBoundParameters.Remove('ProjectID')
        $null = $PSBoundParameters.Remove('MachineName')

        # Retrieve ProjectName if GetBySDSID
        if ($parameterSet -eq 'GetBySDSID') {
            $machineIdArray = $DiscoveredMachineId.Split('/')
            if ($machineIdArray.Length -lt 11) {
                throw "Invalid machine ID '$DiscoveredMachineId'."
            }

            $ResourceGroupName = $machineIdArray[4]
            $siteType = $machineIdArray[7]
            $siteName = $machineIdArray[8]
            $MachineName = $machineIdArray[10]

            # Get machine site
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('SiteName', $siteName)

            if ($siteType -eq $SiteTypes.VMwareSites) {
                $siteObject = Az.Migrate\Get-AzMigrateSite @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
            }
            elseif ($siteType -eq $SiteTypes.HyperVSites) {
                $siteObject = Az.Migrate.Internal\Get-AzMigrateHyperVSite @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
            }
            else {
                throw "Unknown machine site '$siteName' with Type '$siteType'."
            }

            $null = $PSBoundParameters.Remove('SiteName')
            $null = $PSBoundParameters.Remove('ResourceGroupName')

            if ($null -eq $siteObject) {
                throw "Machine site '$siteName' with Type '$siteType' not found."
            }
            elseif ([string]::IsNullOrEmpty($siteObject.DiscoverySolutionId)) {
                throw "Discovery solution Id is not found in machine site '$siteName' with Type '$siteType'."
            }
            else {
                $discoverySolutionIdArray = $siteObject.DiscoverySolutionId.Split("/")
                if ($discoverySolutionIdArray.Length -lt 9) {
                    throw "Invalid discovery solution Id '$discoveredMachineId' found in machine site '$siteName' with Type '$siteType'."
                }

                $ProjectName = $discoverySolutionIdArray[8]
            }
        }

        # Retrieve ResourceGroupName, ProjectName if ListByID
        if ($parameterSet -eq 'ListByID') {
            $resourceGroupIdArray = $ResourceGroupID.Split('/')
            if ($resourceGroupIdArray.Length -lt 5) {
                throw "Invalid resource group Id '$ResourceGroupID'."
            }

            $ResourceGroupName = $resourceGroupIdArray[4]

            $projectIdArray = $ProjectID.Split('/')
            if ($projectIdArray.Length -lt 9) {
                throw "Invalid migrate project Id '$ProjectID'."
            }

            $ProjectName = $projectIdArray[8]
        }

        # Retrieve VaultName if GetBySDSID, GetByMachineName, ListByID, or ListByName
        if ($parameterSet -eq 'GetBySDSID' -or $parameterSet -eq 'GetByMachineName' -or
            $parameterSet -eq 'ListByID' -or $parameterSet -eq 'ListByName') {
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('MigrateProjectName', $ProjectName)
            $null = $PSBoundParameters.Add('Name', 'Servers-Migration-ServerMigration_DataReplication')

            $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters

            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('MigrateProjectName')
            $null = $PSBoundParameters.Remove('ResourceGroupName')

            if ($null -eq $solution -or $solution.Count -eq 0) {
                throw "Solution 'Servers-Migration-ServerMigration_DataReplication' not found."
            }
            else {
                $vaultId = $solution.DetailExtendedDetail.AdditionalProperties.vaultId
                if ([string]::IsNullOrEmpty($vaultId)) {
                    throw "Replication vauld Id is not found in Solution 'Servers-Migration-ServerMigration_DataReplication'."
                }

                $vaultIdArray = $vaultId.Split("/")
                if ($vaultIdArray.Length -lt 9) {
                    throw "Invalid replication vault Id '$vaultId' found in Solution 'Servers-Migration-ServerMigration_DataReplication'."
                }
                
                $VaultName = $vaultIdArray[8]
            }
        }

        # Retrieve ResourceGroupName, VaultName, MachineName if by InputObject or ItemID
        if (($parameterSet -eq 'GetByInputObject') -or ($parameterSet -eq 'GetByItemID')) {
            if ($parameterSet -eq 'GetByInputObject') {
                $TargetObjectID = $InputObject.Id
            }

            $objectIdArray = $TargetObjectID.Split('/')
            if ($objectIdArray.Length -lt 11) {
                throw "Invalid target object ID '$TargetObjectID'."
            }

            $ResourceGroupName = $objectIdArray[4]
            $VaultName = $objectIdArray[8]
            $MachineName = $objectIdArray[10]
        }

        $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
        $null = $PSBoundParameters.Add('VaultName', $VaultName)
        if ($parameterSet -match 'Get') {
            $null = $PSBoundParameters.Add('Name', $MachineName)
        }
        
        $null = $PSBoundParameters.Add('ErrorVariable', 'notPresent')
        $null = $PSBoundParameters.Add('ErrorAction', 'SilentlyContinue')

        return Az.Migrate.Internal\Get-AzMigrateProtectedItem @PSBoundParameters
    }
}