if(($null -eq $TestName) -or ($TestName -contains 'New-AzStackHciCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHciCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStackHciCluster' {
    It 'CreateExpanded' {
        New-AzStackHciCluster -Name $env.ClusterName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -AadClientId $env.AadClientId -AadTenantId $env.AadTenantId -Location $env.Location
    }
}
