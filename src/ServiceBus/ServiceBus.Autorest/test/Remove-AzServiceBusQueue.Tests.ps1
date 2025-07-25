if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusQueue'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusQueue.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusQueue' {
    It 'Delete' {
        New-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queueToRemove
        Remove-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queueToRemove
        { Get-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queueToRemove -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $queue = New-AzServiceBusQueue -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name queueToRemove
        Remove-AzServiceBusQueue -InputObject $queue
        { Get-AzServiceBusQueue -InputObject $queue -ErrorAction Stop } | Should -Throw
    }
}
