$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzsLinkOffer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzsLinkOffer' {
    It 'LinkExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Link' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
