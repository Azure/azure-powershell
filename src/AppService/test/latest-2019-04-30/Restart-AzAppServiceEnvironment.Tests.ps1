$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzAppServiceEnvironment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzAppServiceEnvironment' {
    It 'Reboot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RebootViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
