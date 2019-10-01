$TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzResourceProvider.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Register-AzResourceProvider' {
    It 'Register' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegisterViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
