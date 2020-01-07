$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsBackup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsBackup' {
    . $PSScriptRoot\Common.ps1

    AfterEach {
        $global:Client = $null
    }

    It "TestListBackups" -Skip:$('TestListBackups' -in $global:SkippedTests) {
        $global:TestName = 'TestListBackups'

        $backups = Get-AzsBackup
        $backups  | Should Not Be $null
        foreach ($backup in $backups) {
            ValidateBackup -Backup $backup
        }
    }

    It "TestGetBackup" -Skip:$('TestGetBackup' -in $global:SkippedTests) {
        $global:TestName = 'TestGetBackup'

        $backups = Get-AzsBackup
        $backups  | Should Not Be $null
        foreach ($backup in $backups) {
            $result = Get-AzsBackup -Name $backup.Name
            ValidateBackup -Backup $result
            AssertBackupsAreEqual -expected $backup -found $result
        }
    }

    It "TestGetBackupViaIdentity" -Skip:$('TestGetBackupViaIdentity' -in $global:SkippedTests) {
        $global:TestName = 'TestGetBackupViaIdentity'

        $backups = Get-AzsBackup
        $backups  | Should Not Be $null
        foreach ($backup in $backups) {
            $result = $backup | Get-AzsBackup
            ValidateBackup -Backup $result
            AssertBackupsAreEqual -expected $backup -found $result
        }
    }
}
