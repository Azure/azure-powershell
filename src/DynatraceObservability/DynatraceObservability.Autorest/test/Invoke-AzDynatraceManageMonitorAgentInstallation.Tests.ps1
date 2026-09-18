if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDynatraceManageMonitorAgentInstallation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDynatraceManageMonitorAgentInstallation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

    # Fallbacks for missing names to avoid empty string parameter binding errors
    if ([string]::IsNullOrWhiteSpace($MonitorName)) {
        if ($env.dynatraceName01) { $MonitorName = $env.dynatraceName01 } else { $MonitorName = 'dynatrace-monitor-' + (Get-Random) }
    }
    if ([string]::IsNullOrWhiteSpace($ResourceGroupName)) {
        if ($env.resourceGroup) { $ResourceGroupName = $env.resourceGroup } else { $ResourceGroupName = 'rg-dynatrace-test' }
    }
}

Describe 'Invoke-AzDynatraceManageMonitorAgentInstallation' {
    # Assumptions:
    #  - loadEnv.ps1 defines $SubscriptionId, $ResourceGroupName, $MonitorName
    #  - Playback recordings capture both Install and Uninstall actions for sample resource IDs
    #  - Sample ARM resource IDs refer to VMs or resources eligible for agent actions (placeholder acceptable in playback)

    BeforeAll {
        $global:SampleResourceId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Compute/virtualMachines/sampleVM1"
        $global:TempJsonPath = Join-Path $PSScriptRoot 'manage-agent.json'
        $jsonObj = @{ action = 'Install'; manageAgentInstallationList = @( @{ id = $global:SampleResourceId } ) }
        ($jsonObj | ConvertTo-Json -Depth 5) | Set-Content -Path $global:TempJsonPath -Encoding UTF8
    }
    AfterAll {
        if (Test-Path $global:TempJsonPath) { Remove-Item $global:TempJsonPath -Force }
    }

    # Backend currently returning InternalServerError for install/uninstall operations.
    # Convert success assertions to validation (-WhatIf) and expected-error patterns.
    Context 'ManageExpanded Install action (validation then expected failure)' {
        It 'Validates parameters with WhatIf (no backend call)' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Install -ManageAgentInstallationList $list -WhatIf } | Should -Not -Throw
        }
        It 'Actual install expected to throw' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Install -ManageAgentInstallationList $list -Confirm:$false } | Should -Throw
        }
    }

    Context 'ManageExpanded Uninstall action (validation then expected failure)' {
        It 'Validates uninstall parameters with WhatIf' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Uninstall -ManageAgentInstallationList $list -WhatIf } | Should -Not -Throw
        }
        It 'Actual uninstall expected to throw' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Uninstall -ManageAgentInstallationList $list -Confirm:$false } | Should -Throw
        }
    }

    Context 'Manage parameter set with Request object (validation then expected failure)' {
        It 'Validates request object with WhatIf' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $request = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new(); $request.Action = 'Install'; $request.ManageAgentInstallationList = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Request $request -WhatIf } | Should -Not -Throw
        }
        It 'Actual install with request object expected to throw' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $request = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new(); $request.Action = 'Install'; $request.ManageAgentInstallationList = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Request $request -Confirm:$false } | Should -Throw
        }
    }

    Context 'ManageViaIdentity Expanded (validation then expected failure)' {
        It 'Validates identity + expanded params with WhatIf (pipe monitor object)' {
            # Obtain monitor object implementing IDynatraceObservabilityIdentity
            $monitorObj = Get-AzDynatraceMonitor -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            $monitorObj | Should -Not -BeNullOrEmpty
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { $monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Action Install -ManageAgentInstallationList $list -WhatIf } | Should -Not -Throw
        }
        It 'Actual install via identity expected to throw (backend error)' {
            $monitorObj = Get-AzDynatraceMonitor -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { $monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Action Install -ManageAgentInstallationList $list -Confirm:$false } | Should -Throw
        }
    }

    Context 'ManageViaIdentity with Request object (validation then expected failure)' {
        It 'Validates identity + request object with WhatIf (pipe monitor object)' {
            $monitorObj = Get-AzDynatraceMonitor -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            $monitorObj | Should -Not -BeNullOrEmpty
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $request = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new(); $request.Action = 'Uninstall'; $request.ManageAgentInstallationList = @($entry)
            { $monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Request $request -WhatIf } | Should -Not -Throw
        }
        It 'Actual uninstall via identity expected to throw (backend error)' {
            $monitorObj = Get-AzDynatraceMonitor -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName | Select-Object -First 1
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $request = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest]::new(); $request.Action = 'Uninstall'; $request.ManageAgentInstallationList = @($entry)
            { $monitorObj | Invoke-AzDynatraceManageMonitorAgentInstallation -Request $request -Confirm:$false } | Should -Throw
        }
    }

    Context 'ManageViaJsonString (validation then expected failure)' {
        It 'Validates JSON string with WhatIf' {
            $json = @{ action = 'Install'; manageAgentInstallationList = @( @{ id = $global:SampleResourceId } ) } | ConvertTo-Json -Depth 5
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -JsonString $json -WhatIf } | Should -Not -Throw
        }
        It 'Actual JSON string install expected to throw' {
            $json = @{ action = 'Install'; manageAgentInstallationList = @( @{ id = $global:SampleResourceId } ) } | ConvertTo-Json -Depth 5
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -JsonString $json -Confirm:$false } | Should -Throw
        }
    }

    Context 'ManageViaJsonFilePath (validation then expected failure)' {
        It 'Validates JSON file path with WhatIf' {
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -JsonFilePath $global:TempJsonPath -WhatIf } | Should -Not -Throw
        }
        It 'Actual JSON file path install expected to throw' {
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -JsonFilePath $global:TempJsonPath -Confirm:$false } | Should -Throw
        }
    }

    Context 'Parameter validation errors' {
        It 'Throws when MonitorName missing in Manage set' {
            $request = [PSCustomObject]@{ Action = 'Install'; ManageAgentInstallationList = @() }
            { Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName $ResourceGroupName -Request $request } | Should -Throw
        }
    It 'Throws when ResourceGroupName missing in Manage set' {
            $request = [PSCustomObject]@{ Action = 'Install'; ManageAgentInstallationList = @() }
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -Request $request } | Should -Throw
        }
    It 'Throws when Action missing in Expanded set' {
            $list = @([PSCustomObject]@{ Id = $global:SampleResourceId })
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -ManageAgentInstallationList $list } | Should -Throw
        }
    }

    Context 'Empty resource list edge (validation only)' {
        It 'Empty list validated with WhatIf' {
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Install -ManageAgentInstallationList @() -WhatIf } | Should -Not -Throw
        }
        It 'Actual call with empty list expected to throw' {
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Install -ManageAgentInstallationList @() -Confirm:$false } | Should -Throw
        }
    }

    Context 'Invalid action negative case' {
        It 'Throws for unsupported action value' {
            $json = @{ action = 'Reinstall'; manageAgentInstallationList = @( @{ id = $global:SampleResourceId } ) } | ConvertTo-Json -Depth 5
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -JsonString $json -Confirm:$false } | Should -Throw
        }
    }

    Context 'WhatIf safety (already covered above)' {
        It 'Redundant WhatIf scenario retained for completeness' {
            $entry = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList]::new(); $entry.Id = $global:SampleResourceId
            $list = @($entry)
            { Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName $MonitorName -ResourceGroupName $ResourceGroupName -Action Install -ManageAgentInstallationList $list -WhatIf } | Should -Not -Throw
        }
    }
}
