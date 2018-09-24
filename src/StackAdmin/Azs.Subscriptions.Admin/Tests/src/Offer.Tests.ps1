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
	  Describing Offer
		[+] TestListOffers 503ms
		[+] TestGetOffer 118ms
		[+] TestGetAllOffers 152ms
		[+] TestCreateUpdateThenDeleteOffer 181ms

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

    Describe "Offer" -Tags @('Offers', 'SubscriptionsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateOffer {
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
                $Offer.DisplayName   | Should Not Be $null
                $Offer.OfferName     | Should Not Be $null
                $Offer.Description   | Should Not Be $null
                $Offer.State         | Should Not Be $null
            }

            function AssertOffersSame {
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

                    # Offer
                    $Found.DisplayName   | Should Be $Expected.DisplayName
                    $Found.OfferName     | Should Be $Expected.OfferName
                    $Found.Description   | Should Be $Expected.Description
                    $Found.State         | Should Be $Expected.State
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

        it "TestListOffers" -Skip:$('TestListOffers' -in $global:SkippedTests) {
            $global:TestName = 'TestListOffers'

            $allOffers = Get-AzsManagedOffer
            $global:ResourceGroupNames = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

            foreach ($offer in $allOffers) {
                $rgn = GetResourceGroupName -ID $offer.Id
                $global:ResourceGroupNames.Add($rgn)
            }

            foreach ($rgn in $global:ResourceGroupNames) {
                Get-AzsManagedOffer -ResourceGroupName $rgn
            }
        }

        it "TestGetOffer" -Skip:$('TestGetOffer' -in $global:SkippedTests) {
            $global:TestName = 'TestGetOffer'

            $offer = (Get-AzsManagedOffer)[0]
            $offer | Should Not Be $null
            $rgn = GetResourceGroupName -ID $offer.Id
            $offer2 = Get-AzsManagedOffer -ResourceGroupName $rgn -Name $offer.Name
            AssertOffersSame $offer $offer2
        }

        it "TestGetAllOffers" -Skip:$('TestGetAllOffers' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllOffers'

            $allOffers = Get-AzsManagedOffer
            foreach ($offer in $allOffers) {
                $rgn = GetResourceGroupName -ID $offer.Id
                $offer2 = Get-AzsManagedOffer -ResourceGroupName $rgn -Name $offer.Name
                AssertOffersSame $offer $offer2
            }
        }

        it "TestSetOffer" -Skip:$('TestSetOffer' -in $global:SkippedTests) {
            $global:TestName = "TestSetOffer"

            $allOffers = Get-AzsManagedOffer
            $offer = $allOffers[0]
            $rgn = GetResourceGroupName -Id $offer.Id

            $offer.DisplayName += "-test"

            $offer | Set-AzsOffer
            $updated = Get-AzsManagedOffer -Name $offer.Name -ResourceGroupName $rgn
            $updated.DisplayName | Should Be $offer.DisplayName
        }

        it "TestCreateUpdateThenDeleteOffer" -Skip:$('TestCreateUpdateThenDeleteOffer' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateUpdateThenDeleteOffer'

            $plan = (Get-AzsPlan)[0]

            $offer = New-AzsOffer -Name $global:OfferName -DisplayName "Test Offer" -ResourceGroupName $global:OfferResourceGroupName -BasePlanIds { $plan.Id } -Location $global:Location
            $saved = Get-AzsManagedOffer -Name $global:OfferName -ResourceGroupName $global:OfferResourceGroupName
            AssertOffersSame $offer $saved
        }
    }
}
