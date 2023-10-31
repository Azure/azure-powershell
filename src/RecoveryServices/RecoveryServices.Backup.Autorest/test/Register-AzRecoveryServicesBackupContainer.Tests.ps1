if(($null -eq $TestName) -or ($TestName -contains 'Register-AzRecoveryServicesBackupContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzRecoveryServicesBackupContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Register-AzRecoveryServicesBackupContainer' {
    It 'Register' -skip {
        # { throw [System.NotImplementedException] } | Should -Not -Throw
               
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $location = $env.TestCommon.Location
        $vaultId = $env.TestCommon.VaultId
        $resourceId = $env.TestRegisterContainer.ResourceId
        $containerFriendlyName = $env.TestRegisterContainer.SQLVMName

        # unregister - TODO
        
        # register        
        ## get container should be null
        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
        $container | Should -Be $null

        $reg = Register-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -DatasourceType MSSQL -ResourceId $resourceId 
        $reg.Property.SourceResourceId -match $resourceId | Should -Be $true
    }

    It 'ReRegister' {
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $location = $env.TestCommon.Location
        $vaultId = $env.TestCommon.VaultId
        $resourceId = $env.TestRegisterContainer.ResourceId
        $containerFriendlyName = $env.TestRegisterContainer.SQLVMName

        # re-register SQL container
        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
        $container -eq $null | Should -Be $false

        $reg = Register-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -DatasourceType MSSQL -Container $container

        # check container registered 
        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }

        $container.RegistrationStatus -eq "Registered" | Should -Be $true

        # ReRegister SAPHANA workload
        $containerSapHana = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType SAPHANA

        $regSapHana = Register-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -DatasourceType SAPHANA -Container $containerSapHana[0]

        # check container registered
        $containerSapHana = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType SAPHANA

        $containerSapHana[0].RegistrationStatus -eq "Registered" | Should -Be $true
    }
}
