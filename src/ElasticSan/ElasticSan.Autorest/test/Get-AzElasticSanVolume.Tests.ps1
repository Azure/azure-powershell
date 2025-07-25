if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticSanVolume'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticSanVolume.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticSanVolume' {
    It 'List' {
        $volumes = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName
        $volumes.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $volume = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $env.VolumeName
        $volume.Name | Should -Be $env.VolumeName
        $volume.SizeGiB | Should -Be 100
    }
}
