$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppConfigurationStoreKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzAppConfigurationStoreKey' {
    It 'RegenerateExpanded' {
        $oldAppconfkeys = Get-AzAppConfigurationStoreKey -Name $env.appconfName00-ResourceGroupName $env.resourceGroup
        New-AzAppConfigurationStoreKey -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup -Id $oldAppconfkeys[0].id
        $newAppconfkeys = Get-AzAppConfigurationStoreKey -Name $env.appconfName00-ResourceGroupName $env.resourceGroup
        $oldAppconfkeys[0].value | Should -Not -Be $newAppconfkeys[0].value
    }

    It 'RegenerateViaIdentityExpanded' {
        $appconf = Get-AzAppConfigurationStore -Name $env.appconfName00-ResourceGroupName $env.resourceGroup
        $oldAppconfkeys = Get-AzAppConfigurationStoreKey -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup
        New-AzAppConfigurationStoreKey -InputObject $appconf -Id $oldAppconfkeys[0].id
        $newAppconfkeys = Get-AzAppConfigurationStoreKey -Name $env.appconfName00-ResourceGroupName $env.resourceGroup
        $oldAppconfkeys[0].value | Should -Not -Be $newAppconfkeys[0].value
    }
}
