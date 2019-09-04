$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteSourceControl.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteSourceControl' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
