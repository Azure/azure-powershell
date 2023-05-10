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

Describe 'New-AzElasticSanVolume' {
    It 'CreateExpanded' {
        $volGroupName = "testvol" + $env.RandomString
        $volume = New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $volGroupName -SizeGib 100  -CreationDataSourceUri 'https://abc.com' -Tag @{tag1="value1";tag2="value2"} -CreationDataCreateSource 'None'
        $volume.Name | Should -Be $volGroupName 
        $volume.SizeGiB | Should -Be 100
        $volume.CreationDataSourceUri | Should -Be 'https://abc.com'
        $volume.Tag.Count  | Should -BeGreaterOrEqual 1 
        $volume.CreationDataCreateSource | Should -Be 'None'
    }
}
