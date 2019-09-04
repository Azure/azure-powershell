$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Restore-AzWebAppSnapshot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzWebAppSnapshot' {
    It 'RestoreBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
