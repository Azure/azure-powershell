if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSpringAppActiveDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringAppActiveDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSpringAppActiveDeployment' {
    It 'SetExpanded' {
        { Update-AzSpringAppActiveDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name $env.appGateway -DeploymentName $env.greenDeploymentName } | Should -Not -Throw
    }
}
