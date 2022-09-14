if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusSubscription' {
    $sub = Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subscription1
    
    It 'List' {
        $listOfSubscriptions = Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1
        $listOfSubscriptions.Count | Should -Be 1
    }

    It 'Get' {
        $sub.Name | Should -Be "subscription1"
        $sub.ResourceGroupName | Should -Be $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $sub = Get-AzServiceBusSubscription -InputObject $sub
        $sub.Name | Should -Be "subscription1"
        $sub.ResourceGroupName | Should -Be $env.resourceGroup
    }
}
