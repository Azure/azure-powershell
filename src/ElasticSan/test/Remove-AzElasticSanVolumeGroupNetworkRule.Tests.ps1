if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzElasticSanVolumeGroupNetworkRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzElasticSanVolumeGroupNetworkRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzElasticSanVolumeGroupNetworkRule' {
    It 'NetworkRuleResourceId' {
        # Clear exsiting rules 
        Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName -NetworkAclsVirtualNetworkRule @()    
        # Add rules 
        $rules = Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -NetworkAclsVirtualNetworkResourceId $env.vnetResourceId1,$env.vnetResourceId2
        $rules.Count | Should -Be 2 

        $rules = Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -NetworkAclsVirtualNetworkResourceId $env.vnetResourceId1,$env.vnetResourceId2
        $rules.Count | Should -Be 0
    }

    It 'NetworkRuleObject' {
        $vnetRule1 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId1 -Action "Allow"
        $vnetRule2 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId2 -Action "Allow"
        # Clear exsiting rules 
        Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName -NetworkAclsVirtualNetworkRule @()    
        # Add rules 
        $rules = Add-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -NetworkAclsVirtualNetworkRule $vnetRule1,$vnetRule2
        $rules.Count | Should -Be 2

        $rules = Remove-AzElasticSanVolumeGroupNetworkRule -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -NetworkAclsVirtualNetworkRule $vnetRule1,$vnetRule2
        $rules.Count | Should -Be 0
    }
}
