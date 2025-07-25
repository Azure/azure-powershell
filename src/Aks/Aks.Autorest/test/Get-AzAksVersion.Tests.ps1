$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksVersion.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzAksVersion' {
    It 'Get' {
        $version = Get-AzAksVersion -Location eastus

        $version.Count | Should -Be 7
    
        $chosenVersion = $version | Where-Object { $_.OrchestratorVersion -eq '1.23.12'}
        $chosenVersion.OrchestratorVersion | Should -Be '1.23.12'
        $chosenVersion.Upgrade.Count | Should -Be 3
        $chosenVersion.Upgrade[0].OrchestratorVersion | Should -Be '1.23.15'
    }
}
