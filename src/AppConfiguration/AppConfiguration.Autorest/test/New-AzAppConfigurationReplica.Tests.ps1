if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppConfigurationReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppConfigurationReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppConfigurationReplica' {
    BeforeAll {
        $newReplicaStoreName = $env.newReplicaStoreName
        New-AzAppConfigurationStore -Name $newReplicaStoreName -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
    }

    AfterAll {
        Remove-AzAppConfigurationReplica -ConfigStoreName $newReplicaStoreName -ResourceGroupName $env.resourceGroup -Name "westus2replica" -ErrorAction SilentlyContinue
        Remove-AzAppConfigurationStore -Name $newReplicaStoreName -ResourceGroupName $env.resourceGroup -Confirm:$false
    }

    It 'CreateExpanded' {
        {
            $replica = New-AzAppConfigurationReplica -ConfigStoreName $newReplicaStoreName -ResourceGroupName $env.resourceGroup -Name "westus2replica" -Location "westus2"
            $replica | Should -Not -BeNullOrEmpty
            $replica.Name | Should -Be "westus2replica"
            $replica.Location | Should -Be "westus2"
        } | Should -Not -Throw
    }
}
