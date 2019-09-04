$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Remove-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzResource' {
    It 'DeleteTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
