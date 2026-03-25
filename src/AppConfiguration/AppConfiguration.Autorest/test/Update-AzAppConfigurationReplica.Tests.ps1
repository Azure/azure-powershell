if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAppConfigurationReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAppConfigurationReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAppConfigurationReplica' {
    BeforeAll {
        $updateReplicaStoreName = $env.updateReplicaStoreName
        New-AzAppConfigurationStore -Name $updateReplicaStoreName -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
        $updateReplicaName = "westus2replica"
        New-AzAppConfigurationReplica -ConfigStoreName $updateReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $updateReplicaName -Location "westus2"
    }

    AfterAll {
        Remove-AzAppConfigurationStore -Name $updateReplicaStoreName -ResourceGroupName $env.resourceGroup -Confirm:$false
    }

    It 'UpdateExpanded' {
        {
            $replica = Update-AzAppConfigurationReplica -ConfigStoreName $updateReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $updateReplicaName
            $replica | Should -Not -BeNullOrEmpty
            $replica.Name | Should -Be $updateReplicaName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $replica = Get-AzAppConfigurationReplica -ConfigStoreName $updateReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $updateReplicaName
            $updated = Update-AzAppConfigurationReplica -InputObject $replica
            $updated | Should -Not -BeNullOrEmpty
            $updated.Name | Should -Be $updateReplicaName
        } | Should -Not -Throw
    }
}
