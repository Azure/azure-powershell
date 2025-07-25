if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedEnvStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedEnvStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedEnvStorage' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' {
        {
            # $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupManaged -AccountName $env.storageAccount1).Value[0]
            $storageAccountKey = "1234"

            $config = New-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvStorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName $env.storageAccount1 -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvStorage
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            # $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupManaged -AccountName $env.storageAccount1).Value[0]
            $storageAccountKey = "1234"

            $config = Update-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvStorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName $env.storageAccount1 -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            # $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupManaged -AccountName $env.storageAccount1).Value[0]
            $storageAccountKey = "1234"
            $config = Get-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvStorage

            $config = Update-AzContainerAppManagedEnvStorage -InputObject $config -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName $env.storageAccount1 -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppManagedEnvStorage -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvStorage
        } | Should -Not -Throw
    }
}
