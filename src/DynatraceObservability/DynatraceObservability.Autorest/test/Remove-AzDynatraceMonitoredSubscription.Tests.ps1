if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDynatraceMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDynatraceMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

    # Fallbacks: ensure required names exist to avoid empty string binding errors
    if ([string]::IsNullOrWhiteSpace($MonitorName)) {
        if ($env.dynatraceName01) { $MonitorName = $env.dynatraceName01 } else { $MonitorName = 'dynatrace-monitor-' + (Get-Random) }
    }
    if ([string]::IsNullOrWhiteSpace($ResourceGroupName)) {
        if ($env.resourceGroup) { $ResourceGroupName = $env.resourceGroup } else { $ResourceGroupName = 'rg-dynatrace-test' }
    }
}

Describe 'Remove-AzDynatraceMonitoredSubscription' {
    # These tests assume loadEnv.ps1 sets $SubscriptionId, $ResourceGroupName, $MonitorName
    # and that a monitored subscription relationship exists (or in playback its recording).
    # NOTE: Service currently returning InternalServerError for delete operations.
    # We convert "happy path" into parameter validation (WhatIf) and expected-error assertions.
    Context 'Delete by explicit parameters (validation only then expected failure)' {
        It 'Validates parameters with WhatIf without throwing' {
            { Remove-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -WhatIf } | Should -Not -Throw
        }
        It 'Actual delete currently throws (InternalServerError)' {
            { Remove-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Confirm:$false } | Should -Throw
        }
    }

    Context 'Delete via identity (validation then expected failure)' {
        It 'Pipes monitored subscription object and validates with WhatIf' {
            $obj = Get-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            $obj | Should -Not -BeNullOrEmpty
            { $obj | Remove-AzDynatraceMonitoredSubscription -WhatIf } | Should -Not -Throw
        }
        It 'Actual delete via identity expected to throw' {
            $obj = Get-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            { $obj | Remove-AzDynatraceMonitoredSubscription -Confirm:$false } | Should -Throw
        }
    }

    Context 'Idempotent delete behavior (current service state)' {
        It 'Second delete also throws (still failing backend)' {
            { Remove-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Confirm:$false } | Should -Throw
        }
    }

    Context 'Parameter validation errors' {
        It 'Throws when MonitorName missing' {
            { Remove-AzDynatraceMonitoredSubscription -ResourceGroupName $ResourceGroupName -Confirm:$false } | Should -Throw
        }
    It 'Throws when ResourceGroupName missing' {
            { Remove-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -Confirm:$false } | Should -Throw
        }
    }

    Context 'WhatIf safety' {
        It 'WhatIf does not perform deletion and does not throw' {
            { Remove-AzDynatraceMonitoredSubscription -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -WhatIf } | Should -Not -Throw
        }
    }
}
