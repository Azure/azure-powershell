$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironmentServerFarm.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironmentServerFarm' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
