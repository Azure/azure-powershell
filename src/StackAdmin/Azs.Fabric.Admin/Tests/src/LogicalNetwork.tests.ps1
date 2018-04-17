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
    Run AzureStack fabric admin logical network tests.

.DESCRIPTION
    Run AzureStack fabric admin logical network tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\LogicalNetwork.Tests.ps1
	Describing LogicalNetworks
	 [+] TestListLogicalNetworks 132ms
	 [+] TestGetLogicalNetwork 75ms
	 [+] TestGetAllLogicalNetworks 174ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
	[bool]$RunRaw = $false
)

$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Fabric.Admin {

	Describe "LogicalNetworks" -Tags @('LogicalNetwork', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateLogicalNetwork {
				param(
					[Parameter(Mandatory=$true)]
					$LogicalNetwork
				)

				$LogicalNetwork          | Should Not Be $null

				# Resource
				$LogicalNetwork.Id       | Should Not Be $null
				$LogicalNetwork.Location | Should Not Be $null
				$LogicalNetwork.Name     | Should Not Be $null
				$LogicalNetwork.Type     | Should Not Be $null

				# Logical Network
				$LogicalNetwork.NetworkVirtualizationEnabled  | Should Not Be $null
				$LogicalNetwork.Subnets                       | Should Not Be $null
			}

			function AssertLogicalNetworksAreSame {
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

					# Logical Network
					$Found.NetworkVirtualizationEnabled  | Should Be $Expected.NetworkVirtualizationEnabled

					if($Expected.Subnets -eq $null) {
						$Found.Subnets        | Should Be $null
					} else {
						$Found.Subnets        | Should Not Be $null
						$Found.Subnets.Count  | Should Be $Expected.Subnets.Count
					}

					if($Expected.Metadata -eq $null) {
						$Found.Metadata        | Should Be $null
					} else {
						$Found.Metadata        | Should Not Be $null
						$Found.Metadata.Count  | Should Be $Expected.Metadata.Count
					}
				}
			}
		}


		It "TestListLogicalNetworks" {
			$global:TestName = 'TestListLogicalNetworks'
			$logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $ResourceGroup -Location $Location
			$logicalNetworks | Should Not Be $null
			foreach($logicalNetwork in $logicalNetworks) {
				ValidateLogicalNetwork -LogicalNetwork $logicalNetwork
			}
	    }


		It "TestGetLogicalNetwork" {
            $global:TestName = 'TestGetLogicalNetwork'

			$logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $ResourceGroup -Location $Location
			foreach($logicalNetwork in $logicalNetworks) {
				$retrieved = Get-AzsLogicalNetwork -ResourceGroupName $ResourceGroup -Location $Location -Name $logicalNetwork.Name
				AssertLogicalNetworksAreSame -Expected $logicalNetwork -Found $retrieved
				break
			}
		}

		It "TestGetAllLogicalNetworks" {
			$global:TestName = 'TestGetAllLogicalNetworks'

			$logicalNetworks = Get-AzsLogicalNetwork -ResourceGroupName $ResourceGroup -Location $Location
			foreach($logicalNetwork in $logicalNetworks) {
				$retrieved = Get-AzsLogicalNetwork -ResourceGroupName $ResourceGroup -Location $Location -Name $logicalNetwork.Name
				AssertLogicalNetworksAreSame -Expected $logicalNetwork -Found $retrieved
			}
		}
    }
}
