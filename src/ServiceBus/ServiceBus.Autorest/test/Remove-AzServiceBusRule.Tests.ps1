if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusRule' {
    It 'Delete' {
        New-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRuleToRemove
        Remove-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRuleToRemove
        { Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRuleToRemove -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $rule = New-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRuleToRemove
        Remove-AzServiceBusRule -InputObject $rule
        { Get-AzServiceBusRule -InputObject $rule -ErrorAction Stop } | Should -Throw
    }
}
