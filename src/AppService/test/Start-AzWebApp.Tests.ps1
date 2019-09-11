$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Start-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzWebApp' {
    It 'StartBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
