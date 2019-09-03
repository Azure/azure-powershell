$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzDnsNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzDnsNameAvailability' {
    It 'Check1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CheckViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
