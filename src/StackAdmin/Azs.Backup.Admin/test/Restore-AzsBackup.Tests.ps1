$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzsBackup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzsBackup' {
    . $PSScriptRoot\Common.ps1

    AfterEach {
        $global:Client = $null
    }

    It "TestRestoreBackupExpanded" -Skip:$('TestRestoreBackupExpanded' -in $global:SkippedTests) {
        $global:TestName = 'TestRestoreBackupExpanded'

        $backup = Start-AzsBackup -Force
        $backup | Should Not Be $Null

        try
        {
            [System.IO.File]::WriteAllBytes($global:decryptionCertPath, [System.Convert]::FromBase64String($global:decryptionCertBase64))
            Restore-AzsBackup -Name $backup.Name -DecryptionCertPath $global:decryptionCertPath -DecryptionCertPassword $global:decryptionCertPassword -Force
        }
        finally
        {
            if (Test-Path -Path $global:decryptionCertPath -PathType Leaf)
            {
                Remove-Item -Path $global:decryptionCertPath -Force -ErrorAction Continue
            }
        }
    }

    It "TestRestoreBackupViaIdentityExpanded" -Skip:$('TestRestoreBackupViaIdentityExpanded' -in $global:SkippedTests) {
        $global:TestName = 'TestRestoreBackupViaIdentityExpanded'

        $backup = Start-AzsBackup -Force
        $backup | Should Not Be $Null

        try
        {
            [System.IO.File]::WriteAllBytes($global:decryptionCertPath, [System.Convert]::FromBase64String($global:decryptionCertBase64))
            $backup | Restore-AzsBackup -DecryptionCertPath $global:decryptionCertPath -DecryptionCertPassword $global:decryptionCertPassword -Force
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
