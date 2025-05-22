if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCarbonEmissionReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCarbonEmissionReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCarbonEmissionReport' {

    It 'GetCarbonEmissionsOverallSummaryReport' {
        $queryFilter =  New-AzCarbonOverallSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response = Get-AzCarbonEmissionReport -QueryParameter $queryFilter
        $response | Should -Not -Be $null
        $response.Value | Should -Not -Be $null
    }
    It 'GetCarbonEmissionsMonthlySummaryReport' {
        $queryFilter =  New-AzCarbonMonthlySummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3')  -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response = Get-AzCarbonEmissionReport -QueryParameter $queryFilter
        $response | Should -Not -Be $null
        $response.Value | Should -Not -Be $null
    }
    It 'GetCarbonEmissionsTopItemsMonthlySummaryReport' {
        $queryFilter =  New-AzCarbonTopitemsMonthlySummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -TopItem 5 -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response = Get-AzCarbonEmissionReport -QueryParameter $queryFilter
        $response | Should -Not -Be $null
        $response.Value | Should -Not -Be $null
    }
    It 'GetCarbonEmissionsTopItemsSummaryReport' {
        $queryFilter =  New-AzCarbonTopitemsSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -TopItem 5 -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response = Get-AzCarbonEmissionReport -QueryParameter $queryFilter
        $response | Should -Not -Be $null
        $response.Value | Should -Not -Be $null
    }
    It 'GetCarbonEmissionsItemDetailsReport' {
        $queryFilter = New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 100 -SortDirection 'Desc' -SubscriptionList ('1fcfa925-ad8b-443e-afc9-73038125cc86')
        $response = Get-AzCarbonEmissionReport -QueryParameter $queryFilter
        $response | Should -Not -Be $null
        $response.Value | Should -Not -Be $null
    }
}
