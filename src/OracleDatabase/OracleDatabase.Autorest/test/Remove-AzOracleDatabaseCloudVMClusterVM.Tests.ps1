if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOracleDatabaseCloudVMClusterVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOracleDatabaseCloudVMClusterVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOracleDatabaseCloudVMClusterVM' {
    It 'RemoveExpanded' {
        {
            $dbServerList = Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $dbServerOcid1 = $dbServerList[0].Ocid
            $dbServersToRemove = @($dbServerOcid1)
            
            Remove-AzOracleDatabaseCloudVMClusterVM -NoWait -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup -DbServer $dbServersToRemove
        } | Should -Not -Throw
    }

    It 'RemoveViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Remove' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RemoveViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
