if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeOrderAddress'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeOrderAddress.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeOrderAddress' {
    It 'Get' {
        $job = Get-AzEdgeOrderAddress -Name $env.AddressNameTest -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
        $job.Name | should -be $env.AddressNameTest
    }
}
