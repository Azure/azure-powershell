$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWebAppConfigurationSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzWebAppConfigurationSlot' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
