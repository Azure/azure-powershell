if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzAksArcClusterUpgrade'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAksArcClusterUpgrade.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Should be run in live mode only because the Remove-AzAksArcCluster cleanup call makes an Invoke-AzRestMethod that is 
# not supported by autorest playback.
Describe 'Invoke-AzAksArcClusterUpgrade' -Tag 'LiveOnly' {
    BeforeAll {
        if (!$env.upgradeCluster1 -or !$env.upgradeCluster2) {
            Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
            $uniqueNumbers = Get-RandomNumbers -Count 2
            Add-Member -InputObject $env -MemberType NoteProperty -Name "upgradeCluster1" -Value "upgradeCluster1$($uniqueNumbers[0])"
            Add-Member -InputObject $env -MemberType NoteProperty -Name "upgradeCluster2" -Value "upgradeCluster2$($uniqueNumbers[1])"
        }
        $sshPath = Join-Path -Path $PSScriptRoot -ChildPath "test-rsa"
        $ssh = Get-Content -Path "${sshPath}.pub"
        $versions = (Get-AzAksArcKubernetesVersion -CustomLocationName $env.customLocationName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID).Value
        $sortedVersions = $versions | Sort-Object -Property Version
        # The second to last of sorted versions should always be upgradable.
        $upgradableK8sVersion = @($sortedVersions[-2].PatchVersion.Keys)[-1]
    }
    AfterEach {
        Remove-AzAksArcCluster `
            -ClusterName $env.upgradeCluster1 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        Remove-AzAksArcCluster `
            -ClusterName $env.upgradeCluster2 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
    }
    It 'UpdateExpanded' {
        # This cluster is to test the latest version upgrade.
        New-AzAksArcCluster `
            -ClusterName $env.upgradeCluster1 `
            -ResourceGroupName $env.resourceGroupName  `
            -SubscriptionId $env.subscriptionID `
            -CustomLocationName $env.customLocationName `
            -VnetId $env.lnetID `
            -KubernetesVersion $upgradableK8sVersion `
            -SshKeyValue $ssh
        # The resulting version should be the latest.
        $latestVersion = @($sortedVersions[-1].PatchVersion.Keys)[-1]
        $upgradedCluster = Invoke-AzAksArcClusterUpgrade `
            -ClusterName $env.upgradeCluster1 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $upgradedCluster | Should -Not -BeNullOrEmpty
        $upgradedCluster.ProvisioningState | Should -Be 'Succeeded'
        $upgradedCluster.KubernetesVersion | Should -Be $latestVersion
    }
    It 'Upgrade' {
        # This cluster is to test a specific version upgrade.
        New-AzAksArcCluster `
            -ClusterName $env.upgradeCluster2 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID `
            -CustomLocationName $env.customLocationName `
            -VnetId $env.lnetID `
            -KubernetesVersion $upgradableK8sVersion `
            -SshKeyValue $ssh
        $upgradeToVersion = @($sortedVersions[-1].PatchVersion.Keys)[0]
        $upgradedCluster = Invoke-AzAksArcClusterUpgrade `
            -ClusterName $env.upgradeCluster2 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID `
            -KubernetesVersion $upgradeToVersion
        $upgradedCluster | Should -Not -BeNullOrEmpty
        $upgradedCluster.ProvisioningState | Should -Be 'Succeeded'
        $upgradedCluster.KubernetesVersion | Should -Be $upgradeToVersion
    }
}
