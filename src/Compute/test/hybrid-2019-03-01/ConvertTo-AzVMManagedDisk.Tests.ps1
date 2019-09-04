$TestRecordingFile = Join-Path $PSScriptRoot 'ConvertTo-AzVMManagedDisk.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'ConvertTo-AzVMManagedDisk' {
    It 'Convert' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConvertViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
