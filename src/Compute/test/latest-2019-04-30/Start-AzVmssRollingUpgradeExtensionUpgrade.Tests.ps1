$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzVmssRollingUpgradeExtensionUpgrade.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzVmssRollingUpgradeExtensionUpgrade' {
    It 'Start' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
