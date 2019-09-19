$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDeployment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzDeployment' {
    It 'Cancel' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Cancel1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
