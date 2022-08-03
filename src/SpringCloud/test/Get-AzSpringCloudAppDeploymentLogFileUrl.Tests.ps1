if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudAppDeploymentLogFileUrl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudAppDeploymentLogFileUrl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudAppDeploymentLogFileUrl' {
    It 'Get' {
        { Get-AzSpringCloudAppDeploymentLogFileUrl -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name $env.greenDeploymentName } | Should -Not -Throw
    }
}
