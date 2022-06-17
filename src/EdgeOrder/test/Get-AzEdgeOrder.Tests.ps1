if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeOrder'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeOrder.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeOrder' {
    It 'Get' {
        $job = Get-AzEdgeOrder -Name $env.OrderName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -Location "eastus"
        $job.Name | should -be $env.OrderName  
    }
}
