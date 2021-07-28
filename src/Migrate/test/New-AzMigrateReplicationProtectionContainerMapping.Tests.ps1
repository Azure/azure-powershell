$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateReplicationProtectionContainerMapping.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMigrateReplicationProtectionContainerMapping' {
    It 'CreateExpanded' {
    $providerSpecificInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.VMwareCbtContainerMappingInput]::new()
    $providerSpecificInput.InstanceType = "VMwareCbt"
        $providerSpecificInput.KeyVaultId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.KeyVault/vaults/migratekv868271840"
        $providerSpecificInput.KeyVaultUri = "https://migratekv868271840.vault.azure.net"
        $providerSpecificInput.ServiceBusConnectionStringSecretName = "ServiceBusConnectionString"
        $providerSpecificInput.StorageAccountId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.Storage/storageAccounts/migrategwsa868271840"
        $providerSpecificInput.StorageAccountSasSecretName = "migrategwsa868271840-gwySas"
        $providerSpecificInput.TargetLocation = "centraluseuap"

        $output = New-AzMigrateReplicationProtectionContainerMapping -FabricName $env.srsFabricName -MappingName $env.srsMappingName -ProtectionContainerName $env.srsProtectionContainerName -ResourceGroupName $env.migResourceGroup -ResourceName $env.srsVaultName -SubscriptionId $env.srsSubscriptionId -PolicyId $env.srsPolicyId -ProviderSpecificInput $providerSpecificInput -TargetProtectionContainerId $env.srsTargetPCId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
