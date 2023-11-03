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

    It 'CreateExpanded' -skip {
        {
            $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroup -AccountName $env.storageAccount).Value[0]
            $config = New-AzContainerAppManagedEnvStorage -EnvName $env.envName -ResourceGroupName $env.resourceGroup -StorageName $env.storageAccount -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName $env.storageAccount -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $config = Get-AzContainerAppManagedEnvStorage -EnvName $env.envName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -skip {
        {
            $config = Get-AzContainerAppManagedEnvStorage -EnvName $env.envName -ResourceGroupName $env.resourceGroup -StorageName $env.storageAccount
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'Delete' -skip {
        {
            Remove-AzContainerAppManagedEnvStorage -EnvName $env.envName -ResourceGroupName $env.resourceGroup -StorageName $env.storageAccount
        } | Should -Not -Throw
    }
}
