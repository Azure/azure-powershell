if(($null -eq $TestName) -or ($TestName -contains 'Update-AzHorizonDbPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzHorizonDbPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzHorizonDbPool' {
    It 'UpdateExpanded' {
        $null = Update-AzHorizonDbPool -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -Name $env.sharedPoolName -SubscriptionId $env.SubscriptionId -ComputeModelVCore 4 -Confirm:$false -ErrorAction Stop

        $pool = Get-AzHorizonDbPool -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -Name $env.sharedPoolName -SubscriptionId $env.SubscriptionId -ErrorAction Stop

        $pool.Name | Should -Be $env.sharedPoolName
        $pool.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $pool.ComputeModelVCore | Should -Be 4
        $pool.State | Should -Be 'Ready'
        $pool.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityClusterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
