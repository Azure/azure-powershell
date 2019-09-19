$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzVmss.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzVmss' {
    It 'StartExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
