$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceHostingEnvironmentWebHostingPlan.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceHostingEnvironmentWebHostingPlan' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
