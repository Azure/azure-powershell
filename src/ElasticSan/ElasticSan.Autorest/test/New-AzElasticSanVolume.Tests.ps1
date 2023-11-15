if(($null -eq $TestName) -or ($TestName -contains 'New-AzElasticSanVolume'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzElasticSanVolume.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Create/Remove volume, Create/Get/Remove snapshot' {
    It 'CreateExpanded' {
        $volName = "testvol123" + $env.RandomString
        $vgName = "testesvg3" + $env.RandomString
        $volume = New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $volName -SizeGib 100 -CreationDataCreateSource 'None'
        $volume.Name | Should -Be $volName 
        $volume.SizeGiB | Should -Be 100
        $volume.CreationDataCreateSource | Should -Be 'None'

        $vg = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -Name $vgName 
        $volume = New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -Name testesvol1 -SizeGiB 1 
        $volume.Name | Should -be "testesvol1"

        $snapshot = New-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -CreationDataSourceId $volume.Id -Name tests1
        $snapshot.Name | Should -Be "tests1"
        $snapshot.VolumeName | Should -Be "testesvol1"

        $snapshot = Get-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -Name tests1 
        $snapshot.Name | Should -Be "tests1"
        $snapshot.VolumeName | Should -Be "testesvol1"

        $snapshot2 = New-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -CreationDataSourceId $volume.Id -Name tests2
        $snapshot2.Name | Should -Be "tests2"
        $snapshot2.VolumeName | Should -Be "testesvol1"

        $snapshots = Get-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName 
        $snapshots.Count | Should -Be 2

        $snapshots = Get-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -Filter 'volumeName eq testesvol1'
        $snapshots.Count | Should -Be 2

        Remove-AzElasticSanVolumeSnapshot -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -Name tests1 
        Remove-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName2 -ElasticSanName $env.ElasticSanName3 -VolumeGroupName $vgName -Name "testesvol1" -DeleteSnapshot true
        Remove-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $volName
    }
}
