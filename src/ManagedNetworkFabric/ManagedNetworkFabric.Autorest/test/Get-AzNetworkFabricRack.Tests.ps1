if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkFabricRack'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkFabricRack.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkFabricRack' {
    It 'ListBySubscription' {
        {
            Get-AzNetworkFabricRack -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzNetworkFabricRack -Name $global:config.networkRack.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            Get-AzNetworkFabricRack -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
