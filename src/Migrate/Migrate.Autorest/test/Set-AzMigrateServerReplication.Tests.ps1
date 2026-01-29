$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzMigrateServerReplication'  -Tag 'LiveOnly' {
    It 'ByIDVMwareCbt' {
       $output = Set-AzMigrateServerReplication -TargetObjectID $env.srsMachineId2 -SubscriptionId $env.srsSubscriptionId2
       $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineId2 -SubscriptionId $env.srsSubscriptionId2 -SqlServerLicenseType $env.sqlServerLicenseType
        $obj.Count | Should -BeGreaterOrEqual 1
        $output = Set-AzMigrateServerReplication -InputObject $obj -SubscriptionId $env.srsSubscriptionId2 -SqlServerLicenseType $env.sqlServerLicenseType
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
