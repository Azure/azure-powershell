if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusSubscription' {
    It 'Delete' {
        New-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subToRemove
        Remove-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subToRemove
        { Get-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subToRemove -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $sub = New-AzServiceBusSubscription -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name subToRemove
        Remove-AzServiceBusSubscription -InputObject $sub
        { Get-AzServiceBusSubscription -InputObject $sub -ErrorAction Stop } | Should -Throw
    }
}
