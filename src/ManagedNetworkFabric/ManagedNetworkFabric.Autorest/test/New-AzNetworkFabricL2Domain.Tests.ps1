if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkFabricL2Domain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkFabricL2Domain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkFabricL2Domain' {
    It 'Create' {
        {
            New-AzNetworkFabricL2Domain -SubscriptionId $global:config.common.subscriptionId -Name $global:config.l2domain.name -ResourceGroupName $global:config.common.resourceGroupName -Location $global:config.common.location -NetworkFabricId $global:config.l2domain.nfId -VlanId $global:config.l2domain.vlanId -Mtu $global:config.l2domain.mtu
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
