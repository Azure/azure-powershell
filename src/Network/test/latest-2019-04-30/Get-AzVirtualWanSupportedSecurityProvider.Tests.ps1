$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVirtualWanSupportedSecurityProvider.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVirtualWanSupportedSecurityProvider' {
    It 'Supported' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SupportedViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
