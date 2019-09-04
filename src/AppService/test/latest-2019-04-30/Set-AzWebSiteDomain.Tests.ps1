$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebSiteDomain.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebSiteDomain' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
