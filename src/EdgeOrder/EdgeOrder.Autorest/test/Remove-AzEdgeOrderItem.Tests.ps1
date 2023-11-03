if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEdgeOrderItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEdgeOrderItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEdgeOrderItem' {
    It 'Delete' {
        Remove-AzEdgeOrderItem -Name $env.OrderItemNameTest -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId
        Remove-AzEdgeOrderItem -Name $env.OrderItemName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId
    }
}
