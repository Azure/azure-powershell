if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoveryNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoveryNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoveryNodePool' {
    It 'CreateExpanded' {
        $result = New-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNew -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -SubnetId $env.NodePoolSubnetId `
            -VMSize 'Standard_D4s_v6' -MinNodeCount 0 -MaxNodeCount 1 `
            -OSDiskSizeGb 128 -ScaleSetPriority 'Regular' `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.NodePoolNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            location = $env.location
            properties = @{
                subnetId = $env.NodePoolSubnetId
                vmSize = 'Standard_D4s_v6'
                minNodeCount = 0
                maxNodeCount = 1
                osDiskSizeGb = 128
                scaleSetPriority = 'Regular'
            }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNewJson -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.NodePoolNameForNewJson
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-nodepool-test.json'
        try {
            $json = @{
                location = $env.location
                properties = @{
                    subnetId = $env.NodePoolSubnetId
                    vmSize = 'Standard_D4s_v6'
                    minNodeCount = 0
                    maxNodeCount = 1
                    osDiskSizeGb = 128
                    scaleSetPriority = 'Regular'
                }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
                -SupercomputerName $env.SupercomputerNameForGet `
                -Name $env.NodePoolNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -Location $env.location `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.NodePoolNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaIdentitySupercomputerExpanded' -Skip {
        $supercomputer = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result = New-AzDiscoveryNodePool -SupercomputerInputObject $supercomputer `
            -Name $env.NodePoolNameForNewViaPar `
            -Location $env.location `
            -SubnetId $env.NodePoolSubnetId `
            -VMSize 'Standard_D4s_v6' -MinNodeCount 0 -MaxNodeCount 1 `
            -OSDiskSizeGb 128 -ScaleSetPriority 'Regular' `
            -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.NodePoolNameForNewViaPar
    }
}
