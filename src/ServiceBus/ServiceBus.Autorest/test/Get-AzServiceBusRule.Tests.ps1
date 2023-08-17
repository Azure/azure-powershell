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
    $rule = Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRule1
    
    It 'List' {
        $listOfRules = Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1
        $listOfRules.Count | Should -Be 1
    }

    It 'Get' {
        $rule.Name | Should -Be "sqlRule1"
        $rule.ResourceGroupName | Should -Be $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $rule = Get-AzServiceBusRule -InputObject $rule
        $rule.Name | Should -Be "sqlRule1"
        $rule.ResourceGroupName | Should -Be $env.resourceGroup
    }
}
