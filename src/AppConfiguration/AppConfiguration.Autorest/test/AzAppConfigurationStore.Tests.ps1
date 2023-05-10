if(($null -eq $TestName) -or ($TestName -contains 'AzAppConfigurationStore'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzAppConfigurationStore.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzAppConfigurationStore' {
    It 'CheckStoreNameAvailability' {
        {
            $config = Test-AzAppConfigurationStoreNameAvailability -Name $env.appStoreName1
            $config.Message | Should -Be "The specified name is available."
        } | Should -Not -Throw
    }

    It 'CreateStore' {
        {
            $config = New-AzAppConfigurationStore -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
            $config.Name | Should -Be $env.appStoreName1

            $config = New-AzAppConfigurationStore -Name $env.appStoreName2 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
            $config.Name | Should -Be $env.appStoreName2
        } | Should -Not -Throw
    }

    It 'ListStoreKey' {
        {
            $config = Get-AzAppConfigurationStoreKey -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'CreateStoreKey' {
        {
            $keys = Get-AzAppConfigurationStoreKey -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup
            $config = New-AzAppConfigurationStoreKey -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup -Id $keys[0].id
            $config.Name | Should -Be "Primary"
        } | Should -Not -Throw
    }

    It 'GetStore' {
        {
            $config = Get-AzAppConfigurationStore -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.appStoreName1
        } | Should -Not -Throw
    }

    It 'ListStoreByResourceGroupName' {
        {
            $config = Get-AzAppConfigurationStore -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListStore' {
        {
            $config = Get-AzAppConfigurationStore
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateStore' {
        {
            $config = Update-AzAppConfigurationStore -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup -DisableLocalAuth -PublicNetworkAccess 'Enabled'
            $config.Name | Should -Be $env.appStoreName1
        } | Should -Not -Throw
    }

    It 'UpdateStoreByObj' {
        {
            $config = Get-AzAppConfigurationStore -Name $env.appStoreName2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzAppConfigurationStore -InputObject $config -DisableLocalAuth -PublicNetworkAccess 'Enabled'
            $config.Name | Should -Be $env.appStoreName2
        } | Should -Not -Throw
    }

    It 'DeleteStore' {
        {
            Remove-AzAppConfigurationStore -Name $env.appStoreName1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteStoreByObj' {
        {
            $config = Get-AzAppConfigurationStore -Name $env.appStoreName2 -ResourceGroupName $env.resourceGroup
            Remove-AzAppConfigurationStore -InputObject $config
        } | Should -Not -Throw
    }

    It 'ListDeletedStore' {
        {
            $config = Get-AzAppConfigurationDeletedStore
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetDeletedStore' {
        {
            $config = Get-AzAppConfigurationDeletedStore -Location $env.location -Name $env.appStoreName1
            $config.Name | Should -Be $env.appStoreName1
        } | Should -Not -Throw
    }

    It 'ClearDeletedStore' {
        {
            $config = Clear-AzAppConfigurationDeletedStore -Location $env.location -Name $env.appStoreName1 -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }
}
