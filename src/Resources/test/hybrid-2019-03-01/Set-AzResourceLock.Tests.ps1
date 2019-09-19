$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzResourceLock.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzResourceLock' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
