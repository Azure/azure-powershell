$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateReplicationPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMigrateReplicationPolicy' {
    It 'CreateExpanded' {
        $providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.VMwareCbtPolicyCreationInput]::new()
        $providerSpecificPolicy.AppConsistentFrequencyInMinute = 240
        $providerSpecificPolicy.InstanceType = "VMwareCbt"
        $providerSpecificPolicy.RecoveryPointHistoryInMinute = 4320
        $providerSpecificPolicy.CrashConsistentFrequencyInMinute = 60
        $output = New-AzMigrateReplicationPolicy -PolicyName $env.srsTestPolicy -ResourceGroupName $env.migResourceGroup -ResourceName $env.srsVaultName -SubscriptionId $env.srsSubscriptionId -ProviderSpecificInput $providerSpecificPolicy
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
