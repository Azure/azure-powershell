if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbPool' {
    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        $resourceGroupName = $env.clusterResourceGroup
        $newClusterName = $env.newClusterPoolName
        $poolName = $env.newPoolName

        $body = @{
            properties = @{
                computeModel = @{
                    type = 'Provisioned'
                    computeProcessor = 'Intel'
                    computeGeneration = 1
                    vCores = 2
                }
                scheduledMaintenance = @{
                    maintenanceManagementType = 'System'
                }
                nodeCount = 1
                highAvailability = @{
                    mode = 'Disabled'
                }
            }
        } | ConvertTo-Json -Depth 5

        $pool = New-AzHorizonDbPool -ResourceGroupName $resourceGroupName -ClusterName $newClusterName -Name $poolName -SubscriptionId $env.SubscriptionId -JsonString $body -ErrorAction Stop

        $pool.Name | Should -Be $poolName
        $pool.ResourceGroupName | Should -Be $resourceGroupName
        $pool.ComputeModelType | Should -Be 'Provisioned'
        $pool.ComputeModelComputeProcessor | Should -Be 'Intel'
        $pool.ComputeModelComputeGeneration | Should -Be 1
        $pool.ComputeModelVCore | Should -Be 2
        $pool.NodeCount | Should -Be 1
        $pool.HighAvailabilityMode | Should -Be 'Disabled'
        $pool.State | Should -Be 'Ready'
        $pool.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityClusterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
