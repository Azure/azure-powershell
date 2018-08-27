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
    Run AzureStack Compute admin managed disk migration tests.

.DESCRIPTION
    Run AzureStack Compute admin managed disk migration tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\DiskMigration.Tests.ps1
	Describing DiskMigrations
	 [+] TestDiskMigration 1.61s

.NOTES
    Author: Shanshan Wang
	Copyright: Microsoft
    Date:   July 11, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:Location = "local"
$global:TestName = ""
$global:TargetShare = "\\SU1FileServer.azurestack.local\SU1_ObjStore\"

InModuleScope Azs.Compute.Admin {

    Describe "DiskMigrations" -Tags @('DiskMigrations', 'Azs.Compute.Admin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateDiskMigration {
                param(
                    [Parameter(Mandatory = $true)]
                    $DiskMigration
                )

                $DiskMigration | Should Not Be $null
                $DiskMigration.Id | Should Not Be $null
                $DiskMigration.Type | Should Not Be $null
                $DiskMigration.Name | Should Not Be $null
                $DiskMigration.CreationTime | Should Not Be $null
				$DiskMigration.TargetShare | Should Not Be $null
				$DiskMigration.Status | Should Not Be $null
				$DiskMigration.Location | Should Not Be $null
				$DiskMigration.MigrationId | Should Not Be $null
            }
        }

        It "TestDiskMigration" {
            $global:TestName = 'TestDiskMigration'

            $disks = Get-AzsDisk -Location $global:Location
            $disks | Should Not Be $null
			$toMigrationDisks = @()
			foreach($disk in $disks)
            {
                if ($toMigrationDisks.Count -lt 3)
                {
                    $toMigrationDisks +=$disk;
                }
                else
                {
                    break;
                }
            }
			$migrationId = "ba0644a4-c2ed-4e3c-a167-089a32865297"; # this should be the same as session Records

            $migration = Start-AzsDiskMigrationJob -Location $global:Location -Name $migrationId -TargetShare $global:TargetShare -Disks $disks
			ValidateDiskMigration -DiskMigration $migration

			$migration = Stop-AzsDiskMigrationJob -Location $global:Location -Name $migration.MigrationId
			ValidateDiskMigration -DiskMigration $migration 

			$migrationFromGet = Get-AzsDiskMigrationJob -Location $global:Location -Name $migrationId
			ValidateDiskMigration -DiskMigration $migrationFromGet 

			$migrationList = Get-AzsDiskMigrationJob -Location $global:Location
			$migrationList | %{ValidateDiskMigration -DiskMigration $_ }

			$migrationSucceededList = Get-AzsDiskMigrationJob -Location $global:Location  -Status "Succeeded"
            $migrationSucceededList | %{ValidateDiskMigration -DiskMigration $_ }
        }

        It "TestDiskMigrationInvalidInput" {
            $global:TestName = 'TestDiskMigrationInvalidInput'

			$InvalidtTargetShare = "\\SU1FileServer.azurestack.local\SU1_ObjStore_Invalid\"
			$disks = @()
            $disks += Get-AzsDisk -Location $global:Location
            $disks | Should Not Be $null
			if($disks.Count -gt 0)
			{
				$toMigrationDisks = @($disks[0])
				$migrationId = "A50E9E6B-CFC2-4BC7-956B-0F7C35035DF2"; # This guid should be the same as the ones in sessionRecord
				{Start-AzsDiskMigrationJob -Location $global:Location -Name $migrationId -TargetShare $InvalidtTargetShare -Disks $toMigrationDisks} | Should throw
				{Get-AzsDiskMigrationJob -Location $global:Location -Name $migrationId }| Should throw
			}
        }
    }
}
