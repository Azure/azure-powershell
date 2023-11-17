if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticSanVolumeGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticSanVolumeGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticSanVolumeGroup' {
    It 'List' {
        $volGroups = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1
        $volGroups.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get'  {
        $volGRoup = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName
        $volGroup.Name | Should -Be $env.VolumeGroupName
        $volGroup.ProtocolType | Should -Be "Iscsi"
        $volGroup.Encryption | Should -Be "EncryptionAtRestWithPlatformKey"
    }
}
