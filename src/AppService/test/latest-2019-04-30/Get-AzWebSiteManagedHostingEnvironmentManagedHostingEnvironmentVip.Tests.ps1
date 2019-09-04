$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentVip.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentVip' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
