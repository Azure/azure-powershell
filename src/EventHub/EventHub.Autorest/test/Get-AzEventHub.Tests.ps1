if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHub' {
    It 'List'  {
        $listOfEventHubs = Get-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfEventHubs.Count | Should -Be 1
    }

    It 'Get' {
        $eventHub = Get-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub
        $eventHub.Name | Should -Be $env.eventHub
        $eventHub.CleanupPolicy |Should be "Delete"
        $eventHub.PartitionCount | Should -Be 1
    }

    It 'GetViaIdentity'  {
        $eventHub = Get-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub

        $eventHub = Get-AzEventHub -InputObject $eventHub
        $eventHub.Name | Should -Be $env.eventHub
        $eventHub.CleanupPolicy |Should be "Delete"
        $eventHub.PartitionCount | Should -Be 1

        $eventHub = Get-AzEventHub -InputObject $eventHub.Id
        $eventHub.Name | Should -Be $env.eventHub
        $eventHub.PartitionCount | Should -Be 1
    }
}
