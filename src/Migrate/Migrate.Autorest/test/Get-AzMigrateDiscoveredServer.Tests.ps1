$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateDiscoveredServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateDiscoveredServer' {
    It 'List' {
        $machines = Get-AzMigrateDiscoveredServer -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
        $machines.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListInSite' {
        $machines = Get-AzMigrateDiscoveredServer -ApplianceName $env.migApplianceName -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
        $machines.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $machines = Get-AzMigrateDiscoveredServer -Name $env.migVMwareMachineName -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
        $machines.Name | Should -Be $env.migVMwareMachineName
    }

    It 'GetInSite' {
        $machines = Get-AzMigrateDiscoveredServer -Name $env.migVMwareMachineName -ApplianceName $env.migApplianceName -ResourceGroupName $env.migResourceGroup -ProjectName $env.migProjectName -SubscriptionId $env.migSubscriptionId
        $machines.Name | Should -Be $env.migVMwareMachineName
    }
}
