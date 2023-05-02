if(($null -eq $TestName) -or ($TestName -contains 'New-AzElasticSanVolumeGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzElasticSanVolumeGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzElasticSanVolumeGroup' {
    It 'CreateExpanded' {
        $vnetRule1 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId1 -Action "Allow"
        $vnetRule2 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId2 -Action "Allow"
        $volGroupName = 'testvolgroup' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName -ProtocolType 'Iscsi' -Tag @{tag1="value1";tag2="value2"} -NetworkAclsVirtualNetworkRule $vnetRule1,$vnetRule2
        $volGroup.Name | Should -Be $volGroupName
        $volGroup.ProtocolType | Should -Be "Iscsi"
        $volGroup.NetworkAclsVirtualNetworkRule.Count | Should -Be 2
        $volGroup.Tag.Count | Should -Be 2
    }
}
