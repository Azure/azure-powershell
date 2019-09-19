$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Restart-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzWebApp' {
    It 'RestartBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
