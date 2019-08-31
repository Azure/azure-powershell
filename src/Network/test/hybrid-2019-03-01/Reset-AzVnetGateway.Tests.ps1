$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzVnetGateway.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Reset-AzVnetGateway' {
    It 'Reset1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
