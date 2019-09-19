$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzKeyVaultAccessPolicy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzKeyVaultAccessPolicy' {
    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
