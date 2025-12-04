if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAksArcCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAksArcCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Should be run in live mode only because the Remove-AzAksArcCluster cleanup call makes an Invoke-AzRestMethod that is 
# not supported by autorest playback.
Describe 'Update-AzAksArcCluster' -Tag 'LiveOnly' {
    BeforeAll {
        if (!$env.updateCluster) {
            Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
            $uniqueNumbers = Get-RandomNumbers -Count 1
            Add-Member -InputObject $env -MemberType NoteProperty -Name "updateCluster" -Value "updateCluster$($uniqueNumbers[0])"
        }
        $sshKeyValue = (Get-Content -Path (Join-Path -Path $PSScriptRoot -ChildPath "test-rsa.pub") -Raw).Trim()
        # This command needs Az.Accounts installed and imported.
        $testGroupOID = $env.testGroupOID
        # Make sure to update this version to one available for your environment.
        $k8sVersion = "1.32.6"
        $minCount = 1
        $maxCount = 2
        $controlPlaneCount = 1
        # This command needs Az.Resources installed and imported.
        $subscriptionId = (Get-AzContext).Subscription.Id
        $autoScalerProfileScanInterval = "30s"
        $autoScalerProfileScaleDownDelayAfterAdd = "10m"
        $autoScalerProfileScaleDownDelayAfterDelete = "30s"
        $autoScalerProfileScaleDownDelayAfterFailure = "3m"
        $autoScalerProfileScaleDownUnneededTime = "10m"
        $autoScalerProfileScaleDownUnreadyTime = "20m"
        $autoScalerProfileScaleDownUtilizationThreshold = "0.5"
        $autoScalerProfileMaxGracefulTerminationSec = "600"
        $autoScalerProfileBalanceSimilarNodeGroup = "true"
        $autoScalerProfileExpander = "random"
        $autoScalerProfileSkipNodesWithLocalStorage = "true"
        $autoScalerProfileSkipNodesWithSystemPod = "true"
        $autoScalerProfileMaxEmptyBulkDelete = "10"
        $autoScalerProfileNewPodScaleUpDelay = "0s"
        $autoScalerProfileMaxTotalUnreadyPercentage = "45"
        $autoScalerProfileMaxNodeProvisionTime = "15m"
        $autoScalerProfileOkTotalUnreadyCount = "3"

        function Test-Cluster {
            param ($Cluster)
            $Cluster | Should -Not -BeNullOrEmpty
            $Cluster.ProvisioningState | Should -Be 'Succeeded'
            # Skip checking AgentPoolProfile since it does not reflect any property changes of actual nodepool at the 
            # time of this comment.
            $Cluster.ControlPlaneCount | Should -Be $controlPlaneCount
            $Cluster.KubernetesVersion | Should -Be $k8sVersion
            $Cluster.LicenseProfileAzureHybridBenefit | Should -BeTrue
            $Cluster.NfCsiDriverEnabled | Should -BeTrue
            $Cluster.SmbCsiDriverEnabled | Should -BeTrue
            $Cluster.AutoScalerProfileBalanceSimilarNodeGroup | Should -Be $autoScalerProfileBalanceSimilarNodeGroup
            $Cluster.AutoScalerProfileExpander | Should -Be $autoScalerProfileExpander
            $Cluster.AutoScalerProfileMaxEmptyBulkDelete | Should -Be $autoScalerProfileMaxEmptyBulkDelete
            $Cluster.AutoScalerProfileMaxGracefulTerminationSec | Should -Be $autoScalerProfileMaxGracefulTerminationSec
            $Cluster.AutoScalerProfileMaxNodeProvisionTime | Should -Be $autoScalerProfileMaxNodeProvisionTime
            $Cluster.AutoScalerProfileMaxTotalUnreadyPercentage | Should -Be $autoScalerProfileMaxTotalUnreadyPercentage
            $Cluster.AutoScalerProfileNewPodScaleUpDelay | Should -Be $autoScalerProfileNewPodScaleUpDelay
            $Cluster.AutoScalerProfileOkTotalUnreadyCount | Should -Be $autoScalerProfileOkTotalUnreadyCount
            $Cluster.AutoScalerProfileScaleDownDelayAfterAdd | Should -Be $autoScalerProfileScaleDownDelayAfterAdd
            $Cluster.AutoScalerProfileScaleDownDelayAfterDelete | Should -Be $autoScalerProfileScaleDownDelayAfterDelete
            $Cluster.AutoScalerProfileScaleDownDelayAfterFailure | Should -Be $autoScalerProfileScaleDownDelayAfterFailure
            $Cluster.AutoScalerProfileScaleDownUnneededTime | Should -Be $autoScalerProfileScaleDownUnneededTime
            $Cluster.AutoScalerProfileScaleDownUnreadyTime | Should -Be $autoScalerProfileScaleDownUnreadyTime
            $Cluster.AutoScalerProfileScaleDownUtilizationThreshold | Should -Be $autoScalerProfileScaleDownUtilizationThreshold
            $Cluster.AutoScalerProfileScanInterval | Should -Be $autoScalerProfileScanInterval
            $Cluster.AutoScalerProfileSkipNodesWithLocalStorage | Should -Be $autoScalerProfileSkipNodesWithLocalStorage
            $Cluster.AutoScalerProfileSkipNodesWithSystemPod | Should -Be $autoScalerProfileSkipNodesWithSystemPod
        }
        function Test-Nodepool {
            param ($Nodepool)
            $Nodepool | Should -Not -BeNullOrEmpty
            # Force $Nodepool to become an array before checking the count because a Nodepool object also has a count
            # property, but we want to access the count property of the collection and not the nodepool.
            @($Nodepool).Count | Should -Be 1
            $Nodepool.ProvisioningState | Should -Be 'Succeeded'
            $Nodepool.MinCount | Should -Be $minCount
            $Nodepool.MaxCount | Should -Be $maxCount
            $Nodepool.EnableAutoScaling | Should -BeTrue
        }
    }
    AfterAll {
        Remove-AzAksArcCluster `
            -ClusterName $env.updateCluster `
            -ResourceGroupName $env.resourceGroupName
    }
    It 'UpdateExpanded' {
        $cluster = New-AzAksArcCluster `
            -ClusterName $env.updateCluster `
            -ResourceGroupName $env.resourceGroupName  `
            -CustomLocationName $env.customLocationName `
            -VnetId $env.lnetID `
            -SshKeyValue $sshKeyValue `
            -KubernetesVersion $k8sVersion
        $cluster | Should -Not -BeNullOrEmpty
        $cluster.ProvisioningState | Should -Be 'Succeeded'
        # For some reason the default type is a "False" string instead of boolean.
        # The statement "$Cluster.LicenseProfileAzureHybridBenefit -eq $false" will be true because of type conversion,
        # but not true for "$Cluster.LicenseProfileAzureHybridBenefit | Should -BeFalse" since Pester doesn't do this
        # type conversion.
        $Cluster.LicenseProfileAzureHybridBenefit | Should -Be "False"
        $Cluster.NfCsiDriverEnabled | Should -BeFalse
        $Cluster.SmbCsiDriverEnabled | Should -BeFalse
        $updatedCluster = Update-AzAksArcCluster `
            -ClusterName $env.updateCluster `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $subscriptionId `
            -MinCount $minCount `
            -MaxCount $maxCount `
            -AdminGroupObjectID $testGroupOID `
            -ControlPlaneCount $controlPlaneCount `
            -EnableAzureHybridBenefit `
            -NfCsiDriverEnabled `
            -SmbCsiDriverEnabled `
            -EnableAutoScaling `
            -AutoScalerProfileScanInterval $autoScalerProfileScanInterval `
            -AutoScalerProfileScaleDownDelayAfterAdd $autoScalerProfileScaleDownDelayAfterAdd `
            -AutoScalerProfileScaleDownDelayAfterDelete $autoScalerProfileScaleDownDelayAfterDelete `
            -AutoScalerProfileScaleDownDelayAfterFailure $autoScalerProfileScaleDownDelayAfterFailure `
            -AutoScalerProfileScaleDownUnneededTime $autoScalerProfileScaleDownUnneededTime `
            -AutoScalerProfileScaleDownUnreadyTime $autoScalerProfileScaleDownUnreadyTime `
            -AutoScalerProfileScaleDownUtilizationThreshold $autoScalerProfileScaleDownUtilizationThreshold `
            -AutoScalerProfileMaxGracefulTerminationSec $autoScalerProfileMaxGracefulTerminationSec `
            -AutoScalerProfileBalanceSimilarNodeGroup $autoScalerProfileBalanceSimilarNodeGroup `
            -AutoScalerProfileExpander $autoScalerProfileExpander `
            -AutoScalerProfileSkipNodesWithLocalStorage $autoScalerProfileSkipNodesWithLocalStorage `
            -AutoScalerProfileSkipNodesWithSystemPod $autoScalerProfileSkipNodesWithSystemPod `
            -AutoScalerProfileMaxEmptyBulkDelete $autoScalerProfileMaxEmptyBulkDelete `
            -AutoScalerProfileNewPodScaleUpDelay $autoScalerProfileNewPodScaleUpDelay `
            -AutoScalerProfileMaxTotalUnreadyPercentage $autoScalerProfileMaxTotalUnreadyPercentage `
            -AutoScalerProfileMaxNodeProvisionTime $autoScalerProfileMaxNodeProvisionTime `
            -AutoScalerProfileOkTotalUnreadyCount $autoScalerProfileOkTotalUnreadyCount
        # Should only be one nodepool by default.
        $updatedNodepool = Get-AzAksArcNodepool `
            -ClusterName $env.updateCluster `
            -ResourceGroupName $env.resourceGroupName
        Test-Cluster -Cluster $updatedCluster
        Test-Nodepool -Nodepool $updatedNodepool
    }
}
