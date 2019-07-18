$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\Resources\test' 'Update-AzADApplication.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzADApplication' {
    It 'PatchByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
