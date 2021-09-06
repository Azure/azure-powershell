if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticMonitor' {
    It 'UpdateExpanded' {
        $elastic = Update-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01 -Tag @{'key01' = 1; 'key02' = 2; 'key03' = 3}
        $elastic.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentityExpanded' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        $elastic = Update-AzElasticMonitor -InputObject $elastic -Tag @{'key01' = 1; 'key02' = 2; 'key03' = 3; 'key04' = 4}
        $elastic.Tag.Count | Should -Be 4
    }
}
