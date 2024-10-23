if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleCloudVMClusterVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleCloudVMClusterVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleCloudVMClusterVM' {
    It 'RemoveExpanded' {
        {
            $dbServerList = Get-AzOracleDbServer -Cloudexadatainfrastructurename $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $dbServerOcid1 = $dbServerList[0].Ocid
            $dbServersToRemove = @($dbServerOcid1)
            
            Remove-AzOracleCloudVMClusterVM -NoWait -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup -DbServer $dbServersToRemove
        } | Should -Not -Throw
    }
}
