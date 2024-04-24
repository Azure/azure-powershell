if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDataProtectionBackupInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataProtectionBackupInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDataProtectionBackupInstance' -Tag 'LiveOnly' {
    It '__AllParameterSets' {        
        $subscriptionId = $env.TestBlobHardeningScenario.SubscriptionId
	    $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $policyName = $env.TestBlobHardeningScenario.PolicyName
        $updatePolicyName = $env.TestBlobHardeningScenario.UpdatePolicyName
        $vaultedContainers = $env.TestBlobHardeningScenario.UpdatedContainersList

        $vault = Get-AzDataProtectionBackupVault -VaultName  $vaultName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId

        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureBlob

        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGroupName $resourceGroupName| Where-object { $_.name -eq $policyName }
        $updatePolicy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGroupName $resourceGroupName| Where-object { $_.name -eq $updatePolicyName }

        # all containers - "conaaa", "conabb", "coneee", "conwxy", "conzzz"
        $backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList

        $updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -PolicyId $updatePolicy.Id -VaultedBackupContainer $vaultedContainers[0,2,4]

        # verify container names, policyID
        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureBlob

        $containersMatch = $true
        $modifiedContainersList = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList

        $vaultedContainers[0,2,4] | ForEach-Object {
            if (!($modifiedContainersList -contains $_)) {
                $containersMatch = $false
            }
        }

        $modifiedContainersList | ForEach-Object {
            if (!($vaultedContainers[0,2,4] -contains $_)) {
                $containersMatch = $false
            }
        }
        
        $instance.Property.PolicyInfo.PolicyId -eq $updatePolicy.Id | Should be $true
        $containersMatch | Should be $true

        $updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -PolicyId $policy.Id -VaultedBackupContainer $backedUpContainers

        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId -ResourceGroup $resourceGroupName -Vault $vaultName -DatasourceType AzureBlob
        
        # verify container names, policyID
        $instance.Property.PolicyInfo.PolicyId -eq $policy.Id | Should be $true
    }
}
