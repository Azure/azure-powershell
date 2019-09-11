$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzResourceLock.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzResourceLock' {
    It 'CreateTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
