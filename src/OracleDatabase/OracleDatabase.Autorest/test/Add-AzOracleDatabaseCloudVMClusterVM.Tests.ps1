if(($null -eq $TestName) -or ($TestName -contains 'Add-AzOracleDatabaseCloudVMClusterVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzOracleDatabaseCloudVMClusterVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzOracleDatabaseCloudVMClusterVM' {
    It 'AddExpanded' {
        {
            $dbServerList = Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename $env.exaInfraName -ResourceGroupName $env.resourceGroup
            # VM Cluster already contains the first 2 out of 3 VMs from the Exadata Infra
            $dbServerOcid1 = $dbServerList[2].Ocid
            $dbServersToAdd = @($dbServerOcid1)
            
            Add-AzOracleDatabaseCloudVMClusterVM -NoWait -Cloudvmclustername $env.vmClusterName -ResourceGroupName $env.resourceGroup -DbServer $dbServersToAdd
        } | Should -Not -Throw
    }

    It 'AddViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Add' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
