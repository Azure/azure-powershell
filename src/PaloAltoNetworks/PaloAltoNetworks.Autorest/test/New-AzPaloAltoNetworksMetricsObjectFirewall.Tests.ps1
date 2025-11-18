if(($null -eq $TestName) -or ($TestName -contains 'New-AzPaloAltoNetworksMetricsObjectFirewall'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPaloAltoNetworksMetricsObjectFirewall.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPaloAltoNetworksMetricsObjectFirewall' {
    It 'CreateExpanded' {
        $connectionString = "InstrumentationKey=95a645a2-898c-4e40-b285-3f38bbe02e5f;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=b4834f2c-adb3-4319-9e71-0721e949f2df"
        $resourceId = "/subscriptions/2bf4a339-294d-4c25-b0b2-ef649e9f5c27/resourceGroups/06Aug2025/providers/microsoft.insights/components/test-prakgupta3-metrics-ai"
        
        { New-AzPaloAltoNetworksMetricsObjectFirewall -FirewallName "italynorth-test-fw" -ResourceGroupName "eastus-rg" -ApplicationInsightsConnectionString $connectionString -ApplicationInsightsResourceId $resourceId } | Should -Not -Throw
    }
}
