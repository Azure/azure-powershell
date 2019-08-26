$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzWebSiteGlobalHostingEnvironmentNameAvailable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzWebSiteGlobalHostingEnvironmentNameAvailable' {
    It 'Is' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IsViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
