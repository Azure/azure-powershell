$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateTestMigration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzMigrateTestMigration' {
    It 'ByNameVMwareCbt' {
       $output = Start-AzMigrateTestMigration -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -MachineName $env.srsMachineNametempa -TestNetworkId $env.srsTestNetworkId -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByIDVMwareCbt' {
        $output = Start-AzMigrateTestMigration -TargetObjectID $env.srsMachineIdtempb -TestNetworkId $env.srsTestNetworkId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineIdtempc -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        $output = Start-AzMigrateTestMigration -InputObject $obj -TestNetworkId $env.srsTestNetworkId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
