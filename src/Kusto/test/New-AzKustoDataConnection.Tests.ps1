$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDataConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoDataConnection' {
    It 'CreateExpandedEventHub' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpandedEventGrid' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpandedIotHub' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpandedEventGrid' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedEventGrid' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
