$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebAppFunction.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebAppFunction' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
