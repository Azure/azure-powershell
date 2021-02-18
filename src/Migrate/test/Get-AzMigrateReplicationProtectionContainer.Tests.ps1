$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateReplicationProtectionContainer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateReplicationProtectionContainer' {
    It 'List'  {
       $output = Get-AzMigrateReplicationProtectionContainer -ResourceName $env.srsVaultName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'List1'  {
       $output = Get-AzMigrateReplicationProtectionContainer -FabricName $env.srsFabricName -ResourceName $env.srsVaultName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
       $output = Get-AzMigrateReplicationProtectionContainer -ProtectionContainerName  $env.srsProtectionContainerName -FabricName $env.srsFabricName -ResourceName $env.srsVaultName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }
}
