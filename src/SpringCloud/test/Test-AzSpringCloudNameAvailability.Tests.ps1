if(($null -eq $TestName) -or ($TestName -contains 'Test-AzSpringCloudNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzSpringCloudNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzSpringCloudNameAvailability' {
    It 'CheckExpanded' {
        { Test-AzSpringCloudNameAvailability -Location EastUS -Name springcloud-service -Type "Microsoft.AppPlatform/Spring" } | Should -Not -Throw
    }
}
