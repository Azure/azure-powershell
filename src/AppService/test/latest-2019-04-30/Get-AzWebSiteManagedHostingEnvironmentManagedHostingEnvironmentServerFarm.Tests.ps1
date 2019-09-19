$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentServerFarm.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentServerFarm' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
