$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppServicePlanVnetRoute.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzAppServicePlanVnetRoute' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Create' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
