if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeOrderItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeOrderItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeOrderItem' {
    It 'Get'  {
        $job = Get-AzEdgeOrderItem -Name $env.OrderItemName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
        $job.Name | should -be $env.OrderItemName 
    }
}
