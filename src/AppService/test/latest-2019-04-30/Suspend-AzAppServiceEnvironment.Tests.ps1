$TestRecordingFile = Join-Path $PSScriptRoot 'Suspend-AzAppServiceEnvironment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Suspend-AzAppServiceEnvironment' {
    It 'Suspend' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SuspendViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
