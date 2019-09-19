$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzWebAppSlotConfigToProduction.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzWebAppSlotConfigToProduction' {
    It 'ApplyExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Apply' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplyViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApplyViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
