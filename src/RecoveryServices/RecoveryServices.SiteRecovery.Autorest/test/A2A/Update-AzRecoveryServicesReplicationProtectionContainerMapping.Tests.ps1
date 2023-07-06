if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRecoveryServicesReplicationProtectionContainerMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRecoveryServicesReplicationProtectionContainerMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRecoveryServicesReplicationProtectionContainerMapping' {
    It 'UpdateExpanded' {
        $primaryfabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $primaryprotectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $primaryfabric -ProtectionContainer $env.a2amppcname
        $mappingInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AUpdateContainerMappingInput]::new()
        $mappingInput.ReplicationScenario="ReplicateAzureToAzure"
        $mappingInput.AgentAutoUpdateStatus='Enabled'
        $mappingInput.AutomationAccountArmId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2arecoveryrg/providers/Microsoft.Automation/automationAccounts/testAutomation"
        $output = Update-AzRecoveryServicesReplicationProtectionContainerMapping -MappingName $env.mappingName -PrimaryProtectionContainer $primaryprotectioncontainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificinput $mappingInput
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Update' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
