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
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Backup.Admin {

    Describe "BackupLocations" -Tags @('BackupLocation', 'Azs.Backup.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateBackupLocation {
                param(
                    [Parameter(Mandatory = $true)]
                    $BackupLocation
                )

                $BackupLocation          | Should Not Be $null

                # Resource
                $BackupLocation.Id          | Should Not Be $null
                $BackupLocation.Name        | Should Not Be $null
                $BackupLocation.Type        | Should Not Be $null
                $BackupLocation.Location    | Should Not Be $null

                # Subscriber Usage Aggregate
                $BackupLocation.Password                 | Should -BeNullOrEmpty
                $BackupLocation.EncryptionCertBase64     | Should -BeNullOrEmpty
            }

            function AssertAreEqual {
                param(
                    [Parameter(Mandatory = $true)]
                    $expected,
                    [Parameter(Mandatory = $true)]
                    $found
                )
                # Resource
                if ($null -eq $expected) {
                    $found                                                    | Should Be $null
                }
                else {
                    $found                                                    | Should Not Be $null
                    # Validate Farm properties
                    $expected.Id                              | Should Be $found.Id
                    $expected.Type                            | Should Be $found.Type
                    $expected.Name                            | Should Be $found.Name
                    $expected.Location                        | Should Be $found.Location
                    $expected.AvailableCapacity               | Should Be $found.AvailableCapacity
                    $expected.BackupFrequencyInHours          | Should Be $found.BackupFrequencyInHours
                    $expected.EncryptionCertBase64            | Should Be $found.EncryptionCertBase64
                    $expected.IsBackupSchedulerEnabled        | Should Be $found.IsBackupSchedulerEnabled
                    $expected.LastBackupTime                  | Should Be $found.LastBackupTime
                    $expected.NextBackupTime                  | Should Be $found.NextBackupTime
                    $expected.LastBackupTime                  | Should Be $found.LastBackupTime
                    $expected.Password                        | Should Be $found.Password
                    $expected.Path                            | Should Be $found.Path
                    $expected.UserName                        | Should Be $found.UserName
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListBackupLocation" -Skip:$('TestListBackupLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestListBackupLocations'

            $backupLocations = Get-AzsBackupConfiguration -ResourceGroupName $global:ResourceGroupName
            $backupLocations  | Should Not Be $null
            foreach ($backupLocation in $backupLocations) {
                ValidateBackupLocation -BackupLocation $backupLocation
            }
        }

        It "TestGetBackupLocation" -Skip:$('TestGetBackupLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestGetBackupLocation'

            $backupLocations = Get-AzsBackupConfiguration -ResourceGroupName $global:ResourceGroupName
            $backupLocations  | Should Not Be $null
            foreach ($backupLocation in $backupLocations) {
                $result = Get-AzsBackupConfiguration -Location $backupLocation.Name
                ValidateBackupLocation -BackupLocation $result
                AssertAreEqual -expected $backupLocation -found $result
            }
        }

        It "TestGetAllBackupLocation" -Skip:$('TestGetAllBackupLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllBackupLocation'

            $backupLocations = Get-AzsBackupConfiguration -ResourceGroupName $global:ResourceGroupName
            $backupLocations  | Should Not Be $null
            foreach ($backupLocation in $backupLocations) {
                $result = Get-AzsBackupConfiguration -Location $backupLocation.Name
                ValidateBackupLocation -BackupLocation $result
                AssertAreEqual -expected $backupLocation -found $result
            }
        }

        It "TestUpdateBackupLocation" -Skip:$('TestUpdateBackupLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestUpdateBackupLocation'

            try
            {
                [System.IO.File]::WriteAllBytes($global:encryptionCertPath, [System.Convert]::FromBase64String($global:encryptionCertBase64))
                $backup = Set-AzsBackupConfiguration -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Username $global:username -Password $global:password -Path $global:path -EncryptionCertPath $global:encryptionCertPath -IsBackupSchedulerEnabled $global:isBackupSchedulerEnabled -BackupFrequencyInHours $global:backupFrequencyInHours -BackupRetentionPeriodInDays $global:backupRetentionPeriodInDays

                $backup                             | Should Not Be $Null
                $backup.Path                        | Should Be $global:path
                $backup.Username                    | Should be $global:username
                $backup.Password                    | Should -BeNullOrEmpty
                $backup.EncryptionCertBase64        | Should -BeNullOrEmpty
                $backup.IsBackupSchedulerEnabled    | Should be $global:isBackupSchedulerEnabled
                $backup.BackupFrequencyInHours      | Should be $global:backupFrequencyInHours
                $backup.BackupRetentionPeriodInDays | Should be $global:backupRetentionPeriodInDays
            }
            finally
            {
                if (Test-Path -Path $global:encryptionCertPath -PathType Leaf)
                {
                    Remove-Item -Path $global:encryptionCertPath -Force -ErrorAction Continue
                }
            }
        }

        It "TestCreateBackup" -Skip:$('TestCreateBackup' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateBackup'

            $backup = Start-AzsBackup -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Force
            $backup                     | Should Not Be $Null

        }

        It "TestRestoreBackup" -Skip:$('TestRestoreBackup' -in $global:SkippedTests) {
            $global:TestName = 'TestRestoreBackup'

            $backup = Start-AzsBackup -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Force
            $backup                     | Should Not Be $Null

            try
            {
                [System.IO.File]::WriteAllBytes($global:decryptionCertPath, [System.Convert]::FromBase64String($global:decryptionCertBase64))
                Restore-AzsBackup -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $backup.Name -DecryptionCertPath $global:decryptionCertPath -DecryptionCertPassword $global:decryptionCertPassword -Force
            }
            finally
            {
                if (Test-Path -Path $global:decryptionCertPath -PathType Leaf)
                {
                    Remove-Item -Path $global:decryptionCertPath -Force -ErrorAction Continue
                }
            }
        }
    }
}
