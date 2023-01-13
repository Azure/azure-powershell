if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudConfigurationService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudConfigurationService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudConfigurationService' {
    It 'Get' {
        { 
            Test-AzSpringCloudConfigurationService -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01
            New-AzSpringCloudConfigurationService -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01
            Get-AzSpringCloudConfigurationService -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01
            Remove-AzSpringCloudConfigurationService -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01
        } | Should -Not -Throw
    }
}
