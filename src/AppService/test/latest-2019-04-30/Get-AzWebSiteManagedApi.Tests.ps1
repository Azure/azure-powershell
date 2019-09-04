$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteManagedApi.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteManagedApi' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
