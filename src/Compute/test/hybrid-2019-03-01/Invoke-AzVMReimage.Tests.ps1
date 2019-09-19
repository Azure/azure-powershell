$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVMReimage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVMReimage' {
    It 'Redeploy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RedeployViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
