if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesBackupProtectableItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesBackupProtectableItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesBackupProtectableItem' {
    It 'List' {
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $location = $env.TestCommon.Location
        $vaultId = $env.TestCommon.VaultId        
        $containerFriendlyName = $env.TestRegisterContainer.SQLVMName
        $serverName = $env.TestProtectableItem.ServerName
        $protectableItemName = $env.TestProtectableItem.ProtectableItemName

        # list all proItems 
        $proItems = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType "MSSQL"

        # check all types (may be except AG) of items are present
        $proItems.ProtectableItemType.Contains("SQLDataBase") | Should -Be $true
        $proItems.ProtectableItemType.Contains("SQLInstance") | Should -Be $true

        # check auto-protection policy is present 
        # check nodes list if present

        # filter based on itemName, server name, name, container
        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }

        $proItemsFiltered = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -ItemType SQLDataBase -ServerName $serverName -Container $container -Name $protectableItemName

        # validate
        $proItemsFiltered.ProtectableItemType.Contains("SQLDataBase") | Should -Be $true
        $proItemsFiltered.ProtectableItemType.Contains("SQLInstance") | Should -Be $false

        $proItemsFiltered.Property.ServerName.Contains($serverName) | Should -Be $true

        $proItemsFiltered.Name -match $protectableItemName | Should -Be $true
        
        $proItemsFiltered.Id -match $container.Name.ToLower() | Should -Be $true
    }
}
