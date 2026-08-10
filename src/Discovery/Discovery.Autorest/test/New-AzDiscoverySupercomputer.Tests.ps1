if(($null -eq $TestName) -or ($TestName -contains 'New-AzDiscoverySupercomputer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiscoverySupercomputer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDiscoverySupercomputer' {
    It 'CreateExpanded' {
        New-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNew -Location $env.location `
            -SubnetId $env.ScSubnetId `
            -ClusterIdentityId $env.UamiSwcId -KubeletIdentityId $env.UamiSwcId `
            -IdentityWorkloadIdentity @{$env.UamiSwcId = @{}} `
            -OutboundType 'LoadBalancer' -SystemSku 'Standard_D4s_v6' `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'} -Confirm:$false | Out-Null

        $result = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNew -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.SupercomputerNameForNew
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -Skip {
        $jsonPath = Join-Path $PSScriptRoot 'new-supercomputer-test.json'
        try {
            $json = @{
                location = $env.location
                properties = @{
                    subnetId = $env.ScSubnetId
                    clusterIdentity = @{ resourceId = $env.UamiSwcId }
                    kubeletIdentity = @{ resourceId = $env.UamiSwcId }
                    outboundType = 'LoadBalancer'
                    systemProfile = @{ vmSize = 'Standard_D4s_v6' }
                }
                identity = @{
                    type = 'UserAssigned'
                    userAssignedIdentities = @{ $env.UamiSwcId = @{} }
                }
                tags = @{ test = 'powershell-jsonfile'; SkipAssociateKeyVaultToNsp = 'True' }
            } | ConvertTo-Json -Depth 10
            $json | Set-Content -Path $jsonPath

            $result = New-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
                -Name $env.SupercomputerNameForNewJsonFile -SubscriptionId $env.SubscriptionId `
                -JsonFilePath $jsonPath -Confirm:$false
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.SupercomputerNameForNewJsonFile
        }
        finally {
            Remove-Item -Path $jsonPath -ErrorAction SilentlyContinue
        }
    }

    It 'CreateViaJsonString' -Skip {
        $json = @{
            location = $env.location
            properties = @{
                subnetId = $env.ScSubnetId
                clusterIdentity = @{ resourceId = $env.UamiSwcId }
                kubeletIdentity = @{ resourceId = $env.UamiSwcId }
                outboundType = 'LoadBalancer'
                systemProfile = @{ vmSize = 'Standard_D4s_v6' }
            }
            identity = @{
                type = 'UserAssigned'
                userAssignedIdentities = @{ $env.UamiSwcId = @{} }
            }
            tags = @{ test = 'powershell-json'; SkipAssociateKeyVaultToNsp = 'True' }
        } | ConvertTo-Json -Depth 10

        $result = New-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNewJson -SubscriptionId $env.SubscriptionId `
            -JsonString $json -Confirm:$false
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.SupercomputerNameForNewJson
    }
}
