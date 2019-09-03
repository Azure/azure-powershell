$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDnsZone.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzDnsZone' {
    It 'UpdatePublic' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdatePrivate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
