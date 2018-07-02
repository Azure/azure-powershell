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
    Run AzureStack fabric admin fabric location tests.

.DESCRIPTION
    Run AzureStack fabric admin fabric location tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\FabricLocation.Tests.ps1
	Describing FabricLocations
	 [+] TestListFabricLocations 103ms
	 [+] TestGetFabricLocation 101ms
	 [+] TestGetAllFabricLocations 64ms

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

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Fabric.Admin {

	Describe "FabricLocations" -Tags @('FabricLocation', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateFabricLocation {
				param(
					[Parameter(Mandatory=$true)]
					$FabricLocation
				)

				$FabricLocation          | Should Not Be $null

				# Resource
				$FabricLocation.Id       | Should Not Be $null
				$FabricLocation.Location | Should Not Be $null
				$FabricLocation.Name     | Should Not Be $null
				$FabricLocation.Type     | Should Not Be $null

			}

			function AssertFabricLocationsAreSame {
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

				}
			}
		}

		It "TestListFabricLocations" {
			$global:TestName = 'TestListFabricLocations'
			$fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $ResourceGroup
			$fabricLocations | Should Not Be $null
			foreach($fabricLocation in $fabricLocations) {
				ValidateFabricLocation -FabricLocation $fabricLocation
			}
	    }

		It "TestGetFabricLocation" {
            $global:TestName = 'TestGetFabricLocation'

			$fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $ResourceGroup
			foreach($fabricLocation in $fabricLocations) {
				$retrieved = Get-AzsInfrastructureLocation -ResourceGroupName $ResourceGroup -Location $fabricLocation.Name
				AssertFabricLocationsAreSame -Expected $fabricLocation -Found $retrieved
				break
			}
		}

		It "TestGetAllFabricLocations" {
			$global:TestName = 'TestGetAllFabricLocations'

			$fabricLocations = Get-AzsInfrastructureLocation -ResourceGroupName $ResourceGroup
			foreach($fabricLocation in $fabricLocations) {
				$retrieved = Get-AzsInfrastructureLocation -ResourceGroupName $ResourceGroup -Location $fabricLocation.Name
				AssertFabricLocationsAreSame -Expected $fabricLocation -Found $retrieved
			}
		}
    }
}
