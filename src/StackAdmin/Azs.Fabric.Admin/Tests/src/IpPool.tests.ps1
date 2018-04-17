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
    Run AzureStack fabric admin ip pool tests.

.DESCRIPTION
    Run AzureStack fabric admin ip pool tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\IpPool.Tests.ps1
	Describing IpPools
	  [+] TestListIpPools 197ms
	  [+] TestGetIpPool 75ms
	  [+] TestGetAllIpPools 289ms
	  [!] TestCreateIpPool 4ms

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

	Describe "IpPools" -Tags @('IpPool', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateIpPool {
				param(
					[Parameter(Mandatory=$true)]
					$IpPool
				)

				$IpPool          | Should Not Be $null

				# Resource
				$IpPool.Id       | Should Not Be $null
				$IpPool.Location | Should Not Be $null
				$IpPool.Name     | Should Not Be $null
				$IpPool.Type     | Should Not Be $null

				# IpPool
				$IpPool.EndIpAddress                     | Should not be $null
				$IpPool.NumberOfAllocatedIpAddresses     | Should not be $null
				$IpPool.NumberOfIpAddresses              | Should not be $null
				$IpPool.NumberOfIpAddressesInTransition  | Should not be $null
				$IpPool.StartIpAddress                   | Should not be $null

			}

			function AssertIpPoolsAreSame {
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

					# IpPool
					$Found.EndIpAddress                     | Should Be $Expected.EndIpAddress
					$Found.NumberOfAllocatedIpAddresses     | Should Be $Expected.NumberOfAllocatedIpAddresses
					$Found.NumberOfIpAddresses              | Should Be $Expected.NumberOfIpAddresses
					$Found.NumberOfIpAddressesInTransition  | Should Be $Expected.NumberOfIpAddressesInTransition
					$Found.StartIpAddress                   | Should Be $Expected.StartIpAddress

				}
			}
		}

		It "TestListIpPools" {
			$global:TestName = 'TestListIpPools'
			$IpPools = Get-AzsIpPool -ResourceGroupName $ResourceGroup -Location $Location
			$IpPools | Should not be $null
			foreach($IpPool in $IpPools) {
				ValidateIpPool -IpPool $IpPool
			}
	    }

		It "TestGetIpPool" {
            $global:TestName = 'TestGetIpPool'

			$IpPools = Get-AzsIpPool -ResourceGroupName $ResourceGroup -Location $Location
			if($IpPools -and $IpPools.Count -gt 0) {
				$IpPool = $IpPools[0]
				$retrieved = Get-AzsIpPool -ResourceGroupName $ResourceGroup -Location $Location -Name $IpPool.Name
				AssertIpPoolsAreSame -Expected $IpPool -Found $retrieved
			}
		}

		It "TestGetAllIpPools" {
			$global:TestName = 'TestGetAllIpPools'

			$IpPools = Get-AzsIpPool -ResourceGroupName $ResourceGroup -Location $Location
			foreach($IpPool in $IpPools) {
				$retrieved = Get-AzsIpPool -ResourceGroupName $ResourceGroup -Location $Location -Name $IpPool.Name
				AssertIpPoolsAreSame -Expected $IpPool -Found $retrieved
			}
		}


		It "TestCreateIpPool" -Skip {
			$global:TestName = 'TestCreateIpPool'

			$Name = "okaytodelete"
			$StartIpAddress = "192.168.99.1"
			$EndIpAddress = "192.168.99.254"
			$AddressPrefix = "192.168.99.0/24"


			$params = @($Location, $ResourceGroup, $Name, $StartIpAddress, $EndIpAddress, $AddressPrefix)
			$ipPool = New-AzsIpPool @params

			$ipPool | Should not be $null
		}
    }
}
