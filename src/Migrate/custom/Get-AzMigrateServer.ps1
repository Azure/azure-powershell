
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
Get All servers in a migrate project.
.Description
Get Azure migrate server commandlet fetches all servers in a migrate project.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/get-azmigrateserver
#>

function Get-AzMigrateServer {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine])]
    param (
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the migrate project name.
        ${MigrateProjectName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the resource group name.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Specifies the subscription id.
        ${SubscriptionId}
    )
    
    process {
        $discoverySolutionName = "Servers-Discovery-ServerDiscovery"
        $discoverySolution = Get-AzMigrateSolution -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -MigrateProjectName $MigrateProjectName -Name $discoverySolutionName
        if ($discoverySolution.Name -ne $discoverySolutionName) {
            throw "Server Discovery Solution not found."
        }

        $extendedDetails = $discoverySolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json

        $projectSdsMachines = [System.Collections.ArrayList]::new()
        foreach ($det in $extendedDetails) {
            $siteArmId = $det.SiteId
            $r = '(?<=/Microsoft.OffAzure/VMwareSites/).*$'

            if ($siteArmId -match $r) {
                $siteName = $Matches[0]
                $siteMachines = Get-AzMigrateMachine -ResourceGroupName $ResourceGroupName -SiteName $siteName -SubscriptionId $SubscriptionId
                if ($null -ne $siteMachines) {
                    $projectSdsMachines.AddRange($siteMachines)
                }
            }            
        }

        return $projectSdsMachines
    }
}