if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksArcCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksArcCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Need to run in live only due to Az calls in custom code, which is not supported by autorest playback.
Describe 'New-AzAksArcCluster' -Tag 'LiveOnly' {
  BeforeAll {
    if (!$env.newCluster1 -or !$env.newCluster2 -or !$env.newCluster3) {
      Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
      $uniqueNumbers = Get-RandomNumbers -Count 3
      Add-Member -InputObject $env -MemberType NoteProperty -Name "newCluster1" -Value "newCluster1$($uniqueNumbers[0])"
      Add-Member -InputObject $env -MemberType NoteProperty -Name "newCluster2" -Value "newCluster2$($uniqueNumbers[1])"
      Add-Member -InputObject $env -MemberType NoteProperty -Name "newCluster3" -Value "newCluster3$($uniqueNumbers[2])"
    }
    $sshKeyValue = (Get-Content -Path (Join-Path -Path $PSScriptRoot -ChildPath "test-rsa.pub") -Raw).Trim()
    # May need to update this periodically to update to available versions.
    $k8sVersion = "1.32.6"
    $controlPlaneVmSize = "Standard_A4_v2"
    $minCount = 1
    $maxCount = 2
    $maxPod = 30
    $controlPlaneCount = 1
    $nodeLabelKey = "labelKey"
    $nodeLabelValue = "labelValue"
    $nodeLabel = @{ $nodeLabelKey = $nodeLabelValue}
    $nodeTaint = @("taintKey=taintValue:NoSchedule")
    # By default, the number of supported load balancers is 0. To add load balancers, we will need another module 
    # or SDK to allocate load balancing resources. Therefore, we set it to 0 here.
    $loadBalancerCount = 0
    $podCidr = "10.244.0.0/16" # Default pod CIDR for AKS.
    $testIP = "203.0.113.0" # TEST-NET-3 unused IP address for documentation and examples.
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

    $jsonString = @"
{
"properties": {
  "linuxProfile": {
    "ssh": {
      "publicKeys": [
        {
          "keyData": "$sshKeyValue"
        }
      ]
    }
  },
  "controlPlane": {
    "controlPlaneEndpoint": {
      "hostIP": "$($env.tempProvisionedClusterControlPlaneIP)"
    },
    "count": $controlPlaneCount,
    "vmSize": "$controlPlaneVmSize"
  },
  "networkProfile": {
    "loadBalancerProfile": {
      "count": $loadBalancerCount
    },
    "networkPolicy": "calico",
    "podCidr": "$podCidr"
  },
  "storageProfile": {
    "smbCsiDriver": {
      "enabled": true
    },
    "nfsCsiDriver": {
      "enabled": true
    }
  },
  "clusterVMAccessProfile": {
    "authorizedIPRanges": "$testIP"
  },
  "cloudProviderProfile": {
    "infraNetworkProfile": {
      "vnetSubnetIds": [
        "$($env.lnetID)"
      ]
    }
  },
  "licenseProfile": {
    "azureHybridBenefit": "True"
  },
  "autoScalerProfile": {
    "balance-similar-node-groups": "$autoScalerProfileBalanceSimilarNodeGroup",
    "expander": "$autoScalerProfileExpander",
    "max-empty-bulk-delete": "$autoScalerProfileMaxEmptyBulkDelete",
    "max-graceful-termination-sec": "$autoScalerProfileMaxGracefulTerminationSec",
    "max-node-provision-time": "$autoScalerProfileMaxNodeProvisionTime",
    "max-total-unready-percentage": "$autoScalerProfileMaxTotalUnreadyPercentage",
    "new-pod-scale-up-delay": "$autoScalerProfileNewPodScaleUpDelay",
    "ok-total-unready-count": "$autoScalerProfileOkTotalUnreadyCount",
    "scan-interval": "$autoScalerProfileScanInterval",
    "scale-down-delay-after-add": "$autoScalerProfileScaleDownDelayAfterAdd",
    "scale-down-delay-after-delete": "$autoScalerProfileScaleDownDelayAfterDelete",
    "scale-down-delay-after-failure": "$autoScalerProfileScaleDownDelayAfterFailure",
    "scale-down-unneeded-time": "$autoScalerProfileScaleDownUnneededTime",
    "scale-down-unready-time": "$autoScalerProfileScaleDownUnreadyTime",
    "scale-down-utilization-threshold": "$autoScalerProfileScaleDownUtilizationThreshold",
    "skip-nodes-with-local-storage": "$autoScalerProfileSkipNodesWithLocalStorage",
    "skip-nodes-with-system-pods": "$autoScalerProfileSkipNodesWithSystemPod"
  },
  "kubernetesVersion": "$k8sVersion",
  "agentPoolProfiles": [
    {
      "nodeLabels": {
        "$nodeLabelKey": "$nodeLabelValue"
      },
      "nodeTaints": [
        "$($nodeTaint[0])"
      ],
      "maxCount": $maxCount,
      "minCount": $minCount,
      "enableAutoScaling": true,
      "maxPods": $maxPod
    }
  ]
},
"extendedLocation": {
  "type": "CustomLocation",
  "name": "$($env.customLocationID)"
}
}
"@
    function Test-Cluster {
      param ($Cluster)
      $Cluster | Should -Not -BeNullOrEmpty
      $Cluster.ProvisioningState | Should -Be 'Succeeded'
      $Cluster.AgentPoolProfile.Count | Should -Be 1
      $Cluster.AgentPoolProfile[0].minCount | Should -Be $minCount
      $Cluster.AgentPoolProfile[0].maxCount | Should -Be $maxCount
      $Cluster.AgentPoolProfile[0].maxPod | Should -Be $maxPod
      $Cluster.ControlPlaneEndpointHostIP | Should -Be $env.tempProvisionedClusterControlPlaneIP
      $Cluster.ClusterVMAccessProfileAuthorizedIprange | Should -Be $testIP
      $Cluster.ControlPlaneCount | Should -Be $controlPlaneCount
      $Cluster.ControlPlaneVmSize | Should -Be $controlPlaneVmSize
      $Cluster.KubernetesVersion | Should -Be $k8sVersion
      $Cluster.LicenseProfileAzureHybridBenefit | Should -BeTrue
      $Cluster.LoadBalancerProfileCount | Should -Be $loadBalancerCount
      $Cluster.NetworkProfilePodCidr | Should -Be $podCidr
      $Cluster.NfCsiDriverEnabled | Should -BeTrue
      $Cluster.SmbCsiDriverEnabled | Should -BeTrue
      $Cluster.SshPublicKey.Count | Should -Be 1
      $Cluster.SshPublicKey[0].keyData | Should -Be $sshKeyValue
      $Cluster.AgentPoolProfile[0].enableAutoScaling | Should -BeTrue
      $Cluster.AgentPoolProfile[0].nodeLabel.Count | Should -Be 1
      $Cluster.AgentPoolProfile[0].nodeLabel.ContainsKey($nodeLabelKey) | Should -BeTrue
      $Cluster.AgentPoolProfile[0].nodeLabel[$nodeLabelKey] | Should -Be $nodeLabelValue
      $Cluster.AgentPoolProfile[0].nodeTaint.Count | Should -Be 1
      $Cluster.AgentPoolProfile[0].nodeTaint[0] | Should -Be $nodeTaint
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
  }
  AfterEach {
    Remove-AzAksArcCluster `
      -ClusterName $env.newCluster1 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID
    Remove-AzAksArcCluster `
      -ClusterName $env.newCluster2 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID
    Remove-AzAksArcCluster `
      -ClusterName $env.newCluster3 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID
  }
  It 'CreateExpanded' {
    # See https://learn.microsoft.com/en-us/azure/aks/aksarc/work-with-autoscaler-profiles for autoscaler profiles.
    $cluster = New-AzAksArcCluster `
      -ClusterName $env.newCluster1 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID `
      -CustomLocationName $env.customLocationName `
      -VnetId $env.lnetID `
      -MinCount $minCount `
      -MaxCount $maxCount `
      -MaxPod $maxPod `
      -ControlPlaneIP $env.tempProvisionedClusterControlPlaneIP `
      -Location $env.location `
      -AdminGroupObjectID $env.testGroupOID `
      -SshAuthIp $testIP `
      -ControlPlaneCount $controlPlaneCount `
      -ControlPlaneVmSize $controlPlaneVmSize `
      -KubernetesVersion $k8sVersion `
      -EnableAzureHybridBenefit `
      -EnableAzureRbac `
      -LoadBalancerCount $loadBalancerCount `
      -PodCidr $podCidr `
      -NfCsiDriverEnabled `
      -SmbCsiDriverEnabled `
      -SshKeyValue $sshKeyValue `
      -EnableAutoScaling `
      -NodeLabel $nodeLabel `
      -NodeTaint $nodeTaint `
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
    Test-Cluster -Cluster $cluster
  }

  It 'CreateViaJsonFilePath' {
    $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath "New-AzAksArcCluster-Params.json"
    $jsonString | Out-File -FilePath $jsonFilePath
    $cluster = New-AzAksArcCluster `
      -ClusterName $env.newCluster2 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID `
      -CustomLocationName $env.customLocationName `
      -JsonFilePath $jsonFilePath
    Test-Cluster -Cluster $cluster
  }

  It 'CreateViaJsonString' {
    $cluster = New-AzAksArcCluster `
      -ClusterName $env.newCluster3 `
      -ResourceGroupName $env.resourceGroupName `
      -SubscriptionId $env.subscriptionID `
      -CustomLocationName $env.customLocationName `
      -JsonString $jsonString
    Test-Cluster -Cluster $cluster
  }
}
