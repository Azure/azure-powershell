$TestRecordingFile = Join-Path $PSScriptRoot 'Rename-AzAppServiceEnvironmentVnet.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Rename-AzAppServiceEnvironmentVnet' {
    It 'ChangeExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Change' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ChangeViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ChangeViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
