$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Remove-AzWebAppBackup.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebAppBackup' {
    It 'DeleteBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
