$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRoleDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzRoleDefinition' {
    It 'DeleteByName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
