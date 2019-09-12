$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Update-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzResource' {
    It 'UpdateTopLevelResource' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
