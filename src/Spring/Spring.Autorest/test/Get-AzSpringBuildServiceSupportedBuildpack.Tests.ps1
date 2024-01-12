if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringBuildServiceSupportedBuildpack'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringBuildServiceSupportedBuildpack.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringBuildServiceSupportedBuildpack' {
    It 'List' {
        { Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name 'tanzu-buildpacks-python' } | Should -Not -Throw
    }
}
