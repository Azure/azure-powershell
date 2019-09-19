$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebAppPublishingPassword.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzWebAppPublishingPassword' {
    It 'Generate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
