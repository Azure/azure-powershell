$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Compute\test' 'New-AzVmss.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVmss' {
    It 'DefaultParameter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SimpleParameterSet' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
