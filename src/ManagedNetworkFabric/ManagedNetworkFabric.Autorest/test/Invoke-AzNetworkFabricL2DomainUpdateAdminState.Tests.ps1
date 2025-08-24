if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricL2DomainUpdateAdminState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricL2DomainUpdateAdminState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricL2DomainUpdateAdminState' {
    It 'Enable' {
        {
            Invoke-AzNetworkFabricL2DomainUpdateAdminState -L2IsolationDomainName $global:config.l2domain.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.l2domain.enable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Disable' {
        {
            Invoke-AzNetworkFabricL2DomainUpdateAdminState -L2IsolationDomainName $global:config.l2domain.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.l2domain.disable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
