$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderDistributor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderDistributor' {
    It 'VhdDistributor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ManagedImageDistributor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SharedImageDistributor' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
