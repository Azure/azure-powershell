$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzNetworkWatcherIPFlow.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzNetworkWatcherIPFlow' {
    It 'VerifyExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Verify' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'VerifyViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'VerifyViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
