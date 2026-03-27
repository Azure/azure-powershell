if(($null -eq $TestName) -or ($TestName -contains 'New-AzDynatraceMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDynatraceMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

  # Fallbacks to avoid empty env values causing ParameterBindingValidationException during WhatIf validation
  if ([string]::IsNullOrWhiteSpace($env.resourceGroup)) { $env.resourceGroup = "rg-dynatrace-test" }
  if ([string]::IsNullOrWhiteSpace($env.dynatraceName01)) { $env.dynatraceName01 = "dynatrace-monitor-" + (Get-Random) }
}

Describe 'New-AzDynatraceMonitoredSubscription' {
    It 'CreateExpandedLifecycle' {
        # Perform real creation with fully qualified subscription resource ID; omit Status (output-only).
        $sub = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new()
        $sub.SubscriptionId = "/subscriptions/$($env.SubscriptionId)"
        $list = @($sub)
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -MonitoredSubscriptionList $list -Operation "AddBegin" } | Should -Not -Throw
    }

    It 'CreateViaJsonStringReal' {
        # Wrap body under 'properties' to satisfy ARM resource schema (see successful recording payload).
        $jsonString = @{
            properties = @{
                operation = 'AddBegin'
                monitoredSubscriptionList = @(
                    @{ subscriptionId = "/subscriptions/$($env.SubscriptionId)" }
                )
            }
        } | ConvertTo-Json -Depth 6
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -JsonString $jsonString } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePathReal' {
        $tempFile = New-TemporaryFile
        # Same shape as JSON string variant; top-level 'properties' required.
        $jsonContent = @{
            properties = @{
                operation = 'AddBegin'
                monitoredSubscriptionList = @(
                    @{ subscriptionId = "/subscriptions/$($env.SubscriptionId)" }
                )
            }
        } | ConvertTo-Json -Depth 6
        Set-Content -Path $tempFile.FullName -Value $jsonContent
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -JsonFilePath $tempFile.FullName } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    # Identity pipeline variant removed – cmdlet does not expose a monitor-object identity parameter set; explicit parameters used instead.

    It 'JsonShapeValidation' {
        $jsonString = @{
            properties = @{
                operation = 'AddBegin'
                monitoredSubscriptionList = @(
                    @{ subscriptionId = "/subscriptions/$($env.SubscriptionId)" }
                )
            }
        } | ConvertTo-Json -Depth 6
        # Ensure wrapper and required fields present; status should not be user-supplied; operation inside properties.
        $jsonString | Should -Match '"properties"'
        $jsonString | Should -Not -Match '"status"'
        $jsonString | Should -Match '"/subscriptions/'
        $jsonString | Should -Match '"operation"\s*:\s*"AddBegin"'
    }
}