if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppConnectedEnvStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppConnectedEnvStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppConnectedEnvStorage' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -skip {
        {
            $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupConnected -AccountName $env.storageAccount2).Value[0]

            $config = New-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvStorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $config = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -skip {
        {
            $config = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvStorage
            $config.Name | Should -Be $env.connectedEnvStorage
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupConnected -AccountName $env.storageAccount2).Value[0]

            $config = Update-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvStorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"

        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        {
            $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroupConnected -AccountName $env.storageAccount2).Value[0]
            $config = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvStorage

            $config = Update-AzContainerAppConnectedEnvStorage -InputObject $config -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
            $config.AzureFileShareName | Should -Be "azps-rw-sharename"
        } | Should -Not -Throw
    }

    It 'Delete' -skip {
        {
            Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnvStorage
        } | Should -Not -Throw
    }
}
