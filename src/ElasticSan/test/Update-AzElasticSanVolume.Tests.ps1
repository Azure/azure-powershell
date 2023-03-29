if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticSanVolume'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticSanVolume.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticSanVolume' {
    It 'UpdateExpanded' {
        $volume = Update-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $env.VolumeName -Tag @{tag3 = "value3"} -SizeGib 120
        $volume.Name | Should -Be $env.VolumeName
        $volume.SizeGiB | Should -Be 120
        $volume.Tag.Count | Should -Be 1      

        $volume = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $env.VolumeName
        $volume.Name | Should -Be $env.VolumeName
        $volume.SizeGiB | Should -Be 120
        $volume.Tag.Count | Should -Be 1   
    }
}
