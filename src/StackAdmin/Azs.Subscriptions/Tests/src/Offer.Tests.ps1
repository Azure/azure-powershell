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
    PS C:\> .\src\Offer.Tests.ps1
	Describing Offers
	  [+] TestListRootOffers 119ms
	  [+] TestListDelegatedProviderOffers 84ms
	  [+] TestGetDelegatedProviderOffers 95ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions {

    Describe "Offers" -Tags @('Subscription', 'Offer') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateOffer {
                param(
                    [Parameter(Mandatory = $true)]
                    $Offer
                )

                $Offer              | Should Not Be $null

                # Resource
                $Offer.Id           | Should Not Be $null
                $Offer.Name         | Should Not Be $null
                $Offer.DisplayName  | Should Not Be $null
            }

            function AssertOffersAreSame {
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
                    $Found.Name             | Should Be $Expected.Name
                    $Found.DisplayName      | Should Be $Expected.DisplayName
                }
            }
        }

        it "TestListRootOffers" -Skip:$('TestListRootOffers' -in $global:SkippedTests) {
            $global:TestName = 'TestListRootOffers'

            $offers = Get-AzsOffer
            $offers | Should Not Be $null
            foreach ($offer in $offers) {
                ValidateOffer -Offer $offer
            }
        }

        it "TestListDelegatedProviderOffers" -Skip:$('TestListDelegatedProviderOffers' -in $global:SkippedTests) {
            $global:TestName = 'TestListDelegatedProviderOffers'

            $offers = Get-AzsDelegatedProviderOffer -DelegatedProviderId 'default'
            $offers | Should Not Be $null
            foreach ($offer in $offers) {
                ValidateOffer -Offer $offer
            }
        }

        it "TestGetDelegatedProviderOffers" -Skip:$('TestGetDelegatedProviderOffers' -in $global:SkippedTests) {
            $global:TestName = 'TestGetDelegatedProviderOffers'

            $offers = Get-AzsDelegatedProviderOffer -DelegatedProviderId 'default'
            $offers | Should Not Be $null
            foreach ($offer in $offers) {
                $retrieved = Get-AzsDelegatedProviderOffer -OfferName $offer.Name -DelegatedProviderId 'default'
                AssertOffersAreSame -Expected $offer -Found $retrieved
                break
            }
        }
    }
}
