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
    PS C:\> .\src\Network.Tests.ps1
	Describing SubscriptionTests
	[+] TestListRegionHealths 182ms
	[+] TestGetRegionHealth 112ms
	[+] TestGetAllRegionHealths 113ms

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

InModuleScope Azs.Network.Admin {

    Describe "LoadBalancerTests" {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

        }

        It "TestGetAllLoadBalancers" -Skip:$('TestGetAllLoadBalancers' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllLoadBalancers'

            $Balancers = Get-AzsLoadBalancer
            # This test should be using the SessionRecord which has an existing LoadBalancer created
            if ($null -ne $Balancers) {
                foreach ($Balancer in $Balancers) {
                    ValidateBaseResources($Balancer)
                    ValidateBaseResourceTenant($Balancer)
                    $Balancer.PublicIpAddresses | Should Not Be $null
                    foreach ($IpAddress in $Balancer.PublicIpAddresses) {
                        $IpAddress | Should Not Be $null
                    }
                }
            }
        }
    }
}
