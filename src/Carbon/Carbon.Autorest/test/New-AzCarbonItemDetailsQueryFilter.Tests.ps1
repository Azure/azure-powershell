if(($null -eq $TestName) -or ($TestName -contains 'New-AzCarbonItemDetailsQueryFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCarbonItemDetailsQueryFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCarbonItemDetailsQueryFilter' {
    It '__AllParameterSets' {
        $response = New-AzCarbonItemDetailsQueryFilter -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 100 -SortDirection 'Desc' -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response | Should -Not -Be $null
    }
}
