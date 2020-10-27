$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMigrateServerReplication' {
    It 'ByIDVMwareCbt' {
         {Remove-AzMigrateServerReplication -TargetObjectID $env.srsMachineIdtempc -SubscriptionId $env.srsSubscriptionId} | Should -Not -Throw

    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID  $env.srsMachineIdtempd -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        {Remove-AzMigrateServerReplication -InputObject $obj -SubscriptionId $env.srsSubscriptionId} | Should -Not -Throw
    }
}
