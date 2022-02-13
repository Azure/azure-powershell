
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
Get All discovered servers in a migrate project.
.Description
Get Azure migrate server commandlet fetches all servers in a migrate project.
.Link
https://docs.microsoft.com/powershell/module/az.migrate/get-azmigratediscoveredserver
#>

function Get-AzMigrateDiscoveredServer {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine])]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param (
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the migrate project name.
        ${ProjectName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the resource group name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='GetInSite', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the VMware machine name. This is an internal Name. For users, use display name.
        ${Name},

        [Parameter(ParameterSetName='List')]
        [Parameter(ParameterSetName='ListInSite')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the VMware machine display name.
        ${DisplayName},

        [Parameter(ParameterSetName='GetInSite', Mandatory)]
        [Parameter(ParameterSetName='ListInSite', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the appliance name. This internally maps to a site.
        ${ApplianceName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Specifies the subscription id.
        ${SubscriptionId}
    )
    
    process {
        $parameterSet = $PSCmdlet.ParameterSetName
        
        $discoverySolutionName = "Servers-Discovery-ServerDiscovery"
        $discoverySolution = Get-AzMigrateSolution -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -MigrateProjectName $ProjectName -Name $discoverySolutionName
        if ($discoverySolution.Name -ne $discoverySolutionName) {
            throw "Server Discovery Solution not found."
        }

        $appMap = @{}

        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"]) {
            $appMapV2 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json
            # Fetch all appliance from V2 map first. Then these can be updated if found again in V3 map.
            foreach ($item in $appMapV2) {
                $appMap[$item.ApplianceName] = $item.SiteId
            }
        }
        
        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"]) {
            $appMapV3 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] | ConvertFrom-Json
            foreach ($item in $appMapV3) {
                $t = $item.psobject.properties
                $appMap[$t.Name] = $t.Value.SiteId
            }    
        }

        if ($null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] -And
             $null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] ) {
            throw "Server Discovery Solution missing Appliance Details. Invalid Solution."           
        }

        # Regex to match site name.
        $r = '(?<=/Microsoft.OffAzure/VMwareSites/).*$'
        $siteNameTmp = ""
        if ($parameterSet -match "Site") {
            #Fetch by site scenario. This is when site name filter is provided.
            $siteFound = 0
            foreach ($kvp in $appMap.GetEnumerator()) {
                if ($kvp.Key -eq $ApplianceName) {
                    $siteArmId = $kvp.Value
                    if ($siteArmId -match $r) {
                        $siteNameTmp = $Matches[0]
                        $siteFound = 1
                        if ($parameterSet -eq 'GetInSite') {
                            return Get-AzMigrateMachine -Name $Name -ResourceGroupName $ResourceGroupName -SiteName $siteNameTmp -SubscriptionId $SubscriptionId
                        }
                        elseif ($parameterSet -eq 'ListInSite') {
                            $siteMachines = Get-AzMigrateMachine -ResourceGroupName $ResourceGroupName -SiteName $siteNameTmp -SubscriptionId $SubscriptionId
                            
                            if ($DisplayName) {
                                $filteredMachines = $siteMachines | Where-Object {$_.DisplayName -match $DisplayName}
                                return $filteredMachines
                            }
                            else {
                                return $siteMachines
                            }
                        }        
                    }                    
                }
            }

            if ($siteFound -eq 0) {
                throw "Appiance: $ApplianceName not found in project $ProjectName."
            }
        }
        else {
            # Fetch across project. All machines or by name.
            $projectSdsMachines = [System.Collections.ArrayList]::new()

            if ($parameterSet -eq 'List') {
                foreach ($kvp in $appMap.GetEnumerator()) {
                    $siteArmId = $kvp.Value
        
                    if ($siteArmId -match $r) {
                        $siteNameTmp = $Matches[0]
                        $siteMachines = Get-AzMigrateMachine -ResourceGroupName $ResourceGroupName -SiteName $siteNameTmp -SubscriptionId $SubscriptionId
                        if ($null -ne $siteMachines) {
                            $projectSdsMachines.AddRange($siteMachines)
                        }    
                    }
                }

                if ($DisplayName) {
                    $filteredMachines = $projectSdsMachines | Where-Object {$_.DisplayName -match $DisplayName}
                    return $filteredMachines
                }
                else {
                    return $projectSdsMachines                
                }
            }
            elseif ($parameterSet -eq 'Get') {
                foreach ($kvp in $appMap.GetEnumerator()) {
                    $siteArmId = $kvp.Value
        
                    if ($siteArmId -match $r) {
                        $siteNameTmp = $Matches[0]

                        try {
                            $siteMachine = Get-AzMigrateMachine -Name $Name -ResourceGroupName $ResourceGroupName -SiteName $siteNameTmp -SubscriptionId $SubscriptionId
                            if ($null -ne $siteMachine) {
                                return $siteMachine
                            }
                        }
                        catch {
                            $theError = $_
                            Write-Host $theError
                        }
                    }      
                }

                throw "Machine with Id $Name not found in project $ProjectName."
            }
        }
    }
}