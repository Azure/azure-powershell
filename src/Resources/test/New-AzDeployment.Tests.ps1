$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzDeployment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzDeployment' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateRGDeploymentByFile' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
