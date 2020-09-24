$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateServerMigration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzMigrateServerMigration' {
    It 'ByNameVMwareCbt' {
        {Start-AzMigrateServerMigration -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -MachineName $env.srsMachineNametempe -SubscriptionId $env.srsSubscriptionId} | Should -Not -Throw
    }

    It 'ByIDVMwareCbt' {
        {Start-AzMigrateServerMigration -TargetObjectID $env.srsMachineIdtempf -SubscriptionId $env.srsSubscriptionId} | Should -Not -Throw
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID  $env.srsMachineIdtempg -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        {Start-AzMigrateServerMigration -InputObject $obj -SubscriptionId $env.srsSubscriptionId} | Should -Not -Throw
    }
}
