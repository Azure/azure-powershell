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
    PS C:\> .\src\DelegatedProviderOffer.Tests.ps1
	Describing DelegatedProviderOffer
	  [+] TestListDelegatedProviderOffers 169ms

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 16, 2018
#>
param(
    [bool]$RunRaw = $false
)

$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "DelegatedProviderOffer" -Tags @('DelegatedProviderOffers', 'SubscriptionsAdmin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateDelegatedProviderOffer {
                param(
                    [Parameter(Mandatory = $true)]
                    $offer
                )
                # Overall
                $offer            | Should Not Be $null

                # Resource
                $offer.Id         | Should Not Be $null
				$offer.Location   | Should Not Be $null
				$offer.Name       | Should Not Be $null
				$offer.Type       | Should Not Be $null
            }
        }
		
        It "TestListDelegatedProviderOffers" {
            $global:TestName = 'TestListDelegatedProviderOffers'

            $providers = Get-AzsDelegatedProvider

            foreach($provider in $providers) {
				$offers = Get-AzsDelegatedProviderManagedOffer -DelegatedProvider $provider.DelegatedProviderSubscriptionId
				foreach($offer in $offers)
				{
	                ValidateDelegatedProviderOffer $offer
				}
	        }
        }
    }
}
