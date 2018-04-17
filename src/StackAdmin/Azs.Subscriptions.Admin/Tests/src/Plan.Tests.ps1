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
    [bool]$RunRaw = $false
)

$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "Plan" -Tags @('Plans', 'SubscriptionsAdmin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

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
                } else {
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

        It "TestListPlans" {
            $global:TestName = 'TestListPlans'

            $allPlans = Get-AzsPlan
            $resourceGroups = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

            foreach($plan in $allPlans) {
                $rgn = GetResourceGroupName -ID $plan.Id
                $resourceGroups.Add($rgn)
            }

            foreach($rgn in $resourceGroups) {
                Get-AzsPlan -ResourceGroupName $rgn
            }
        }

        It "TestCreateUpdateThenDeletePlan" {
            $global:TestName = 'TestCreateUpdateThenDeletePlan'

            $location = "local"
            $rg = "testrg"
            $name = "testplans"
            $description = "description of the plan"

            $quota = Get-AzsSubscriptionsQuota -Location $Location

            $result = New-AzsPlan -Name $name -ResourceGroupName $rg -Location $location -DisplayName $name -QuotaIds $quota.Id -Description $description
            ValidatePlan -Plan $result

            $plan = Get-AzsPlan -Name $name -ResourceGroupName $rg
            ValidatePlan -Plan $plan

            Remove-AzsPlan -Name $name -ResourceGroupName $rg -Force
        }
    }
}
