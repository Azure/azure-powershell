$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzNetworkWatcherPacketCapture.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzNetworkWatcherPacketCapture' {
    It 'Stop' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
