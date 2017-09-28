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
    Run AzureStack fabric admin infrarole tests.

.DESCRIPTION
    Run AzureStack fabric admin infrarole tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\InfraRole.Tests.ps1
	Describing InfraRoles
	 [+] TestListInfraRoles 438ms
	 [+] TestGetInfraRole 107ms
	 [+] TestGetAllInfraRoles 0.99s

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

	Describe "InfraRoles" -Tags @('InfraRole', 'Azs.Fabric.Admin') {

		BeforeEach  {
			
			. $PSScriptRoot\Common.ps1

			function ValidateInfraRole {
				param(
					[Parameter(Mandatory=$true)]
					$InfraRole
				)
			
				$InfraRole          | Should Not Be $null

				# Resource
				$InfraRole.Id       | Should Not Be $null
				$InfraRole.Location | Should Not Be $null
				$InfraRole.Name     | Should Not Be $null
				$InfraRole.Type     | Should Not Be $null

				# Infra Role
				$InfraRole.Instances | Should Not be $null
				$InfraRole.Instances.Count | Should Not be 0

			}

			function AssertInfraRolesAreSame {
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

					# Infra Role
					$Found.Instances.Count| Should Be $Expected.Instances.Count

				}
			}
		}
		
		It "TestListInfraRoles" {
			$global:TestName = 'TestListInfraRoles'
			$infraRoles = Get-AzsInfraRole -Location $Location
			$infraRoles | Should Not Be $null
			foreach($infraRole in $infraRoles) {
				ValidateInfraRole -InfraRole $infraRole
			}
	    }
	
		It "TestGetInfraRole" {
            $global:TestName = 'TestGetInfraRole'

			$infraRoles = Get-AzsInfraRole -Location $Location
			foreach($infraRole in $infraRoles) {
				$retrieved = Get-AzsInfraRole -Location $Location -InfraRole $infraRole.Name
				AssertInfraRolesAreSame -Expected $infraRole -Found $retrieved
				break
			}
		}

		It "TestGetAllInfraRoles" {
			$global:TestName = 'TestGetAllInfraRoles'

			$infraRoles = Get-AzsInfraRole -Location $Location
			foreach($infraRole in $infraRoles) {
				$name = $infraRole.Name
				$check = -not ($name -like "*User*" -or $name -like "*Administrator*")
				if($check) {
					$retrieved = Get-AzsInfraRole -Location $Location -InfraRole $infraRole.Name
					AssertInfraRolesAreSame -Expected $infraRole -Found $retrieved
				}
			}
		}

    }
}