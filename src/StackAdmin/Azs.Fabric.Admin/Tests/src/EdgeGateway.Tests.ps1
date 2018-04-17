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
    Run AzureStack fabric admin edge gateway tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\EdgeGateway.Tests.ps1
    Describing EdgeGateways
	 [+] TestListEdgeGateways 81ms
	 [+] TestGetEdgeGateway 73ms
	 [+] TestGetAllEdgeGateways 66ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
	[bool]$RunRaw = $false
)

$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Fabric.Admin {

	Describe "EdgeGateways" -Tags @('EdgeGateway', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateEdgeGateway {
				param(
					[Parameter(Mandatory=$true)]
					$EdgeGateway
				)

				$EdgeGateway          | Should Not Be $null

				# Resource
				$EdgeGateway.Id       | Should Not Be $null
				$EdgeGateway.Location | Should Not Be $null
				$EdgeGateway.Name     | Should Not Be $null
				$EdgeGateway.Type     | Should Not Be $null

				# Edge Gateway
				$EdgeGateway.NumberOfConnections  | Should Not Be $null
				$EdgeGateway.State                | Should Not Be $null
				$EdgeGateway.TotalCapacity        | Should Not Be $null

			}

			function AssertEdgeGatewaysAreSame {
				param(
					[Parameter(Mandatory=$true)]
					$Expected,

					[Parameter(Mandatory=$true)]
					$Found
				)

				if($Expected -eq $null) {
					$Found | Should Be $null
				} else {
					$Found                  | Should Not Be $null

					# Resource
					$Found.Id               | Should Be $Expected.Id
					$Found.Location         | Should Be $Expected.Location
					$Found.Name             | Should Be $Expected.Name
					$Found.Type             | Should Be $Expected.Type

					# Edgegateway
					$Found.NumberOfConnections  | Should Be $Expected.NumberOfConnections
					$Found.State                | Should Be $Expected.State
					$Found.TotalCapacity        | Should Be $Expected.TotalCapacity
				}
			}
		}

		It "TestListEdgeGateways" {
			$global:TestName = 'TestListEdgeGateways'

			$gateways = Get-AzsEdgeGateway -ResourceGroupName $ResourceGroup -Location $Location
			$gateways | Should Not Be $null
			foreach($gateway in $gateways) {
				ValidateEdgeGateway -EdgeGateway $gateway
			}
		}

		It "TestGetEdgeGateway" {
			$global:TestName = 'TestGetEdgeGateway'

			$gateways = Get-AzsEdgeGateway -ResourceGroupName $ResourceGroup -Location $Location
			foreach($gateway in $gateways) {
				$retrieved = Get-AzsEdgeGateway -ResourceGroupName $ResourceGroup -Location $Location -Name $gateway.Name
				AssertEdgeGatewaysAreSame -Expected $gateway -Found $retrieved
				break
			}
		}

		It "TestGetAllEdgeGateways" {
			$global:TestName = 'TestGetAllEdgeGateways'

			$gateways = Get-AzsEdgeGateway -ResourceGroupName $ResourceGroup -Location $Location
			foreach($gateway in $gateways) {
				$retrieved = Get-AzsEdgeGateway -ResourceGroupName $ResourceGroup -Location $Location -Name $gateway.Name
				AssertEdgeGatewaysAreSame -Expected $gateway -Found $retrieved
			}
		}
	}
}
