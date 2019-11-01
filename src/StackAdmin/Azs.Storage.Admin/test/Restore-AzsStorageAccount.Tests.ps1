$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzsStorageAccount.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzsStorageAccount' {
    It 'Undelete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UndeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
