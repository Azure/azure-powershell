$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsZone.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsZone' {
    It 'CreatePublic' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreatePrivate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
