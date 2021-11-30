if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzEdgeOrderItemCancellation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzEdgeOrderItemCancellation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzEdgeOrderItemCancellation' {
    It 'CancelExpanded'  {
        Invoke-AzEdgeOrderItemCancellation -Name $env.OrderItemNameTest -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Invoke-AzEdgeOrderItemCancellation -Name $env.OrderItemName -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
    }
}
