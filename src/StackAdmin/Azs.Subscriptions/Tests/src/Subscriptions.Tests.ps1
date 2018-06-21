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
    Run AzureStack fabric admin edge gateway pool tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway pool tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Subscriptions.Tests.ps1
	Describing Subscriptions
	  [+] TestListSubscriptions 2.01s
	  [+] TestGetSubscription 278ms

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 20, 2018
#>
param(
	[bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions {

	Describe "Subscriptions" -Tags @('Subscriptions', 'Offers') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateSubscription {
				param(
					[Parameter(Mandatory=$true)]
					$subscription
				)

				$subscription          | Should Not Be $null

				# Resource
				$subscription.Id       | Should Not Be $null

				# Subscription
				$subscription.DisplayName	    | Should Not Be $null
				$subscription.SubscriptionId	| Should Not Be $null
				$subscription.TenantId			| Should Not Be $null
				$subscription.State             | Should Not Be $null
				$subscription.OfferId           | Should Not Be $null
			}

			function AssertSubscriptionsAreSame {
				param(
					[Parameter(Mandatory=$true)]
					$Expected,

					[Parameter(Mandatory=$true)]
					$Found
				)
				if($Expected -eq $null) {
					$Found | Should Be $null
				} else {
					$Found          | Should Not Be $null

					# Resource
					$Found.Id       | Should Be $Expected.Id

					# Subscription
					$Found.DisplayName	    | Should Not Be $null
					$Found.SubscriptionId	| Should Not Be $null
					$Found.TenantId			| Should Not Be $null
					$Found.State            | Should Not Be $null
					$Found.OfferId          | Should Not Be $null
				}
			}
		}


		It "TestListSubscriptions" {
			$global:TestName = 'TestListSubscriptions'

			$subscriptions = Get-AzsSubscription
			$subscriptions | Should Not Be $null
			foreach($subscription in $subscriptions) {
				ValidateSubscription -Subscription $subscription
			}
	    }

		It "TestGetSubscription" {
            $global:TestName = 'TestGetSubscription'

			$subscriptions = Get-AzsSubscription
			$subscriptions | Should Not Be $null
			foreach($subscription in $subscriptions) {
				$retrieved = Get-AzsSubscription -SubscriptionId $subscription.SubscriptionId
				AssertSubscriptionsAreSame -Expected $subscription -Found $retrieved
				break
			}
		}
    }
}
