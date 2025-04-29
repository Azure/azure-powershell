if(($null -eq $TestName) -or ($TestName -contains 'New-AzCarbonMonthlySummaryReportQueryFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCarbonMonthlySummaryReportQueryFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCarbonMonthlySummaryReportQueryFilter' {
     It '__AllParameterSets' {
        $response = New-AzCarbonMonthlySummaryReportQueryFilter -CarbonScopeList ('Scope1', 'Scope2', 'Scope3')  -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response | Should -Not -Be $null
    }
}
