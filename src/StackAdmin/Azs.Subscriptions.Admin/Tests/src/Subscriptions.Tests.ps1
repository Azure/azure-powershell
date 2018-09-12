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
    PS C:\> .\src\Subscriptions.Tests.ps1
	  Describing Subscription
		[+] TestListSubscriptions 493ms
		[+] CheckNameAvailability 49ms
		[+] CreateUpdateDeleteSubscription 205ms

.NOTES
    Author: Bala Ganapathy
	Copyright: Microsoft
    Date:   February 21, 2018
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

    Describe "Subscription" -Tags @('Subscriptions', 'SubscriptionsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateSubscription {
                param(
                    [Parameter(Mandatory = $true)]
                    $Subscription
                )

                $Subscription                | Should Not Be $null

                # Resource
                $Subscription.Id             | Should Not Be $null
                $Subscription.DisplayName    | Should Not Be $null
                $Subscription.OfferId        | Should Not Be $null
                $Subscription.Owner          | Should Not Be $null
                $Subscription.State          | Should Not Be $null
                $Subscription.SubscriptionId | Should Not Be $null
                $Subscription.TenantId       | Should Not Be $null

            }

        }

        AfterEach {
            $global:Client = $null
        }

        it "TestListSubscriptions" -Skip:$('TestListSubscriptions' -in $global:SkippedTests) {
            $global:TestName = 'TestListSubscriptions'

            $Subscriptions = Get-AzsUserSubscription
            $Subscriptions | Should Not Be $null
            foreach ($Subscription in $Subscriptions) {
                ValidateSubscription -Subscription $Subscription
            }
        }

        it "TestSetSubscription" -Skip:$('TestSetSubscription' -in $global:SkippedTests) {
            $global:TestName = "TestSetSubscription"

            $Subscriptions = Get-AzsUserSubscription
            foreach ($sub in $subscriptions) {
                $sub.DisplayName += "-test"
                $sub.Owner = $global:Owner

                $sub | Set-AzsUserSubscription

                $updated = Get-AzsUserSubscription -SubscriptionId $sub.SubscriptionId

                $updated.DisplayName | Should Be $sub.DisplayName
                $updated.Owner       | Should Be $global:Owner

				break;
			}
		}

        it "CheckNameAvailability" -Skip:$('CheckNameAvailability' -in $global:SkippedTests) {
            $global:TestName = 'CheckNameAvailability'

            Test-AzsNameAvailability -Name $global:TestAvailability -ResourceType $global:ResourceType
        }

        it "TestMoveSubscription" -Skip:$('TestMoveSubscription' -in $global:SkippedTests) {
            $global:TestName = 'MoveSubscription'
            $resourceIds = Get-AzsUserSubscription -Filter "offerName eq 'o1'" | Select -ExpandProperty Id
            Move-AzsSubscription -DestinationDelegatedProviderOffer $Null -ResourceId $resourceIds
		}

        it "TestTestMoveSubscription" -Skip:$('TestTestMoveSubscription' -in $global:SkippedTests) {
            $global:TestName = 'MoveSubscription'
            $resourceIds = Get-AzsUserSubscription -Filter "offerName eq 'o1'" | Select-Object -ExpandProperty Id
            Test-AzsMoveSubscription -DestinationDelegatedProviderOffer $Null -ResourceId $resourceIds
		}
    }
}
