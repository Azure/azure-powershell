
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
        # Specifies the display name of the replicating machine.
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
     
        if ($parameterSet -eq 'GetBySDSID') {
            $machineIdArray = $DiscoveredMachineId.Split("/")
            if ($machineIdArray.Length -lt 11) {
                throw "Invalid machine ID '$DiscoveredMachineId'"
            }
            $siteType = $machineIdArray[7]
            $siteName = $machineIdArray[8]
            $ResourceGroupName = $machineIdArray[4]
            $ProtectedItemName = $machineIdArray[10]

            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            $null = $PSBoundParameters.Add('SiteName', $siteName)

            if (($siteType -ne $SiteTypes.HyperVSites) -and ($siteType -ne $SiteTypes.VMwareSites)) {
                throw "Unknown machine site '$siteName' with Type '$siteType'."
            }
            
            # Occasionally, Get Machine Site will not return machine site even when the site exist,
            # hence retry get machine site.
            $attempts = 4
            for ($i = 1; $i -le $attempts; $i++) {
                try {
                    if ($siteType -eq $SiteTypes.VMwareSites) {
                        $siteObject = Az.Migrate\Get-AzMigrateSite @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    }
                    elseif ($siteType -eq $SiteTypes.HyperVSites) {
                        $siteObject = Az.Migrate.Internal\Get-AzMigrateHyperVSite @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
                    } 

                    if ($null -eq $siteObject) {
                        throw "Machine site not found."
                    }
                    else {
                        $ProjectName = $siteObject.DiscoverySolutionId.Split("/")[8]
                    }

                    break;
                }
                catch {
                    if ($i -lt $attempts)
                    {
                        Write-Host "Machine site not found. Retrying in 30 seconds..."
                        Start-Sleep -Seconds 30
                    }
                    else
                    {
                        throw "Machine site '$siteName' with Type '$siteType' not found."
                    }
                }
            }
                
            $null = $PSBoundParameters.Remove('SiteName')

            $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration_DataReplication")
            $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
                    
            $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
            if ($solution -and ($solution.Count -ge 1)) {
                $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
            }
            else {
                throw "Solution not found."
            }

            $null = $PSBoundParameters.Remove("Name")
            $null = $PSBoundParameters.Remove("MigrateProjectName")
    
            $null = $PSBoundParameters.Add("VaultName", $VaultName)
            $null = $PSBoundParameters.Add("Name", $ProtectedItemName)

            return Az.Migrate.Internal\Get-AzMigrateProtectedItem @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
        }
            
        if (($parameterSet -match 'List') -or ($parameterSet -eq 'GetByMachineName')) {
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

            $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
            $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration_DataReplication")
            $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)
                
            $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
            if ($solution -and ($solution.Count -ge 1)) {
                $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
            }
            else {
                throw "Solution not found."
            }

            $null = $PSBoundParameters.Remove("Name")
            $null = $PSBoundParameters.Remove("MigrateProjectName")
            $null = $PSBoundParameters.Add("VaultName", $VaultName)
                
            $replicatingItems = Az.Migrate.Internal\Get-AzMigrateProtectedItem @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue

            if ($parameterSet -eq "GetByMachineName") {
                $replicatingItems = $replicatingItems | Where-Object { $_.Property.FabricObjectName -eq $MachineName }
            }
            return $replicatingItems
        }

        if (($parameterSet -eq "GetByInputObject") -or ($parameterSet -eq "GetByItemID")) {
            if ($parameterSet -eq 'GetByInputObject') {
                $TargetObjectID = $InputObject.Id
            }
            $objectIdArray = $TargetObjectID.Split("/")
            if ($objectIdArray.Length -lt 11) {
                throw "Invalid target object ID '$TargetObjectID'."
            }

            $ResourceGroupName = $objectIdArray[4]
            $VaultName = $objectIdArray[8]
            $ProtectedItemName = $objectIdArray[10]
            $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
            $null = $PSBoundParameters.Add("VaultName", $VaultName)
            $null = $PSBoundParameters.Add("Name", $ProtectedItemName)
    
            return Az.Migrate.Internal\Get-AzMigrateProtectedItem @PSBoundParameters -ErrorVariable notPresent -ErrorAction SilentlyContinue
        }
    }
}