$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageContainer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageContainer' {
    It 'ContainerName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ContainerPrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
