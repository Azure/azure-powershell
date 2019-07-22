$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageQueueSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageQueueSASToken' {
    It 'SasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
