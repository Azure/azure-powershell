if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusTopic' {
    $topic = Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topic1

    It 'List' {
        $listOfTopics = Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfTopics.Count | Should -Be 1
    }

    It 'Get' {
        $topic.Name | Should -Be "topic1"
        $topic.ResourceGroupName | Should -Be $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $topic = Get-AzServiceBusTopic -InputObject $topic
        $topic.Name | Should -Be "topic1"
        $topic.ResourceGroupName | Should -Be $env.resourceGroup
    }
}
