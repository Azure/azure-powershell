$TestRecordingFile = Join-Path 'C:\Code\azps-generation\src\Dns\test' 'Test-AzDummy.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzDummy' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
