$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkInterfaceEffectiveNsg.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzNetworkInterfaceEffectiveNsg' {
    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
