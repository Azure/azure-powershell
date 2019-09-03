$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzDeploymentExistence.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzDeploymentExistence' {
    It 'Check' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Check1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
