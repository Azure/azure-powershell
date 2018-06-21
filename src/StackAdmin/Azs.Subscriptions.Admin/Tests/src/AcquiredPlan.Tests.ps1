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
    PS C:\> .\src\AcquiredPlan.Tests.ps1

	  Describing AcquiredPlan
		[+] TestListAcquiredPlans 420ms
		[+] TestGetAcquiredPlan 96ms
		[+] TestCreateThenDeleteAcquiredPlan 230ms

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 16, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "AcquiredPlan" -Tags @('AcquiredPlan', 'SubscriptionsAdmin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidatePlanAcquisition {
                param(
                    [Parameter(Mandatory = $true)]
                    $PlanAcquisition
                )
                # Overall
                $PlanAcquisition                            | Should Not Be $null

                # Resource
                $PlanAcquisition.Id                         | Should Not Be $null

                # PlanAcquisition
                $PlanAcquisition.AcquisitionId              | Should Not Be $null
                $PlanAcquisition.AcquisitionTime            | Should Not Be $null
				$PlanAcquisition.PlanId                     | Should Not Be $null
				$PlanAcquisition.ProvisioningState          | Should Not Be $null
            }

            function AssertPlanAcquisitionsSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                } else {
                    $Found                            | Should Not Be $null

                    # Resource
                    $Found.Id                         | Should Be $Expected.Id

					# DelegatedProvider
					$Found.AcquisitionId              | Should Be $Found.AcquisitionId
					$Found.AcquisitionTime            | Should Be $Found.AcquisitionTime
					$Found.ExternalReferenceId        | Should Be $Found.ExternalReferenceId
					$Found.PlanId                     | Should Be $Found.PlanId
					$Found.ProvisioningState          | Should Be $Found.ProvisioningState
                }
            }
        }

        It "TestListAcquiredPlans" {
            $global:TestName = 'TestListAcquiredPlans'

            $plans = Get-AzsSubscriptionPlan -TargetSubscriptionId "8158498d-27b1-4ccf-9aa1-de0f925731e6"

            foreach($plan in $plans) {
                ValidatePlanAcquisition $plan
	        }
        }

		It "TestGetAcquiredPlan" {
            $global:TestName = 'TestGetAcquiredPlan'

            $subscriptionId = "ca831431-dac2-4466-a538-59fa3f882f68"
            $plans = Get-AzsSubscriptionPlan -TargetSubscriptionId $subscriptionId

            foreach($plan in $plans) {
				$plan2 = Get-AzsSubscriptionPlan -TargetSubscriptionId $subscriptionId -AcquisitionId $plan.AcquisitionId
                AssertPlanAcquisitionsSame $plan $plan2
	        }
		}

		It "TestCreateThenDeleteAcquiredPlan" {
			$global:TestName = "TestCreateThenDeleteAcquiredPlan"

			$subs = Get-AzsUserSubscription
			$plans = Get-AzsPlan

			$acquisitionId = "718c7f7c-4868-479a-98ce-5caaa8f158c8"
			$subscriptionId = "8158498d-27b1-4ccf-9aa1-de0f925731e6"

			$new = New-AzsSubscriptionPlan -AcquisitionId $acquisitionId -PlanId $plans[0].Id -TargetSubscriptionId $subscriptionId
			ValidatePlanAcquisition $new

			Remove-AzsSubscriptionPlan -AcquisitionId $acquisitionId -TargetSubscriptionId $subscriptionId -Force

			{ Get-AzsSubscriptionPlan -AcquisitionId $acquisitionId -TargetSubscriptionId $subscriptionId } | Should Throw
		}
    }
}
