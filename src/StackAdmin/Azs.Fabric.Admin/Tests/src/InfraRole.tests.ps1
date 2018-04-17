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
    Run AzureStack fabric admin InfrastructureRole tests.

.DESCRIPTION
    Run AzureStack fabric admin InfrastructureRole tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\InfrastructureRole.Tests.ps1
	Describing InfrastructureRoles
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

	Describe "InfrastructureRoles" -Tags @('InfrastructureRole', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateInfrastructureRole {
				param(
					[Parameter(Mandatory=$true)]
					$InfrastructureRole
				)

				$InfrastructureRole          | Should Not Be $null

				# Resource
				$InfrastructureRole.Id       | Should Not Be $null
				$InfrastructureRole.Location | Should Not Be $null
				$InfrastructureRole.Name     | Should Not Be $null
				$InfrastructureRole.Type     | Should Not Be $null

				# Infra Role
				$InfrastructureRole.Instances | Should Not be $null
				$InfrastructureRole.Instances.Count | Should Not be 0

			}

			function AssertInfrastructureRolesAreSame {
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
			$InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $ResourceGroup -Location $Location
			$InfrastructureRoles | Should Not Be $null
			foreach($InfrastructureRole in $InfrastructureRoles) {
				ValidateInfrastructureRole -InfrastructureRole $InfrastructureRole
			}
	    }

		It "TestGetInfraRole" {
            $global:TestName = 'TestGetInfraRole'

			$InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $ResourceGroup -Location $Location
			foreach($InfrastructureRole in $InfrastructureRoles) {
				$retrieved = Get-AzsInfrastructureRole -ResourceGroupName $ResourceGroup -Location $Location -Name $InfrastructureRole.Name
				AssertInfrastructureRolesAreSame -Expected $InfrastructureRole -Found $retrieved
				break
			}
		}

		It "TestGetAllInfraRoles" {
			$global:TestName = 'TestGetAllInfraRoles'

			$InfrastructureRoles = Get-AzsInfrastructureRole -ResourceGroupName $ResourceGroup -Location $Location
			foreach($InfrastructureRole in $InfrastructureRoles) {
				$name = $InfrastructureRole.Name
				$check = -not ($name -like "*User*" -or $name -like "*Administrator*")
				if($check) {
					$retrieved = Get-AzsInfrastructureRole -ResourceGroupName $ResourceGroup -Location $Location -Name $InfrastructureRole.Name
					AssertInfrastructureRolesAreSame -Expected $InfrastructureRole -Found $retrieved
				}
			}
		}

    }
}
