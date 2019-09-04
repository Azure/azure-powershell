$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppContinuouWebJob.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppContinuouWebJob' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
