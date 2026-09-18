if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksArcNodepool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksArcNodepool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Forced to skip for now since autorest doesn't support playback with Az commands in custom file.
Describe 'New-AzAksArcNodepool' -Tag 'LiveOnly' {
    BeforeAll {
        if (!$env.newPool1 -or !$env.newPool2 -or !$env.newPool3) {
            Import-Module (Join-Path -Path $PSScriptRoot -ChildPath 'AzAksArcTestHelper.psm1')
            $uniqueNumbers = Get-RandomNumbers -Count 3
            # Nodepool names must be lowercase and have a maximum of 12 characters.
            Add-Member -InputObject $env -MemberType NoteProperty -Name "newPool1" -Value "newpool1$($uniqueNumbers[0])"
            Add-Member -InputObject $env -MemberType NoteProperty -Name "newPool2" -Value "newpool2$($uniqueNumbers[1])"
            Add-Member -InputObject $env -MemberType NoteProperty -Name "newPool3" -Value "newpool3$($uniqueNumbers[2])"
        }
        $nodeLabelKey = "labelKey"
        $nodeLabelValue = "labelValue"
        $nodeLabel = @{ $nodeLabelKey = $nodeLabelValue}
        $nodeTaint = @("taintKey=taintValue:NoSchedule")
        $vmSize = "Standard_A4_v2"
        $count = 1
        $osSku = "CBLMariner"
        $osType = "Linux"
        $tagKey1 = "tagKey1"
        $tagKey2 = "tagKey2"
        $tags = @{ $tagKey1 = "tagValue1"; $tagKey2 = "tagValue2" }
        $maxPod = 30
        $minCount = 1
        $maxCount = 2
        $type = "microsoft.hybridcontainerservice/provisionedclusterinstances/agentpools"

        $jsonString = @"
{
  "properties": {
    "osType": "$osType",
    "osSKU": "$osSku",
    "nodeLabels": {
      "$nodeLabelKey": "$nodeLabelValue"
    },
    "nodeTaints": [
      "$($nodeTaint[0])"
    ],
    "maxCount": $maxCount,
    "minCount": $minCount,
    "enableAutoScaling": true,
    "maxPods": $maxPod,
    "count": $count,
    "vmSize": "$vmSize"
  },
  "tags": {
    "$tagKey2": "$($tags[$tagKey2])",
    "$tagKey1": "$($tags[$tagKey1])"
  }
}
"@
        function Test-NodePool {
            param($NodePool)
            $NodePool | Should -Not -BeNullOrEmpty
            $NodePool.ProvisioningState | Should -Be "Succeeded"
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
            -Name $env.newPool1
        Remove-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool2
        Remove-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool3
    }
    It 'CreateExpanded' {
        $nodepool = New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool1 `
            -NodeLabel $nodeLabel  `
            -NodeTaint $nodeTaint `
            -VMSize $vmSize `
            -Count $count `
            -OSSku $osSku `
            -OSType $osType  `
            -Tag $tags `
            -MaxPod $maxPod `
            -EnableAutoScaling `
            -MinCount $minCount `
            -MaxCount $maxCount
        $nodePoolGet = Get-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool1
        $nodePoolGet.Id | Should -Be $nodepool.Id
        Test-NodePool -NodePool $nodePoolGet
    }
    It 'CreateViaJsonFilePath' {
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath "New-AzAksArcNodepool-Params.json"
        $jsonString | Out-File -FilePath $jsonFilePath
        $nodepool = New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool2 `
            -JsonFilePath $jsonFilePath
        $nodePoolGet = Get-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool2
        $nodePoolGet.Id | Should -Be $nodepool.Id
        Test-NodePool -NodePool $nodePoolGet
    }
    It 'CreateViaJsonString' {
        $nodepool = New-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool3 `
            -JsonString $jsonString
        $nodePoolGet = Get-AzAksArcNodepool `
            -ClusterName $env.clusterName `
            -ResourceGroupName $env.resourceGroupName `
            -Name $env.newPool3
        $nodePoolGet.Id | Should -Be $nodepool.Id
        Test-NodePool -NodePool $nodePoolGet
    }
}
