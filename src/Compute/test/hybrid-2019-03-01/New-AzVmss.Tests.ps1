$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVmss.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVmss' {
    It 'DefaultParameter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SimpleParameterSet' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
