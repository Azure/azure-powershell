$TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzsSubscription.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Move-AzsSubscription' {
    It 'MoveExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Move' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
