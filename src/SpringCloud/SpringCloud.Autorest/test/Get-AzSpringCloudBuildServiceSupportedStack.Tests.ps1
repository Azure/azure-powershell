if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudBuildServiceSupportedStack'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudBuildServiceSupportedStack.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudBuildServiceSupportedStack' {
    It 'List' {
        { Get-AzSpringCloudBuildServiceSupportedStack -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01} | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzSpringCloudBuildServiceSupportedStack -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name io.buildpacks.stacks.bionic-full } | Should -Not -Throw
    }
}
