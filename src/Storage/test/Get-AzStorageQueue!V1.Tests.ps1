$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageQueue!V1.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageQueue!V1' {
    It 'QueueName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'QueuePrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
