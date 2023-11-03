if(($null -eq $TestName) -or ($TestName -contains 'AzDeviceUpdateInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDeviceUpdateInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDeviceUpdateInstance' {
    # It 'CreateExpanded' {
    #     {
    #         $resourceId2 = (Get-AzIotHub -ResourceGroupName $env.resourceGroup -Name azpstest-iothub-2).Id
    #         $iotHubSetting = New-AzDeviceUpdateIotHubSettingsObject -ResourceId $resourceId2
    #         $config = New-AzDeviceUpdateInstance -AccountName $env.accountName1 -Name $env.instanceName1 -ResourceGroupName $env.resourceGroup -Location $env.location -IotHub $iotHubSetting -EnableDiagnostic:$false
    #         $config.Name | Should -Be $env.instanceName1

    #         $resourceId3 = (Get-AzIotHub -ResourceGroupName $env.resourceGroup -Name azpstest-iothub-3).Id
    #         $iotHubSetting = New-AzDeviceUpdateIotHubSettingsObject -ResourceId $resourceId3
    #         $config = New-AzDeviceUpdateInstance -AccountName $env.accountName1 -Name $env.instanceName2 -ResourceGroupName $env.resourceGroup -Location $env.location -IotHub $iotHubSetting -EnableDiagnostic:$false
    #         $config.Name | Should -Be $env.instanceName2
    #     } | Should -Not -Throw
    # }

    It 'List' {
        {
            $config = Get-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup -Name $env.instanceName1
            $config.Name | Should -Be $env.instanceName1
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup -Name $env.instanceName1 -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.instanceName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup -Name $env.instanceName2
            $config = Update-AzDeviceUpdateInstance -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.instanceName2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup -Name $env.instanceName1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzDeviceUpdateInstance -AccountName $env.accountName1 -ResourceGroupName $env.resourceGroup -Name $env.instanceName2
            Remove-AzDeviceUpdateInstance -InputObject $config
        } | Should -Not -Throw
    }
}
