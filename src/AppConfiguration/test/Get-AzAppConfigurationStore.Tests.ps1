$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationStore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzAppConfigurationStore' {
    It 'List' {
        $appConfList = Get-AzAppConfigurationStore
        $appConfList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $appConfList = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup
        $appConfList.Count | Should -Be 2
    }

    It 'Get' {
        $appConf = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup -Name $env.appconfName00
        $appConf.Name | Should -Be $env.appconfName00
    }

    It 'GetViaIdentity' {
        $appConf = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup -Name $env.appconfName00
        $appConf = Get-AzAppConfigurationStore -InputObject $appConf 
        $appConf.Name | Should -Be $env.appconfName00
    }
}
