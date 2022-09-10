if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusRule' {
    It 'List' {
        $listOfRules = Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName $env.topic -SubscriptionName $env.subscription
        $listOfRules.Count | Should -Be 1
    }

    It 'Get' {
        $rule = Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName $env.topic -SubscriptionName $env.subscription -Name $env.rule
        $rule.Name | Should -Be $env.rule
        $rule.ResourceGroupName | Should -Be $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $rule = Get-AzServiceBusRule -InputObject $rule
        $rule.Name | Should -Be $env.rule
        $rule.ResourceGroupName | Should -Be $env.resourceGroup
    }
}
