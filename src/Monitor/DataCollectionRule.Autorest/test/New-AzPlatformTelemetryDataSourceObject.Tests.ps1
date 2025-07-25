if(($null -eq $TestName) -or ($TestName -contains 'New-AzPlatformTelemetryDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPlatformTelemetryDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPlatformTelemetryDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzPlatformTelemetryDataSourceObject -Stream "Microsoft.Insights/autoscalesettings:Logs-AutoscaleEvaluations","Microsoft.Insights/autoscalesettings:Logs-AutoscaleScaleActions" -Name "myAutoScalePlatformTelemetryLogs"
        } | Should -Not -Throw
    }
}
