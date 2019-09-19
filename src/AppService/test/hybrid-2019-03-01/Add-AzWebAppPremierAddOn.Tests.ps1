$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzWebAppPremierAddOn.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzWebAppPremierAddOn' {
    It 'AddExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Add' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
