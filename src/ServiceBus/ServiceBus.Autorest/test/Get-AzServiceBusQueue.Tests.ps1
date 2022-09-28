if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusQueue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusQueue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusQueue' {
    $queue = Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queue1
    
    It 'List' {
        $listOfQueues = Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfQueues.Count | Should -Be 1
    }

    It 'Get' {
        $queue.Name | Should -Be "queue1"
        $queue.ResourceGroupName | Should -Be $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $queue = Get-AzServiceBusQueue -InputObject $queue
        $queue.Name | Should -Be "queue1"
        $queue.ResourceGroupName | Should -Be $env.resourceGroup
    }
}
