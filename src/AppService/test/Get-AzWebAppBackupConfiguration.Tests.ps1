$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Get-AzWebAppBackupConfiguration.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppBackupConfiguration' {
    It 'GetBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
