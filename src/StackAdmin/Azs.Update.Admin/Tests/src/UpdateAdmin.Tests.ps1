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
    Run AzureStack Update admin tests.

.DESCRIPTION
    Run AzureStack Update admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
	PS C:\> .\src\UpdateAdmin.Tests.ps1

	Describing UpdateAdminTests
	  [+] TestGetUpdateLocation 1.2s
	  [+] TestListUpdate 4.12s
	  [+] TestGetUdate 4.51s
	  [+] TestListUpdateRun 3.96s
	  [+] TestGetUpdateRun 4.97s

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 15, 2018
#>
param(
	[bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Update.Admin {

	Describe "UpdateAdminTests" -Tags @('UpdateAdminTests', 'Azs.Update.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateUpdateLocation {
				param(
					[Parameter(Mandatory=$true)]
					$location
				)

				$location                   | Should Not Be $null
				$location.Id                | Should Not Be $null
				$location.CurrentOemVersion | Should Not Be $null
				$location.CurrentVersion    | Should Not Be $null
				$location.State             | Should Not Be $null
			}

			function ValidateSameUpdateLocation {
				param(
					[Parameter(Mandatory=$true)]
					$location1,
					[Parameter(Mandatory=$true)]
					$location2
				)

				$location1                   | Should Not Be $null
				$location2                   | Should Not Be $null
				$location1.Id                | Should Be $location2.Id
				$location1.CurrentOemVersion | Should Be $location2.CurrentOemVersion
				$location1.CurrentVersion    | Should Be $location2.CurrentVersion
				$location1.State             | Should Be $location2.State
			}

			function ValidateUpdate {
				param(
					[Parameter(Mandatory=$true)]
					$update
				)

				$update                       | Should Not Be $null
				$update.Id                    | Should Not Be $null
				$update.DateAvailable         | Should Not Be $null
				$update.Description           | Should Not Be $null
				$update.KbLink                | Should Not Be $null
				$update.MinVersionRequired    | Should Not Be $null
				$update.PackagePath           | Should Not Be $null
				$update.PackageSizeInMb       | Should Not Be $null
				$update.PackageType           | Should Not Be $null
				$update.Publisher             | Should Not Be $null
				$update.State                 | Should Not Be $null
				$update.UpdateName            | Should Not Be $null
				$update.UpdateOemFile         | Should Not Be $null
				$update.Version               | Should Not Be $null
			}

			function ValidateSameUpdate {
				param(
					[Parameter(Mandatory=$true)]
					$update1,
					[Parameter(Mandatory=$true)]
					$update2
				)

				$update1                      | Should Not Be $null
				$update2                      | Should Not Be $null
				$update1.Id                   | Should Be $update2.Id
				$update1.DateAvailable        | Should Be $update2.DateAvailable
				$update1.Description          | Should Be $update2.Description
				$update1.KbLink               | Should Be $update2.KbLink
				$update1.MinVersionRequired   | Should Be $update2.MinVersionRequired
				$update1.PackagePath          | Should Be $update2.PackagePath
				$update1.PackageSizeInMb      | Should Be $update2.PackageSizeInMb
				$update1.PackageType          | Should Be $update2.PackageType
				$update1.Publisher            | Should Be $update2.Publisher
				$update1.State                | Should Be $update2.State
				$update1.UpdateName           | Should Be $update2.UpdateName
				$update1.UpdateOemFile        | Should Be $update2.UpdateOemFile
				$update1.Version              | Should Be $update2.Version
			}

			function ValidateUpdateRun {
				param(
					[Parameter(Mandatory=$true)]
					$run
				)

				$run                          | Should Not Be $null
				$run.Id                       | Should Not Be $null
				$run.Duration                 | Should Not Be $null
				$run.State                    | Should Not Be $null
				$run.TimeStarted              | Should Not Be $null
				$run.Location                 | Should Not Be $null
			}

			function ValidateSameUpdateRun {
				param(
					[Parameter(Mandatory=$true)]
					$run1,
					[Parameter(Mandatory=$true)]
					$run2
				)

				$run1                          | Should Not Be $null
				$run2                          | Should Not Be $null
				$run1.Id                       | Should Be $run2.Id
				$run1.Duration                 | Should Be $run2.Duration
				$run1.State                    | Should Be $run2.State
				$run1.TimeStarted              | Should Be $run2.TimeStarted
				$run1.Location                 | Should Be $run2.Location
			}
		}

		It "TestGetUpdateLocation" {
			$global:TestName = "TestGetUpdateLocation"

			$list = Get-AzsUpdateLocation -ResourceGroup System.Redmond -Location redmond
			foreach ($location in $list) {
				$location1 = Get-AzsUpdateLocation -Location $location.Name -ResourceGroup System.Redmond
				ValidateSameUpdateLocation $location $location1
			}
		}

		It "TestListUpdates" {
			$global:TestName = "TestListUpdates"

			$list = Get-AzsUpdate -ResourceGroup System.Redmond -Location redmond
			$list | Should Not Be $null
			foreach ($update in $list) {
				ValidateUpdate $update
			}
		}

		It "TestGetUdate" {
			$global:TestName = "TestGetUpdate"

			$list = Get-AzsUpdate -ResourceGroup System.Redmond -Location redmond
			foreach ($update in $list)
			{
				$update1 = Get-AzsUpdate -Name $update.Name -ResourceGroup System.Redmond -Location redmond
				ValidateSameUpdate $update $update1
			}
		}

		It "TestListUpdateRuns" {
			$global:TestName = "TestListUpdateRuns"

			$list = Get-AzsUpdate -ResourceGroup System.Redmond -Location redmond
			foreach ($update in $list)
			{
				$runList = Get-AzsUpdateRun -UpdateName $update.Name -ResourceGroup System.Redmond -Location redmond
				foreach ($run in $runList)
				{
					ValidateUpdateRun $run
				}
			}
		}

		It "TestGetUpdateRun" {
			$global:TestName = "TestGetUpdateRun"

			$list = Get-AzsUpdate -ResourceGroup System.Redmond -Location redmond
			foreach ($update in $list)
			{
				$update | fl
				$runList = Get-AzsUpdateRun -UpdateName $update.Name -ResourceGroup System.Redmond -Location redmond
				foreach ($run in $runList)
				{
					$run1 = Get-AzsUpdateRun -Name $run.Name -ResourceGroup System.Redmond -Location redmond -UpdateName $update.Name
					ValidateSameUpdateRun $run $run1
				}
			}
		}
	}
}
