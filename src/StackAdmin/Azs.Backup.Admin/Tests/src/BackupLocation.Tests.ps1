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
    PS C:\> .\src\BackupLocation.Tests.ps1
    Describing BackupLocations
  		[+] TestListBackupLocations 630ms
  		[+] TestGetBackupLocation 11ms
  		[+] TestGetAllBackupLocation 630ms
  		[+] TestUpdateBackupLocation 11ms
		[+] TestCreateBackup
		[+] TestRestoreBackup

.NOTES
    Author: Microsoft
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

InModuleScope Azs.Backup.Admin {

	Describe "BackupLocations" -Tags @('BackupLocation', 'Azs.Backup.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateBackupLocation {
				param(
					[Parameter(Mandatory=$true)]
					$BackupLocation
				)

				$BackupLocation          | Should Not Be $null

				# Resource
				$BackupLocation.Id			| Should Not Be $null
				$BackupLocation.Name		| Should Not Be $null
				$BackupLocation.Type		| Should Not Be $null
				$BackupLocation.Location    | Should Not Be $null

				# Subscriber Usage Aggregate
				$BackupLocation.Password    			| Should Be $null
				$BackupLocation.EncryptionKeyBase64     | Should Be $null
			}

			function AssertAreEqual {
				param(
					[Parameter(Mandatory=$true)]
					$expected,
					[Parameter(Mandatory=$true)]
					$found
				)
				# Resource
				if($expected -eq $null){
					$found												    | Should Be $null
				}
				else{
					$found												    | Should Not Be $null
					# Validate Farm properties
					$expected.Id							| Should Be $found.Id
					$expected.Type							| Should Be $found.Type
					$expected.Name							| Should Be $found.Name
					$expected.Location						| Should Be $found.Location
					$expected.AvailableCapacity				| Should Be $found.AvailableCapacity
					$expected.BackupFrequencyInHours		| Should Be $found.BackupFrequencyInHours
					$expected.EncryptionKeyBase64			| Should Be $found.EncryptionKeyBase64
					$expected.IsBackupSchedulerEnabled		| Should Be $found.IsBackupSchedulerEnabled
					$expected.LastBackupTime				| Should Be $found.LastBackupTime
					$expected.NextBackupTime				| Should Be $found.NextBackupTime
					$expected.LastBackupTime				| Should Be $found.LastBackupTime
					$expected.Password						| Should Be $found.Password
					$expected.Path							| Should Be $found.Path
					$expected.UserName						| Should Be $found.UserName
				}
			}
		}

		It "TestListBackupLocation" {
			$global:TestName = 'TestListBackupLocations'

			$backupLocations = Get-AzsBackupLocation -Location $global:Location
			$backupLocations  | Should Not Be $null
			foreach($backupLocation in $backupLocations) {
				ValidateBackupLocation -BackupLocation $backupLocation
			}
		}

		It "TestGetBackupLocation" {
			$global:TestName = 'TestGetBackupLocation'

			$backupLocations = Get-AzsBackupLocation -Location $global:Location
			$backupLocations  | Should Not Be $null
			foreach($backupLocation in $backupLocations) {
			    $result = Get-AzsBackupLocation -Location (Select-Name $backupLocation.Name)
				ValidateBackupLocation -BackupLocation $result
				AssertAreEqual -expected $backupLocation -found $result
			}
		}

		It "TestGetAllBackupLocation" {
			$global:TestName = 'TestGetAllBackupLocation'

			$backupLocations = Get-AzsBackupLocation -Location $global:Location
			$backupLocations  | Should Not Be $null
			foreach($backupLocation in $backupLocations) {
			    $result = Get-AzsBackupLocation -Location (Select-Name $backupLocation.Name)
				ValidateBackupLocation -BackupLocation $result
				AssertAreEqual -expected $backupLocation -found $result
			}
		}

		It "TestUpdateBackupLocation" {
			$global:TestName = 'TestUpdateBackupLocation'

			[String]$username = "azurestack\AzureStackAdmin"
			[SecureString]$password = ConvertTo-SecureString -String "password" -AsPlainText -Force
			[String]$path = "\\192.168.1.1\Share"
			[SecureString]$encryptionKey = ConvertTo-SecureString -String "YVVOa0J3S2xTamhHZ1lyRU9wQ1pKQ0xWanhjaHlkaU5ZQnNDeHRPTGFQenJKdWZsRGtYT25oYmlaa1RMVWFKeQ==" -AsPlainText -Force

			$backup = Set-AzsBackupShare -ResourceGroupName $global:ResourceGroup -Location $global:Location -Username $username -Password $password -BackupShare $path -EncryptionKey $encryptionKey -Force

			$backup 					| Should Not Be $Null
			$backup.Path 				| Should Be $path
			$backup.Username 			| Should be $username
			$backup.Password 			| Should be ""
			$backup.EncryptionKeyBase64 | Should be ""
		}

		# Need to record new tests.
		It "TestCreateBackup" -Skip {
			$global:TestName = 'TestCreateBackup'

			$backup = Start-AzsBackup -ResourceGroupName $global:ResourceGroup -Location $global:Location -Force
			$backup 					| Should Not Be $Null

		}

		It "TestRestoreBackup" -Skip {
			$global:TestName = 'TestRestoreBackup'

			[String]$username = "azurestack\AzureStackAdmin"
			[SecureString]$password = ConvertTo-SecureString -String "password" -AsPlainText -Force
			[String]$path = "\\su1fileserver\SU1_Infrastructure_2"
			[SecureString]$encryptionKey = ConvertTo-SecureString -String "YVVOa0J3S2xTamhHZ1lyRU9wQ1pKQ0xWanhjaHlkaU5ZQnNDeHRPTGFQenJKdWZsRGtYT25oYmlaa1RMVWFKeQ==" -AsPlainText -Force

			$backup = Set-AzsBackupShare -ResourceGroupName $global:ResourceGroup -Location $global:ResourceGroup -Username $username -Password $password -BackupShare $path -EncryptionKey $encryptionKey -Force

			$backup 					| Should Not Be $Null
			Restore-AzsBackup -ResourceGroupName $global:ResourceGroup -Location $global:ResourceGroup -Backup (Select-Name $backup.Name)
		}
	}
}
