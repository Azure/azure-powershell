$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzPolicyDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzPolicyDefinition' {
    It 'UpdateById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
