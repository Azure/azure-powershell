$TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzProviderFeature.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Register-AzProviderFeature' {
    It 'Register' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegisterViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
