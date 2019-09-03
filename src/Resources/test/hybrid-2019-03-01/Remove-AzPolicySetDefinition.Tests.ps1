$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPolicySetDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzPolicySetDefinition' {
    It 'DeleteById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
