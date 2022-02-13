$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubDefaultRollout-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubDefaultRollout-CRUD' {
    It 'Create, get, list, cancel, and delete DefaultRollout' {
        $row2Timespan = New-TimeSpan -Hours 4

        $defaultRollout = New-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psDefaultRollout" -RestOfTheWorldGroupTwoWaitDuration $row2Timespan -CanarySkipRegion "brazilus" -NoWait
        $defaultRollout | Should -Not -BeNullOrEmpty

        $defaultRollout = Get-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psDefaultRollout"
        $defaultRollout | Should -Not -BeNullOrEmpty
        $defaultRollout.Name | Should -BeExactly "psDefaultRollout"

        $defaultRolloutList = Get-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace
        $defaultRolloutList.Count | Should -BeGreaterOrEqual 1

        $defaultRollout = Stop-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psDefaultRollout"
        $defaultRollout = Get-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psDefaultRollout"
        $defaultRollout.ProvisioningState | Should -BeExactly "Canceled"

        $defaultRollout = Remove-AzProviderHubDefaultRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psDefaultRollout"
        $defaultRollout | Should -BeNullOrEmpty
    }
}
