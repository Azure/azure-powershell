if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataProtectionBackupConfigurationClientObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataProtectionBackupConfigurationClientObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataProtectionBackupConfigurationClientObject' {
    It '__AllParameterSets' -skip {
        $subId = $env.TestBackupConfig.SubscriptionId
        $storageAccountResourceGroup = $env.TestBackupConfig.StorageAccountResourceGroup
        $storageAccountName = $env.TestBackupConfig.StorageAccountName

        $storageAccount = Get-AzStorageAccount -ResourceGroupName $storageAccountResourceGroup -Name $storageAccountName
        $containers = Get-AzStorageContainer -Context $storageAccount.Context
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -StorageAccountName $storageAccountName -StorageAccountResourceGroupName $storageAccountResourceGroup -IncludeAllContainer

        $backupConfig.ContainersList.Contains("abc") | Should be $true
        $backupConfig.ContainersList.Contains("aab") | Should be $true
        $backupConfig.ObjectType | Should be "BlobBackupDatasourceParameters"
    }
}
