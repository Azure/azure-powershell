$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADServicePrincipalOwner.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADServicePrincipalOwner' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
