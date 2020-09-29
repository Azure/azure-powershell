$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppConfigurationStore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzAppConfigurationStore' {
    It 'Delete' {
        New-AzAppConfigurationStore -Name $env.appconfName02 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "standard"
        Remove-AzAppConfigurationStore -Name $env.appconfName02 -ResourceGroupName $env.resourceGroup
        $appConfList = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup
        $appConfList.Name | Should -Not -Contain $env.appconfName02
    }

    It 'DeleteViaIdentity' {
        $appConf = New-AzAppConfigurationStore -Name $env.appconfName03 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "standard"
        Remove-AzAppConfigurationStore -InputObject $appConf  
        $appConfList = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup
        $appConfList.Name | Should -Not -Contain $env.appconfName03
    }
}
