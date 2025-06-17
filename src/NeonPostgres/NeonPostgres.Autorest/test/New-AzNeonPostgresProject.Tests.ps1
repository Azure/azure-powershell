if(($null -eq $TestName) -or ($TestName -contains 'New-AzNeonPostgresProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNeonPostgresProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNeonPostgresProject' {
    It 'CreateExpanded' {
        { New-AzNeonPostgresProject -Name "test-project" -OrganizationName "NeonDemoOrgPS1" -ResourceGroupName "neonrg" -SubscriptionId "a81c0054-6c92-41aa-a235-4f9f98f917c6" -BranchDatabaseName "sampledb" -BranchEntityName "sample-entity" -BranchParentId "dawn-breeze-86932057" -BranchRoleName "neondb_owner" -RegionId "eastus2" -PgVersion "17" } | Should -Throw 
    }
}
