$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Set-AzManagedApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzManagedApplication' {
    It 'UpdateRGExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateRGExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
