$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Remove-AzResourceLock.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzResourceLock' {
    It 'DeleteTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
