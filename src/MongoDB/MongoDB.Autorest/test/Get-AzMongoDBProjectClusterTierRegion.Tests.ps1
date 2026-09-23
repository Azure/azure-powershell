if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMongoDBProjectClusterTierRegion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMongoDBProjectClusterTierRegion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMongoDBProjectClusterTierRegion' {
    It 'List' {
        {
            $result = Get-AzMongoDBProjectClusterTierRegion -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -ProjectName $env.ProjectName
            $result.OrganizationId | Should -Not -BeNullOrEmpty
            $result.ProjectId | Should -Not -BeNullOrEmpty
            $result.RegionsByTier | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
