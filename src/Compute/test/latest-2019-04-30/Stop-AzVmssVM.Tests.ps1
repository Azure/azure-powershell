$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVmssVM.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzVmssVM' {
    It 'PowerOff1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PowerOffViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
