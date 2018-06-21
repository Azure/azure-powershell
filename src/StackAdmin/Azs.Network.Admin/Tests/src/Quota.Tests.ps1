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

    Describe "QuotasTests" {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function CheckBaseResourcesAreSame {
                param(
                    $expected,
                    $found
                )

                $expected.Id -eq $found.Id | Should Be $true
                $expected.Location -eq $found.Location | Should Be $true
                $expected.Name -eq $found.Name | Should Be $true
                $expected.Type -eq $found.Type | Should Be $true
            }

            function CreateTestQuota {
                param(
                    $Name
                )
                return New-AzsNetworkQuota -MaxPublicIpsPerSubscription $global:TestQuotaMaxPublicIpsPerSubscription `
                    -MaxVnetsPerSubscription $global:TestQuotaMaxVnetsPerSubscription `
                    -MaxVirtualNetworkGatewaysPerSubscription $global:TestQuotaMaxVirtualNetworkGatewaysPerSubscription `
                    -MaxVirtualNetworkGatewayConnectionsPerSubscription $global:TestQuotaMaxVirtualNetworkGatewayConnectionsPerSubscription `
                    -MaxLoadBalancersPerSubscription $global:TestQuotaMaxLoadBalancersPerSubscription `
                    -MaxNicsPerSubscription $global:TestQuotaMaxNicsPerSubscription `
                    -MaxSecurityGroupsPerSubscription $global:TestQuotaMaxSecurityGroupsPerSubscription `
                    -Name $Name `
                    -Location $global:Location `
                    -Force
            }

            function DeleteQuota {
                param(
                    [string] $location,
                    [string] $quotaName
                )

                Remove-AzsNetworkQuota -Name $quotaName -Location $location -Force
                Start-Sleep -Seconds 5 # Is NRP really that terrible?
            }

            function AssertQuotasAreSame {
                param(
                    $expected,
                    $found
                )

                if ($null -eq $expected) {
                    $found | Should Be $null
                }
                else {
                    CheckBaseResourcesAreSame -expected $expected -found $found

                    $expected.MaxLoadBalancersPerSubscription -eq $found.MaxLoadBalancersPerSubscription | Should Be $true
                    $expected.MaxNicsPerSubscription -eq $found.MaxNicsPerSubscription | Should Be $true
                    $expected.MaxPublicIpsPerSubscription -eq $found.MaxPublicIpsPerSubscription | Should Be $true
                    $expected.MaxSecurityGroupsPerSubscription -eq $found.MaxSecurityGroupsPerSubscription | Should Be $true
                    $expected.MaxVirtualNetworkGatewayConnectionsPerSubscription -eq $found.MaxVirtualNetworkGatewayConnectionsPerSubscription | Should Be $true
                    $expected.MaxVirtualNetworkGatewaysPerSubscription -eq $found.MaxVirtualNetworkGatewaysPerSubscription | Should Be $true
                    $expected.MaxVnetsPerSubscription -eq $found.MaxVnetsPerSubscription | Should Be $true
                    $expected.MigrationPhase -eq $found.MigrationPhase | Should Be $true
                }
            }
        }

        # Record new tests
        It "TestPutAndDeleteQuota" -Skip:$('TestPutAndDeleteQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestPutAndDeleteQuota'

            $created = New-AzsNetworkQuota -Name $global:PutAndDeleteQuotaName -Location $global:location
            $quota = Get-AzsNetworkQuota -Name $global:PutAndDeleteQuotaName -Location $global:location

            $quota   | Should Not be $null
            $created | Should Not be $null

            $quota.Id | Should Not be $null
            $quota.Id | Should Not be $null

            AssertQuotasAreSame -expected $quota -found $created

            # Delete Quota
            DeleteQuota -quotaName $global:PutAndDeleteQuotaName -Location $global:location
        }

        # Record again
        It "TestPutAndUpdateQuota" -Skip:$('TestPutAndUpdateQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestPutAndUpdateQuota'

            $quota = New-AzsNetworkQuota -Name $global:CreateAndUpdateQuotaName -Location $global:location
            $created = Get-AzsNetworkQuota -Name $global:CreateAndUpdateQuotaName -Location $global:location

            $quota   | Should Not be $null
            $created | Should Not be $null

            AssertQuotasAreSame -expected $quota -found $created

            # Post update
            $updatedQuota = Set-AzsNetworkQuota `
                -Name $global:CreateAndUpdateQuotaName `
                -Location $global:location `
                -MaxNicsPerSubscription $global:MaxNicsPerSubscription

            $getUpdatedQuota = Get-AzsNetworkQuota `
                -Name $global:CreateAndUpdateQuotaName `
                -Location $global:location

            AssertQuotasAreSame -expected $updatedQuota -found $getUpdatedQuota

            # Delete Quota
            DeleteQuota -quotaName $global:CreateAndUpdateQuotaName -Location $global:Location
        }
    }
}
