if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksArcCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksArcCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# This needs to run in live only because Az commands in the custom file cannot be recorded.
Describe 'Remove-AzAksArcCluster' -Tag 'LiveOnly' {
    BeforeEach {
        $clusterNameForRemoveTest = "test-remove-cluster"
        # SSH files should be created already.
        $sshPath = Join-Path -Path $PSScriptRoot -ChildPath "test-rsa"
        $ssh = Get-Content -Path "${sshPath}.pub"
        # Create new provisioned cluster for the remove test. The cluster created in utils.ps1 is used for other tests.
        New-AzAksArcCluster `
            -ClusterName $clusterNameForRemoveTest `
            -ResourceGroupName $env.resourceGroupName `
            -CustomLocationName $env.customLocationName `
            -VnetId $env.lnetID `
            -SshKeyValue $ssh
    }
    It 'Delete' {
        Remove-AzAksArcCluster -ClusterName $clusterNameForRemoveTest -ResourceGroupName $env.resourceGroupName
    }
}
