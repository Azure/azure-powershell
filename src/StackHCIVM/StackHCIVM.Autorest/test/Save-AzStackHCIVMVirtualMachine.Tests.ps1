$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzStackHCIVMVirtualMachine.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath -and $currentPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Include 'HttpPipelineMocking.ps1' -File -ErrorAction SilentlyContinue
    $parentPath = Split-Path -Path $currentPath -Parent
    if (-not $parentPath -or $parentPath -eq $currentPath) {
        break
    }
    $currentPath = $parentPath
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Save-AzStackHCIVMVirtualMachine' {
    It 'ByResourceId' {
        $command = Get-Command -Name 'Save-AzStackHCIVMVirtualMachine' -ErrorAction Stop
        $command | Should -Not -BeNullOrEmpty
        $command.Parameters.Keys | Should -Contain 'ResourceId'
    }

    It 'ByName' {
        $command = Get-Command -Name 'Save-AzStackHCIVMVirtualMachine' -ErrorAction Stop
        $command | Should -Not -BeNullOrEmpty
        $command.Parameters.Keys | Should -Contain 'Name'
    }
}
