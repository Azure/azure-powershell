if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAksArcNodepool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAksArcNodepool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Run in live only since autorest doesn't support playback with Az commands in custom file.
Describe 'Update-AzAksArcNodepool' -Tag 'LiveOnly' {
    BeforeAll {
        if (!$env.updatePool1 -or !$env.updatePool2) {
            Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
            $uniqueNumbers = Get-RandomNumbers -Count 2
	        # Nodepool names must be lowercase and have a maximum of 12 characters.
            Add-Member -InputObject $env -MemberType NoteProperty -Name "updatePool1" -Value "udpool1$($uniqueNumbers[0])"
            Add-Member -InputObject $env -MemberType NoteProperty -Name "updatePool2" -Value "udpool2$($uniqueNumbers[1])"
        }
        $nodeLabelKey = "labelKey"
        $nodeLabelValue = "labelValue"
        $nodeLabel = @{ $nodeLabelKey = $nodeLabelValue}
        $nodeTaint = @("taintKey=taintValue:NoSchedule")
        $vmSize = "Standard_A2_v2"
        $count = 2
        # Windows OS SKU is disabled by default. As a result, we cannot run live tests with Windows nodepools unless
        # it is enabled in the environment.
        # $osSku = "Windows2022"
        # $osType = "Windows"
        # These variables are here only to validate that the OS didn't change.
        $osSku = "CBLMariner"
        $osType = "Linux"
        $tagKey1 = "tagKey1"
        $tagKey2 = "tagKey2"
        $tags = @{ $tagKey1 = "tagValue1"; $tagKey2 = "tagValue2" }
        $maxPod = 30
        $minCount = 1
        $maxCount = 2
        $type = "microsoft.hybridcontainerservice/provisionedclusterinstances/agentpools"
        function Test-NodePool {
            param($NodePool)
            $NodePool | Should -Not -BeNullOrEmpty
            $NodePool.StatusCurrentState | Should -Be "Succeeded"
            $NodePool.Type | Should -Be $type
            # Compare with the passed-in variables to verify that the properties are the same as what was passed.
            $NodePool.NodeLabel.Keys.Count | Should -Be 1
            ($NodePool.NodeLabel.Keys | Select-Object -First 1) | Should -Be $nodeLabelKey
            ($NodePool.NodeLabel.Values | Select-Object -First 1) | Should -Be $nodeLabelValue
            $NodePool.NodeTaint.Count | Should -Be 1
            $NodePool.NodeTaint[0] | Should -Be $nodeTaint[0]
            $NodePool.VMSize | Should -Be $vmSize
            $NodePool.Count | Should -Be $count
            $NodePool.OSSku | Should -Be $osSku
            $NodePool.OSType | Should -Be $osType
            $NodePool.Tag.ContainsKey($tagKey1) | Should -BeTrue
            $NodePool.Tag.ContainsKey($tagKey2) | Should -BeTrue
            $NodePool.Tag[$tagKey1] | Should -Be $tags[$tagKey1]
            $NodePool.Tag[$tagKey2] | Should -Be $tags[$tagKey2]
            $NodePool.MaxPod | Should -Be $maxPod
            $NodePool.EnableAutoScaling | Should -BeTrue
            $NodePool.MinCount | Should -Be $minCount
            $NodePool.MaxCount | Should -Be $maxCount
        }
    }
    AfterAll {
        Remove-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool1
        Remove-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool2
    }
    It 'UpdateExpanded' {
        New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool1
        # Update all properties before -EnableAutoScaling since that blocks updating -Count.
        Update-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool1 `
            -Count $count `
            -MaxPod $maxPod `
            -MinCount $minCount `
            -MaxCount $maxCount `
            -NodeLabel $nodeLabel `
            -NodeTaint $nodeTaint `
            -Tag $tags
        # VMSize must be updated separately from EnableAutoScaling.
        $updated = Update-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool1 `
            -VMSize $vmSize
        $updated = Update-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool1 `
            -EnableAutoScaling 
        $updated | Should -Not -BeNullOrEmpty
        Test-NodePool -NodePool $updated
    }
    It 'UpdateViaIdentityExpanded' {
        $poolToUpdate = New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.updatePool2
        # Update all properties before -EnableAutoScaling since that blocks updating -Count.
        $updated = $poolToUpdate | Update-AzAksArcNodepool `
            -Count $count `
            -MaxPod $maxPod `
            -MinCount $minCount `
            -MaxCount $maxCount `
            -NodeLabel $nodeLabel `
            -NodeTaint $nodeTaint `
            -Tag $tags
        # VMSize must be updated separately from EnableAutoScaling.
        $updated = $poolToUpdate | Update-AzAksArcNodepool `
            -VMSize $vmSize
        $updated = $poolToUpdate | Update-AzAksArcNodepool `
            -EnableAutoScaling 
        $updated | Should -Not -BeNullOrEmpty
        Test-NodePool -NodePool $updated
    }
}
