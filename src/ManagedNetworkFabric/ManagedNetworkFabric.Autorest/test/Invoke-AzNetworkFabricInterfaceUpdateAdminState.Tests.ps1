if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricInterfaceUpdateAdminState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricInterfaceUpdateAdminState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricInterfaceUpdateAdminState' {
    It 'Disable' {
        {
            Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName $global:config.networkInterface.deviceName -NetworkInterfaceName $global:config.networkInterface.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.networkInterface.disable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Enable' {
        {
            Invoke-AzNetworkFabricInterfaceUpdateAdminState -NetworkDeviceName $global:config.networkInterface.deviceName -NetworkInterfaceName $global:config.networkInterface.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.networkInterface.enable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityNetworkDeviceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityNetworkDevice' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
