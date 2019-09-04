$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzVmssRollingOSUpgrade.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzVmssRollingOSUpgrade' {
    It 'Start1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
