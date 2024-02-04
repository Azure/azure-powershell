if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticSanVolumeGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticSanVolumeGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticSanVolumeGroup' {
    It 'UpdateExpanded' {
        $vnetRule1 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId1 -Action "Allow"
        $vnetRule2 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId2 -Action "Allow"
        $volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName -ProtocolType 'None' -NetworkAclsVirtualNetworkRule $vnetRule1,$vnetRule2
        $volGroup.Name | Should -Be $env.VolumeGroupName
        $volGroup.ProtocolType | Should -Be 'None'
        $volGroup.NetworkAclsVirtualNetworkRule.Count | Should -Be 2 

        $volGroup = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName
        $volGroup.Name | Should -Be $env.VolumeGroupName
        $volGroup.ProtocolType | Should -Be 'None'
        $volGroup.NetworkAclsVirtualNetworkRule.Count | Should -Be 2 
    }   
}
