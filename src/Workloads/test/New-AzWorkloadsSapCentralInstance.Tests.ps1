if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsSapCentralInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsSapCentralInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsSapCentralInstance' {
    It 'CreateExpanded' {
        { New-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Location $env.Location } | Should -Throw
    }
}
