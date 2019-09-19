$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentWebHostingPlan.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentWebHostingPlan' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
