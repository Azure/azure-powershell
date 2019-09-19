$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSubscriptionLocation.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzSubscriptionLocation' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
