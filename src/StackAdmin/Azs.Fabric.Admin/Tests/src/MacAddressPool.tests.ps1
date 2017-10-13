﻿# ----------------------------------------------------------------------------------
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
    Run AzureStack fabric admin mac address pool tests.

.DESCRIPTION
    Run AzureStack fabric admin edge mac address pool using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\MacAddressPool.Tests.ps1
	Describing MacAddressPools
	 [+] TestListMacAddressPools 76ms
	 [+] TestGetMacAddressPool 64ms
	 [+] TestGetAllMacAddressPools 72ms

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

	Describe "MacAddressPools" -Tags @('MacAddressPool', 'Azs.Fabric.Admin') {

		BeforeEach  {
			
			. $PSScriptRoot\Common.ps1

			function ValidateMacAddressPool {
				param(
					[Parameter(Mandatory=$true)]
					$MacAddressPool
				)
			
				$MacAddressPool          | Should Not Be $null

				# Resource
				$MacAddressPool.Id       | Should Not Be $null
				$MacAddressPool.Location | Should Not Be $null
				$MacAddressPool.Name     | Should Not Be $null
				$MacAddressPool.Type     | Should Not Be $null

				# Mac Address Pool
				$MacAddressPool.NumberOfAllocatedMacAddresses  | Should Not Be $null
				$MacAddressPool.NumberOfAvailableMacAddresses  | Should Not Be $null
				$MacAddressPool.StartMacAddress                | Should Not Be $null
				$MacAddressPool.EndMacAddress                  | Should Not Be $null
			}

			function AssertMacAddressPoolsAreSame {
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
					
					# Mac Address Pool
					$Found.NumberOfAllocatedMacAddresses  | Should Be $Expected.NumberOfAllocatedMacAddresses
					$Found.NumberOfAvailableMacAddresses  | Should Be $Expected.NumberOfAvailableMacAddresses
					$Found.StartMacAddress                | Should Be $Expected.StartMacAddress
					$Found.EndMacAddress                  | Should Be $Expected.EndMacAddress

					if($Expected.Metadata -eq $null) {
						$Found.Metadata        | Should Be $null
					} else {
						$Found.Metadata        | Should Not Be $null
						$Found.Metadata.Count  | Should Be $Expected.Metadata.Count
					}
				}
			}
		}
	
		
		It "TestListMacAddressPools" {
			$global:TestName = 'TestListMacAddressPools'
			$macAddressPools = Get-AzsMacAddressPool -Location $Location
			$macAddressPools | Should Not Be $null
			foreach($macAddressPool in $macAddressPools) {
				ValidateMacAddressPool -MacAddressPool $macAddressPool
			}
	    }
	
	
		It "TestGetMacAddressPool" {
            $global:TestName = 'TestGetMacAddressPool'

			$macAddressPools = Get-AzsMacAddressPool -Location $Location
			foreach($macAddressPool in $macAddressPools) {
				$retrieved = Get-AzsMacAddressPool -Location $Location -MacAddressPool $macAddressPool.Name
				AssertMacAddressPoolsAreSame -Expected $macAddressPool -Found $retrieved
				break
			}
		}

		It "TestGetAllMacAddressPools" {
			$global:TestName = 'TestGetAllMacAddressPools'

			$macAddressPools = Get-AzsMacAddressPool -Location $Location
			foreach($macAddressPool in $macAddressPools) {
				$retrieved = Get-AzsMacAddressPool -Location $Location -MacAddressPool $macAddressPool.Name
				AssertMacAddressPoolsAreSame -Expected $macAddressPool -Found $retrieved
			}
		}
    }
}