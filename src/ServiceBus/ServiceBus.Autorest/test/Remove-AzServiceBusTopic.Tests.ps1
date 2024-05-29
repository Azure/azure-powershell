if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusTopic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusTopic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusTopic' {
    It 'Delete' {
        New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToRemove
        Remove-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToRemove
        { Get-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToRemove -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $topic = New-AzServiceBusTopic -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name topicToRemove
        Remove-AzServiceBusTopic -InputObject $topic
        { Get-AzServiceBusTopic -InputObject $topic -ErrorAction Stop } | Should -Throw
    }
}
