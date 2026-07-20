if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDynatraceMonitorSSOConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDynatraceMonitorSSOConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

    # Fallbacks: always supply workable defaults if values remain empty after env load
    if ([string]::IsNullOrWhiteSpace($MonitorName)) {
        if ($env.dynatraceName01) { $MonitorName = $env.dynatraceName01 } else { $MonitorName = "dynatrace-monitor-" + (Get-Random) }
    }
    if ([string]::IsNullOrWhiteSpace($ResourceGroupName)) {
        if ($env.resourceGroup) { $ResourceGroupName = $env.resourceGroup } else { $ResourceGroupName = "rg-dynatrace-test" }
    }
}

Describe 'Update-AzDynatraceMonitorSSOConfig' {
    BeforeAll {
        # Standardize root reference like other tests
        $TestRoot = $PSScriptRoot
    }
    Context 'UpdateExpanded parameter set' {
        It 'Updates SSO config with AadDomain list' {
            # Arrange: assume env variables or loadEnv set $MonitorName, $ResourceGroupName
            # Use a sample domain; playback recording should match prior capture
            $domains = @("mpliftrlogz20210811outlook.onmicrosoft.com")

            # Act
            $result = Update-AzDynatraceMonitorSSOConfig -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -AadDomain $domains -Confirm:$false

            # Assert
            $result | Should -Not -BeNullOrEmpty
            if ($result.PSObject.Properties.Name -contains 'AadDomain') {
                ($result.AadDomain -join ',') | Should -Match 'mpliftrlogz20210811outlook.onmicrosoft.com'
            }
        }
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityMonitorExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
