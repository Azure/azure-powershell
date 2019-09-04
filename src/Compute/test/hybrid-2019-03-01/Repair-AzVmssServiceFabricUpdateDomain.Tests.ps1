$TestRecordingFile = Join-Path $PSScriptRoot 'Repair-AzVmssServiceFabricUpdateDomain.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Repair-AzVmssServiceFabricUpdateDomain' {
    It 'Force' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ForceViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
