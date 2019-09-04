$TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzResourceProvider.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Register-AzResourceProvider' {
    It 'Register' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegisterViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
