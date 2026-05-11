if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAppConfigurationReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppConfigurationReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAppConfigurationReplica' {
    BeforeAll {
        $removeReplicaStoreName = $env.removeReplicaStoreName
        New-AzAppConfigurationStore -Name $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
    }

    AfterAll {
        Remove-AzAppConfigurationStore -Name $removeReplicaStoreName -ResourceGroupName $env.resourceGroup
    }

    It 'Delete' {
        {
            $replicaName = "westusreplica"
            New-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName -Location "westus"
            Remove-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $replicaName = "westus2replica"
            New-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName -Location "westus2"
            $replica = Get-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName
            Remove-AzAppConfigurationReplica -InputObject $replica
        } | Should -Not -Throw
    }
}
