$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Get-AzStorageQueue.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageQueue' {
    It 'QueueName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'QueuePrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
