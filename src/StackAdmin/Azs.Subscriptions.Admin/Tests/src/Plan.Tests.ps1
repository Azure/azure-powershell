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
.SYNOPSIS
    Run AzureStack subscription admin tests.

.DESCRIPTION
    Run AzureStack subscriptions admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Plan.Tests.ps1
	Describing Plan
		[+] TestListPlans 185ms
		[+] TestCreateUpdateThenDeletePlan 193ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   March 13, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "Plan" -Tags @('Plans', 'SubscriptionsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidatePlan {
                param(
                    [Parameter(Mandatory = $true)]
                    $Plan
                )
                # Overall
                $Plan               | Should Not Be $null

                # Resource
                $Plan.Id            | Should Not Be $null
                $Plan.Name          | Should Not Be $null
                $Plan.Type          | Should Not Be $null
                $Plan.Location      | Should Not Be $null

                # Plan
                $Plan.DisplayName   | Should Not Be $null
                $Plan.PlanName      | Should Not Be $null
                $Plan.QuotaIds      | Should Not Be $null
            }

            function AssertPlansSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                }
                else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Plan
                    $Plan.DisplayName       | Should Be $Expected.DisplayName
                    $Plan.PlanName          | Should Be $Expected.PlanName
                    $Plan.QuotaIds          | Should Be $Expected.QuotaIds
                }
            }

            function GetResourceGroupName() {
                param(
                    $ID
                )
                $rg = "resourceGroups/"
                $pv = "providers/"
                $start = $ID.IndexOf($rg) + $rg.Length
                $length = $ID.IndexOf($pv) - $start - 1
                return $ID.Substring($start, $length);
            }
        }

        AfterEach {
            $global:Client = $null
        }

        it "TestListPlans" -Skip:$('TestListPlans' -in $global:SkippedTests) {
            $global:TestName = 'TestListPlans'

            $allPlans = Get-AzsPlan
            $global:ResourceGroupNames = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

            foreach ($plan in $allPlans) {
                $rgn = GetResourceGroupName -ID $plan.Id
                $global:ResourceGroupNames.Add($rgn)
            }

            foreach ($rgn in $global:ResourceGroupNames) {
                Get-AzsPlan -ResourceGroupName $rgn
            }
        }

        it "TestSetPlan" -Skip:$('TestSetPlan' -in $global:SkippedTests) {
            $global:TestName = "TestSetPlan"

            $allPlans = Get-AzsPlan
            $plan = $allPlans[0]
            $rgn = GetResourceGroupName -Id $plan.Id

            $plan.DisplayName += "-test"

            $plan | Set-AzsPlan
            $updated = Get-AzsPlan -Name $plan.Name -ResourceGroupName $rgn
            $updated.DisplayName | Should Be $plan.DisplayName
        }

        it "TestCreateUpdateThenDeletePlan" -Skip:$('TestCreateUpdateThenDeletePlan' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateUpdateThenDeletePlan'

            $quota = Get-AzsSubscriptionsQuota -Location $global:Location

            $result = New-AzsPlan `
                -Name $global:planName `
                -ResourceGroupName $global:PlanResourceGroupName `
                -Location $global:Location `
                -DisplayName $global:planName `
                -QuotaIds $quota.Id `
                -Description $global:planDescription

            ValidatePlan -Plan $result

            Remove-AzsPlan -Name $global:planName -ResourceGroupName $global:PlanResourceGroupName -Force
        }
    }
}
