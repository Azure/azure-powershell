if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesBackupContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesBackupContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesBackupContainer' {
    It '__AllParameterSets' {        
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $containerFriendlyName = $env.TestRegisterContainer.SQLVMName

        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }

        $container.FriendlyName -eq $containerFriendlyName | Should -Be $true
    }
}
