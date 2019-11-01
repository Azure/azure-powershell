$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzsUnlinkOffer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzsUnlinkOffer' {
    It 'UnlinkExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Unlink' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnlinkViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnlinkViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
