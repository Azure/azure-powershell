if(($null -eq $TestName) -or ($TestName -contains 'Get-AzComputeFleetVMSS'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleetVMSS.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzComputeFleetVMSS' {
    It 'List' {
        {
            $fleetVMSS = Get-AzComputeFleetVMSS -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $fleetVMSS.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }
}
