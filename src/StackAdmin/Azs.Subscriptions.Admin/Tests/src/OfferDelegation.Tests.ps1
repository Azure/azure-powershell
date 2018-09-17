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
    PS C:\> .\src\Offer.Tests.ps1

	  Describing OfferDelegation
		[+] TestListOfferDelegations 527ms

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
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "OfferDelegation" -Tags @('Offers', 'SubscriptionsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateOfferDelegation {
                param(
                    [Parameter(Mandatory = $true)]
                    $Offer
                )
                # Overall
                $Offer               | Should Not Be $null

                # Resource
                $Offer.Id            | Should Not Be $null
                $Offer.Name          | Should Not Be $null
                $Offer.Type          | Should Not Be $null
                $Offer.Location      | Should Not Be $null

                # Offer
                $Offer.SubscriptionId | Should Not Be $null
            }

            function AssertOfferDelegationsSame {
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

                    # OfferDelegation
                    $Found.SubscriptionId   | Should Be $Expected.SubscriptionId
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

        it "TestListOfferDelegations" -Skip:$('TestListOfferDelegations' -in $global:SkippedTests) {
            $global:TestName = "TestListOfferDelegations"

            $offers = Get-AzsManagedOffer

            foreach ($offer in $offers) {
                $resourceGroupName = GetResourceGroupName -ID $offer.Id
                $offerdel = Get-AzsOfferDelegation -ResourceGroupName $resourceGroupName -OfferName $offer.Name
                ValidateOfferDelegation $offerdel
            }
        }
    }
}
