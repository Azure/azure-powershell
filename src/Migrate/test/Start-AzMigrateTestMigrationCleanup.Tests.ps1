$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateTestMigrationCleanup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzMigrateTestMigrationCleanup' {
    It 'ByIDVMwareCbt' {
       $output = Start-AzMigrateTestMigrationCleanup -TargetObjectID  $env.srsMachinetmpv-SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID   $env.srsMachinetmpv -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        $output = Start-AzMigrateTestMigrationCleanup -InputObject $obj -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
