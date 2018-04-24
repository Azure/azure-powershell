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
    PS C:\> .\src\DelegatedProvider.Tests.ps1
	Describing DelegatedProvider
	  [+] TestListDelegatedProviders 158ms
	  [+] TestGetAllDelegatedProviders 201ms

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

    Describe "DelegatedProvider" -Tags @('DelegatedProviders', 'SubscriptionsAdmin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateDelegatedProvider {
                param(
                    [Parameter(Mandatory = $true)]
                    $DelegatedProvider
                )
                # Overall
                $DelegatedProvider                            | Should Not Be $null

                # Resource
                $DelegatedProvider.Id                         | Should Not Be $null

                # DelegatedProvider
                $DelegatedProvider.OfferId                    | Should Not Be $null
                $DelegatedProvider.Owner                      | Should Not Be $null
                $DelegatedProvider.RoutingResourceManagerType | Should Not Be $null
				$DelegatedProvider.SubscriptionId             | Should Not Be $null
				$DelegatedProvider.DisplayName                | Should Not Be $null
				$DelegatedProvider.State                      | Should Not Be $null
				$DelegatedProvider.TenantId                   | Should Not Be $null
            }

            function AssertDelegatedProvidersSame {
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
					$Found.OfferId                    | Should Be $Found.OfferId
					$Found.Owner                      | Should Be $Found.Owner
					$Found.RoutingResourceManagerType | Should Be $Found.RoutingResourceManagerType
					$Found.SubscriptionId             | Should Be $Found.SubscriptionId
					$Found.DisplayName                | Should Be $Found.DisplayName
					$Found.State                      | Should Be $Found.State
					$Found.TenantId                   | Should Be $Found.TenantId
                }
            }
        }

        It "TestListDelegatedProviders" {
            $global:TestName = 'TestListDelegatedProviders'

            $providers = Get-AzsDelegatedProvider

            foreach($provider in $providers) {
                ValidateDelegatedProvider $provider
	        }
        }

		It "TestGetAllDelegatedProviders" {
            $global:TestName = 'TestGetAllDelegatedProviders'

            $providers = Get-AzsDelegatedProvider

            foreach($provider in $providers) {
				$provider2 = Get-AzsDelegatedProvider -DelegatedProviderId $provider.SubscriptionId
                AssertDelegatedProvidersSame $provider $provider2
	        }
		}
    }
}
