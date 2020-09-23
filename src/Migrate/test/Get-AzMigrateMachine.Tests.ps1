$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateMachine' {
    It 'List' {
        $machines = Get-AzMigrateMachine -ResourceGroupName $env.migResourceGroup -SiteName $env.migSiteName -SubscriptionId $env.migSubscriptionId
        $machines.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $machine = Get-AzMigrateMachine -Name $env.migVMwareMachineName -ResourceGroupName $env.migResourceGroup -SiteName $env.migSiteName -SubscriptionId $env.migSubscriptionId
        $machine.Name | Should -Be $env.migVMwareMachineName
    }

    It 'GetViaIdentity' -skip {
        $machine1 = Get-AzMigrateMachine -Name $env.migVMwareMachineName -ResourceGroupName $env.migResourceGroup -SiteName $env.migSiteName -SubscriptionId $env.migSubscriptionId
        $machine2 = Get-AzMigrateMachine -InputObject $machine1
        $machine2.Name | Should -Be $env.migVMwareMachineName
    }
}