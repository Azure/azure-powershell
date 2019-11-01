$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzsStorageReclaimStorageAccountStorageCapacity.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzsStorageReclaimStorageAccountStorageCapacity' {
    It 'Reclaim' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReclaimViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
