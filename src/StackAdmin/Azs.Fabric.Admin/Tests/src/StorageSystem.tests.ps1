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
    Run AzureStack fabric admin storage system tests.

.DESCRIPTION
    Run AzureStack fabric admin storage system tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\StorageSystem.Tests.ps1
	Describing StorageSystems
	 [+] TestListStorageSystems 143ms
	 [+] TestGetStorageSystem 91ms
	 [+] TestGetAllStorageSystems 71ms

.EXAMPLE
    C:\PS> .\src\StorageSystem.Tests.ps1 -RunRaw $true
	Describing StorageSystems
	 [+] TestListStorageSystems 1.79s
	 [+] TestGetStorageSystem 2.37s
	 [+] TestGetAllStorageSystems 1.82s

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

	Describe "StorageSystems" -Tags @('StorageSystem', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateStorageSystem {
				param(
					[Parameter(Mandatory=$true)]
					$StorageSystem
				)
			
				$StorageSystem          | Should Not Be $null

				# Resource
				$StorageSystem.Id       | Should Not Be $null
				$StorageSystem.Location | Should Not Be $null
				$StorageSystem.Name     | Should Not Be $null
				$StorageSystem.Type     | Should Not Be $null

				# Storage System
				$StorageSystem.TotalCapacityGB  | Should Not Be $null
			}

			function AssertStorageSystemsAreSame {
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

					# Storage System
					$Found.TotalCapacityGB  | Should Be $Expected.TotalCapacityGB
				}
			}
		}
	
		
		It "TestListStorageSystems" {
			$global:TestName = 'TestListStorageSystems'
			$StorageSystems = Get-AzsStorageSystem -Location $Location
			$StorageSystems | Should Not Be $null
			foreach($StorageSystem in $StorageSystems) {
				ValidateStorageSystem -StorageSystem $StorageSystem
			}
	    }
	
	
		It "TestGetStorageSystem" {
            $global:TestName = 'TestGetStorageSystem'

			$StorageSystems = Get-AzsStorageSystem -Location $Location
			foreach($StorageSystem in $StorageSystems) {
				$retrieved = Get-AzsStorageSystem -Location $Location -StorageSubSystem $StorageSystem.Name
				AssertStorageSystemsAreSame -Expected $StorageSystem -Found $retrieved
				break
			}
		}

		It "TestGetAllStorageSystems" {
			$global:TestName = 'TestGetAllStorageSystems'

			$StorageSystems = Get-AzsStorageSystem -Location $Location
			foreach($StorageSystem in $StorageSystems) {
				$retrieved = Get-AzsStorageSystem -Location $Location -StorageSubSystem $StorageSystem.Name
				AssertStorageSystemsAreSame -Expected $StorageSystem -Found $retrieved
			}
		}
    }
}