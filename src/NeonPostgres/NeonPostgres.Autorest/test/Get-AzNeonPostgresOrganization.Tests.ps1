if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNeonPostgresOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNeonPostgresOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNeonPostgresOrganization' {
    It 'List' {
        { 
            $result = Get-AzNeonPostgresOrganization -SubscriptionId a81c0054-6c92-41aa-a235-4f9f98f917c6
            $result.Count | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }
}
