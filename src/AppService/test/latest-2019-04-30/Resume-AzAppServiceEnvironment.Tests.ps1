$TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzAppServiceEnvironment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Resume-AzAppServiceEnvironment' {
    It 'Resume' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
