if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzEdgeOrderReturnOrderItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzEdgeOrderReturnOrderItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzEdgeOrderReturnOrderItem' {
    It 'ReturnExpanded' -skip {
        Invoke-AzEdgeOrderReturnOrderItem -OrderItemName $env.OrderItemName -ResourceGroupName $env.ResourceGroupName -ReturnReason "Test Order Return"
        -SubscriptionId $env.SubscriptionId
    }
}
