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
    PS C:\> .\src\EdgeGatewayPool.Tests.ps1
	Describing EdgeGatewayPools
	 [+] TestListEdgeGatewayPools 155ms
	 [+] TestGetEdgeGatewayPool 106ms
	 [+] TestGetAllEdgeGatewayPools 84ms

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

InModuleScope Azs.Fabric.Admin {

    Describe "EdgeGatewayPools" -Tags @('EdgeGatewayPool', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {
            function ValidateEdgeGatewayPool {
                param(
                    [Parameter(Mandatory = $true)]
                    $EdgeGatewayPool
                )

                $EdgeGatewayPool          | Should Not Be $null

                # Resource
                $EdgeGatewayPool.Id       | Should Not Be $null
                $EdgeGatewayPool.Location | Should Not Be $null
                $EdgeGatewayPool.Name     | Should Not Be $null
                $EdgeGatewayPool.Type     | Should Not Be $null

                # Edge Gateway Pool
                $EdgeGatewayPool.GatewayType      | Should Not Be $null
                $EdgeGatewayPool.PublicIpAddress  | Should Not Be $null
                $EdgeGatewayPool.NumberOfGateways | Should Not Be $null
            }

            function AssertEdgeGatewayPoolsAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                } else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Edge Gateway Pool
                    $Found.GatewayType      | Should Be $Expected.GatewayType
                    $Found.PublicIpAddress  | Should Be $Expected.PublicIpAddress
                    $Found.NumberOfGateways | Should Be $Expected.NumberOfGateways
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        It "TestListEdgeGatewayPools" -Skip:$('TestListEdgeGatewayPools' -in $global:SkippedTests) {
            $global:TestName = 'TestListEdgeGatewayPools'
            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $edgeGatewayPools | Should Not Be $null
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                ValidateEdgeGatewayPool -EdgeGatewayPool $edgeGatewayPool
            }
        }


        It "TestGetEdgeGatewayPool" -Skip:$('TestGetEdgeGatewayPool' -in $global:SkippedTests) {
            $global:TestName = 'TestGetEdgeGatewayPool'

            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                $retrieved = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $edgeGatewayPool.Name
                AssertEdgeGatewayPoolsAreSame -Expected $edgeGatewayPool -Found $retrieved
                break
            }
        }

        It "TestGetAllEdgeGatewayPools" -Skip:$('TestGetAllEdgeGatewayPools' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllEdgeGatewayPools'

            $edgeGatewayPools = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($edgeGatewayPool in $edgeGatewayPools) {
                $retrieved = Get-AzsEdgeGatewayPool -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $edgeGatewayPool.Name
                AssertEdgeGatewayPoolsAreSame -Expected $edgeGatewayPool -Found $retrieved
            }
        }

    }
}
