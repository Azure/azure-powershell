$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubCustomRollout-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubCustomRollout-CRUD' {
    It 'Create and get a CustomRollout' {
        $customRollout = New-AzProviderHubCustomRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psCustomRollout" -CanaryRegion "eastus2euap"
        $customRollout | Should -Not -BeNullOrEmpty
        $customRollout.Name | Should -BeExactly "psCustomRollout"
        $customRollout.ProvisioningState | Should -BeExactly "Succeeded"

        $customRollout = Get-AzProviderHubCustomRollout -ProviderNamespace $env.ProviderNamespace -RolloutName "psCustomRollout"
        $customRollout.Name | Should -BeExactly "psCustomRollout"
    }
}
