$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzStackHCIVMVirtualMachine.Recording.json'
$currentPath = $PSScriptRoot
$mockingPath = $null
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $parentPath = Split-Path -Path $currentPath -Parent
    if (-not $parentPath -or $parentPath -eq $currentPath) {
        break
    }
    $currentPath = $parentPath
}
if (-not $mockingPath) {
    throw "HttpPipelineMocking.ps1 could not be found starting from path '$PSScriptRoot'."
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Save-AzStackHCIVMVirtualMachine' {
    It 'ByResourceId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
