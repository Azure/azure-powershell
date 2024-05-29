if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkFabricTap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkFabricTap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkFabricTap' {
    It 'ListBySubscription' {
        {
            Get-AzNetworkFabricTap -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzNetworkFabricTap -Name $global:config.networkTap.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            Get-AzNetworkFabricTap -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
