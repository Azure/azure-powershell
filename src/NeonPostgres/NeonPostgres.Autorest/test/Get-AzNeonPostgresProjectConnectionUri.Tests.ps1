if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNeonPostgresProjectConnectionUri'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNeonPostgresProjectConnectionUri.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNeonPostgresProjectConnectionUri' {
    It 'Get' {
        { 
            $result = Get-AzNeonPostgresProjectConnectionUri -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ProjectId "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "a81c0054-6c92-41aa-a235-4f9f98f917c6" -BranchId "br-damp-bird-a82olmcu" -DatabaseName "neondb" -EndpointId "ep-spring-cake-a88oisqp" -RoleName "neondb_owner"
            $result.Count | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }
}
