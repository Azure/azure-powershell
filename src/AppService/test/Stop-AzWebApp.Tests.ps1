$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Stop-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzWebApp' {
    It 'StopBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
