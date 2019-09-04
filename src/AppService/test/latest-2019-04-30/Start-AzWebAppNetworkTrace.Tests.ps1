$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppNetworkTrace.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzWebAppNetworkTrace' {
    It 'Start' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
