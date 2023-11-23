if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudMonitoringSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudMonitoringSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudMonitoringSetting' {
    It 'Get' {
        { 
            Get-AzSpringCloudMonitoringSetting -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Update-AzSpringCloudMonitoringSetting -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        } | Should -Not -Throw
    }
}
