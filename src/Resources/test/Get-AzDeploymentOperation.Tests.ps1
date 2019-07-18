$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\Resources\test' 'Get-AzDeploymentOperation.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzDeploymentOperation' {
    It 'GetByDeploymentObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
