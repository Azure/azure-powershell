$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Remove-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebApp' {
    It 'DeleteBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
