if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStackHciCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStackHciCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStackHciCluster' {
    It 'Delete' {
        Remove-AzStackHciCluster -ClusterName "$($env.ClusterName)-remove" -ResourceGroupName $env.ResourceGroup 
    }

    It 'DeleteViaIdentity' {
        $clusterremove = Get-AzStackHciCluster -Name "$($env.ClusterName)-remove2" -ResourceGroupName $env.ResourceGroup 
        Remove-AzStackHciCluster -InputObject $clusterremove
    }
}
