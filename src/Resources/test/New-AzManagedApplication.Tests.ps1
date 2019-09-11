$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzManagedApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzManagedApplication' {
    It 'CreateRGExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateRGExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
