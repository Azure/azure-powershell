if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkFabricL3DomainUpdateAdminState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkFabricL3DomainUpdateAdminState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkFabricL3DomainUpdateAdminState' {
    It 'Enable' {
        {
            Invoke-AzNetworkFabricL3DomainUpdateAdminState -L3IsolationDomainName $global:config.l3domain.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.l3domain.enable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Disable' {
        {
            Invoke-AzNetworkFabricL3DomainUpdateAdminState -L3IsolationDomainName $global:config.l3domain.name -ResourceGroupName $global:config.common.resourceGroupName -State $global:config.l3domain.disable -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
