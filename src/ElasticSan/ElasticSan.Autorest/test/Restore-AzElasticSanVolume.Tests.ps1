if(($null -eq $TestName) -or ($TestName -contains 'Restore-AzElasticSanVolume'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzElasticSanVolume.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restore-AzElasticSanVolume' {
    It 'Restore' {
        $volName = "testvol321" + $env.RandomString
        $vgName = "testesvg321" + $env.RandomString
        $vg = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $vgName -DeleteRetentionPolicyRetentionPeriodDay 7 -DeleteRetentionPolicyState Enabled
        $volume = New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -Name $volName -SizeGiB 1 
        $volume.Name | Should -Be $volName 
        $volume.SizeGiB | Should -Be 1

        Remove-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -Name $volName

        $volumeList = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -AccessSoftDeletedResource true
        ($volumeList| ? {$_.Name -like "$($volName)*"} ).count | Should -Not -Be 0
        $volumeToRestore = $volumeList| ? {$_.Name -like "$($volName)*"} | select-object -first 1

        Restore-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -Name $volumeToRestore.Name

        $volumeList = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName
        $volumeList.Name | Should -Contain $volName

        Remove-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -Name $volName
        $volumeList = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -AccessSoftDeletedResource true
        ($volumeList| ? {$_.Name -like "$($volName)*"} ).count | Should -Not -Be 0
        $firstVolume = $volumeList| ? {$_.Name -like "$($volName)*"} | select-object -first 1
        Remove-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -Name $firstVolume.Name -DeleteType permanent

        $volumeList = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $vgName -AccessSoftDeletedResource true
        $volumeList.Name | Should -Not -Contain $firstVolume.Name
    }
}
