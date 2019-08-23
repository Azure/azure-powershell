$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzVmssRollingOSUpgrade.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzVmssRollingOSUpgrade' {
    It 'Start1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
