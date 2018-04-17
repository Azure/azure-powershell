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
    Run AzureStack Backup admin backup location test

.DESCRIPTION
    Run AzureStack Backup admin backup location tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Backup.Tests.ps1
    Describing Backups
	 [+] TestListBackups 81ms
	 [+] TestGetBackup 73ms

.NOTES
    Author: Microsoft
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
	[bool]$RunRaw = $false
)

$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Backup.Admin {

	Describe "Backup" -Tags @('Backup', 'Azs.Backup.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateBackup {
				param(
					[Parameter(Mandatory=$true)]
					$Backup
				)

				$Backup             | Should Not Be $null

				# Resource
				$Backup.Id          | Should Not Be $null
				$Backup.Name        | Should Not Be $null
				$Backup.Type        | Should Not Be $null

				# Subscriber Usage Aggregate
                $Backup.RoleStatus          | Should Not Be $null
                $Backup.CreatedDateTime     | Should Not Be $null
                $Backup.BackupId            | Should Not Be $null
                $Backup.Status              | Should Not Be $null
                $Backup.TimeTakenToCreate   | Should Not Be $null
			}
		}

		It "TestListBackups" {
			$global:TestName = 'TestListBackups'

			$backups = Get-AzsBackup -Location $global:Location
			$backups  | Should Not Be $null
			foreach($backup in $backups) {
			    $result = Get-AzsBackup -Location $global:Location -Name (Select-Name $backup.Name)
				ValidateBackup -Backup $result
			}
		}

		It "TestGetBackup" {
			$global:TestName = 'TestGetBackup'

			$backups = Get-AzsBackup -Location $global:Location
			$backups  | Should Not Be $null
			foreach($backup in $backups) {
			    $result = Get-AzsBackup -Location $global:Location -Name (Select-Name $backup.Name)
				ValidateBackup -Backup $result
			}
		}
	}
}
