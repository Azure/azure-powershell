$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentOperation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentOperation' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
