$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebAppHybridConnection.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebAppHybridConnection' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
