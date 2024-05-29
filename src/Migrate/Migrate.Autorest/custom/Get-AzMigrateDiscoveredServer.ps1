
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
https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratediscoveredserver
#>

function Get-AzMigrateDiscoveredServer {
    [OutputType(
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine],
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachine])]
    [CmdletBinding(DefaultParameterSetName = 'List', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
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

        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'GetInSite', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the source machine name. This is an internal Name. For users, use display name.
        ${Name},

        [Parameter(ParameterSetName = 'List')]
        [Parameter(ParameterSetName = 'ListInSite')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the source machine display name.
        ${DisplayName},

        [Parameter(ParameterSetName = 'GetInSite', Mandatory)]
        [Parameter(ParameterSetName = 'ListInSite', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the appliance name. This internally maps to a site.
        ${ApplianceName},

        [Parameter()]
        [ValidateSet("VMware", "HyperV")]
        [ArgumentCompleter( { "VMware", "HyperV" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the source machine type. Currently, only HyperV and VMware are supported.
        ${SourceMachineType} = "VMware",

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Specifies the subscription id.
        ${SubscriptionId}
    )
    
    process {
        $parameterSet = $PSCmdlet.ParameterSetName
        $hasApplianceName = $PSBoundParameters.ContainsKey("ApplianceName")
        
        $discoverySolutionName = "Servers-Discovery-ServerDiscovery"
        $discoverySolution = Az.Migrate\Get-AzMigrateSolution -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -MigrateProjectName $ProjectName -Name $discoverySolutionName
        if ($discoverySolution.Name -ne $discoverySolutionName)
        {
            throw "Server Discovery Solution not found."
        }

        $appMap = @{}

        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"])
        {
            $appMapV2 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json
            # Fetch all appliance from V2 map first. Then these can be updated if found again in V3 map.
            foreach ($item in $appMapV2)
            {
                $appMap[$item.ApplianceName] = $item.SiteId
            }
        }
        
        if ($null -ne $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"])
        {
            $appMapV3 = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] | ConvertFrom-Json
            foreach ($item in $appMapV3)
            {
                $t = $item.psobject.properties
                $appMap[$t.Name] = $t.Value.SiteId
            }    
        }

        if ($null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] -And
            $null -eq $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] )
        {
            throw "Server Discovery Solution missing Appliance Details. Invalid Solution."           
        }

        # Regex to match site name.
        if ($SourceMachineType -eq "VMware")
        {
            $siteRegex = "(?<=/Microsoft.OffAzure/VMwareSites/).*$"
        }
        else {
            $siteRegex = "(?<=/Microsoft.OffAzure/HyperVSites/).*$"
        }

        if ($parameterSet -match 'Get')
        {
            # Get or GetInSite
            foreach ($kvp in $appMap.GetEnumerator())
            {
                if (($kvp.Value -match $siteRegex) -and
                    (-not (($parameterSet -eq 'GetInSite') -and ($kvp.Key -ne $ApplianceName))))
                {
                    $siteNameTmp = $Matches[0]
                    if ($SourceMachineType -eq "VMware")
                    {
                        $machine = Az.Migrate.Internal\Get-AzMigrateMachine `
                            -Name $Name `
                            -ResourceGroupName $ResourceGroupName `
                            -SiteName $siteNameTmp `
                            -SubscriptionId $SubscriptionId `
                            -ErrorVariable notPresent `
                            -ErrorAction SilentlyContinue
                    }
                    else {
                        # HyperV
                        $machine = Az.Migrate.Internal\Get-AzMigrateHyperVMachine `
                            -MachineName $Name `
                            -ResourceGroupName $ResourceGroupName `
                            -SiteName $siteNameTmp `
                            -SubscriptionId $SubscriptionId `
                            -ErrorVariable notPresent `
                            -ErrorAction SilentlyContinue
                    }

                    # Remove server marked as Deleted.
                    if ($null -ne $machine -and $machine.IsDeleted)
                    {
                        $machine = $null
                    }
    
                    if ($null -ne $machine)
                    {
                        return $machine
                    }
                }
            }

            $errorMsg = "No machine with machine Name '$Name' of Type '$SourceMachineType' found in Project '$ProjectName'"
            if ($hasApplianceName)
            {
                $errorMsg += " with Appliance '$ApplianceName'"
            }

            throw $errorMsg
        }
        else {
            # List or ListInSite
            $allMachines = [System.Collections.ArrayList]::new()
            foreach ($kvp in $appMap.GetEnumerator())
            {
                if (($kvp.Value -match $siteRegex) -and
                    (-not (($parameterSet -eq 'ListInSite') -and ($kvp.Key -ne $ApplianceName))))
                {
                    $siteNameTmp = $Matches[0]
                    if ($SourceMachineType -eq "VMware")
                    {
                        $machines = Az.Migrate.Internal\Get-AzMigrateMachine `
                            -ResourceGroupName $ResourceGroupName `
                            -SiteName $siteNameTmp `
                            -SubscriptionId $SubscriptionId
                    }
                    else {
                        # HyperV
                        $machines = Az.Migrate.Internal\Get-AzMigrateHyperVMachine `
                            -ResourceGroupName $ResourceGroupName `
                            -SiteName $siteNameTmp `
                            -SubscriptionId $SubscriptionId
                    }

                    if ($null -ne $machines)
                    {
                        $allMachines.AddRange($machines)
                    }
                }
            }

            # Remove servers marked as Deleted.
            $allMachines = $allMachines | Where-Object { !$_.IsDeleted }

            if ($allMachines.Count -gt 0 -and $DisplayName)
            {
                $allMachines = $allMachines | Where-Object { $_.DisplayName -match $DisplayName }
            }

            if ($allMachines.Count -eq 0)
            {
                $errorMsg = "No machine of Type '$SourceMachineType' found in Project '$ProjectName'"
                if ($hasApplianceName)
                {
                    $errorMsg += " with Appliance '$ApplianceName'"
                }

                if ($DisplayName)
                {
                    $errorMsg += " with matching machine DisplayName '$DisplayName'"
                }

                throw $errorMsg
            }
            
            return $allMachines
        }
    }
}