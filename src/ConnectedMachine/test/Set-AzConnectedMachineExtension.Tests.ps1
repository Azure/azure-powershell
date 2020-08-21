$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzConnectedMachineExtension' {
    BeforeAll {
        $machineName = $env.MachineName1

        if ($TestMode -ne 'playback' -and $IsMacOS) {
            Write-Host "Live tests can only be run on Windows and Linux. Skipping..."
            $SkipAll = $true
            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
        }

        if ($TestMode -eq 'playback') {
            # Skip starting azcmagent
            return
        }

        Start-Agent -MachineName $machineName -Env $env
    }

    AfterAll {
        # Reset PSDefaultParameterValues
        if ($PSDefaultParameterValues["It:Skip"]) {
            $PSDefaultParameterValues.Remove("It:Skip")
            return
        }

        if ($TestMode -eq 'playback') {
            # Skip stopping azcmagent
            return
        }

        # Extensions must be removed first before the machine is disconnected.
        Start-ExtensionRemoval -ResourceGroupName $env.ResourceGroupName -MachineName $machineName
        Stop-Agent $env.azcmagentPath
    }

    It 'Can set an extension' {
        Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName | Should -BeNullOrEmpty
        
        $splat = @{
            MachineName = $machineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.location
        }
    
        if ($IsLinux) {
            $splat.ExtensionType = "CustomScript"
            $splat.Publisher = "Microsoft.Azure.Extensions"
            $splat.TypeHandlerVersion = "2.1"
            $splat.Settings = @{
                commandToExecute = "ls"
            }
        } elseif ($IsWindows) {
            $splat.ExtensionType = "CustomScriptExtension"
            $splat.Publisher = "Microsoft.Compute"
            $splat.TypeHandlerVersion = "1.10"
            $splat.Settings = @{
                commandToExecute = "dir"
            }
        }
    
        Write-Host "Setting CustomScript extension..." -ForegroundColor Cyan
        Set-AzConnectedMachineExtension @splat -Name custom

        $ext = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName
        $ext | Should -HaveCount 1
        $ext.Name | Should -Be "custom"
        $ext.Setting["commandToExecute"] | Should -Not -BeNullOrEmpty
    }
}
