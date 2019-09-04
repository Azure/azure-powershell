$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteInstanceDeployment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteInstanceDeployment' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
