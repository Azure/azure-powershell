if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppConfigurationReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppConfigurationReplica' {
    BeforeAll {
        $replicaTestStoreName = $env.replicaTestStoreName
        New-AzAppConfigurationStore -Name $replicaTestStoreName -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
        $replicaName = $env.replicaName
        New-AzAppConfigurationReplica -ConfigStoreName $replicaTestStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName -Location "eastus2"
    }

    AfterAll {
        Remove-AzAppConfigurationStore -Name $replicaTestStoreName -ResourceGroupName $env.resourceGroup -Confirm:$false
    }

    It 'List' {
        {
            $replicas = Get-AzAppConfigurationReplica -ConfigStoreName $replicaTestStoreName -ResourceGroupName $env.resourceGroup
            $replicas | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $replicas = Get-AzAppConfigurationReplica -ConfigStoreName $replicaTestStoreName -ResourceGroupName $env.resourceGroup
            $replica = Get-AzAppConfigurationReplica -ConfigStoreName $replicaTestStoreName -ResourceGroupName $env.resourceGroup -Name $replicas[0].Name
            $replica | Should -Not -BeNullOrEmpty
            $replica.Name | Should -Be $replicas[0].Name
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $replicas = Get-AzAppConfigurationReplica -ConfigStoreName $replicaTestStoreName -ResourceGroupName $env.resourceGroup
            $replica = Get-AzAppConfigurationReplica -InputObject $replicas[0]
            $replica | Should -Not -BeNullOrEmpty
            $replica.Name | Should -Be $replicas[0].Name
        } | Should -Not -Throw
    }
}
