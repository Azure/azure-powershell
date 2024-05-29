if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkFabricDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkFabricDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkFabricDevice' {
    It 'ListBySubscription' {
        {
            Get-AzNetworkFabricDevice -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzNetworkFabricDevice -Name $global:config.networkDevice.name -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            Get-AzNetworkFabricDevice -ResourceGroupName $global:config.common.resourceGroupName -SubscriptionId $global:config.common.subscriptionId
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
