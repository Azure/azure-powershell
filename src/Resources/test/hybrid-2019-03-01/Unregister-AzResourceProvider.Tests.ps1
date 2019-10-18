$TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzResourceProvider.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Unregister-AzResourceProvider' {
    It 'Unregister' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UnregisterViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
