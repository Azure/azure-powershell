if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricTapUpdateAdminState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricTapUpdateAdminState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricTapUpdateAdminState' {
    It 'Enable' {
        {
            Invoke-AzNetworkFabricTapUpdateAdminState -NetworkTapName $global:config.networkTap.enableTapName -ResourceGroupName $global:config.networkTap.resourceGroupName -State $global:config.networkTap.enable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Disable' {
        {
            Invoke-AzNetworkFabricTapUpdateAdminState -NetworkTapName $global:config.networkTap.enableTapName -ResourceGroupName $global:config.networkTap.resourceGroupName -State $global:config.networkTap.disable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
