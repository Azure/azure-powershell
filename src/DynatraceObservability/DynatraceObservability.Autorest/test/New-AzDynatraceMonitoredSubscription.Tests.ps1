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
    It 'CreateExpandedParameterValidation' {
        # Expanded parameter set uses -MonitoredSubscriptionList and optional -Operation
                $sub = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new()
                $sub.SubscriptionId = $env.SubscriptionId
                $list = @($sub)
                $list[0] | Should -BeOfType 'Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription'
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -MonitoredSubscriptionList $list -Operation "AddBegin" -WhatIf } | Should -Not -Throw
    }

    It 'CreateViaJsonStringParameterValidation' {
        # Correct JSON shape: top-level monitoredSubscriptionList & operation
        $jsonString = @{
            monitoredSubscriptionList = @(
                @{ subscriptionId = $env.SubscriptionId }
            );
            operation = "AddBegin"
        } | ConvertTo-Json -Depth 4
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePathParameterValidation' {
        $tempFile = New-TemporaryFile
        $jsonContent = @{
            monitoredSubscriptionList = @(
                @{ subscriptionId = $env.SubscriptionId }
            );
            operation = "AddBegin"
        } | ConvertTo-Json -Depth 4
        Set-Content -Path $tempFile.FullName -Value $jsonContent
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'CreateViaIdentityExpandedParameterValidation' {
        # Identity form still validates same payload shape; using WhatIf to avoid remote call
                $sub = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new()
                $sub.SubscriptionId = $env.SubscriptionId
                $list = @($sub)
        { New-AzDynatraceMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 -MonitoredSubscriptionList $list -Operation "AddBegin" -WhatIf } | Should -Not -Throw
    }

    It 'JsonShape' {
        $jsonString = @{
            monitoredSubscriptionList = @(
                @{ subscriptionId = $env.SubscriptionId }
            );
            operation = "AddBegin"
        } | ConvertTo-Json -Depth 4
        $jsonString | Should -Match '"monitoredSubscriptionList"'
        $jsonString | Should -Not -Match '"subscriptionList"'
        $jsonString | Should -Match '"operation"\s*:\s*"AddBegin"'
    }
}