$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVmssRollingUpgrade.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzVmssRollingUpgrade' {
    It 'Cancel1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
