if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNeonPostgresNeonDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNeonPostgresNeonDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Define variables directly in the script
$resourceName = "NeonDemoOrgPS1"
$resourceGroupName = "neonrg"
$subscriptionId = "a81c0054-6c92-41aa-a235-4f9f98f917c6"
$projectId = "dawn-breeze-86932057"
$branchId = "br-damp-bird-a82olmcu"

Describe 'Get-AzNeonPostgresNeonDatabase' {
    It 'List' {
        { 
            $result = Get-AzNeonPostgresNeonDatabase -BranchName $branchId -ProjectName $projectId -OrganizationName $resourceName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId
            $result.Count | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }
}
