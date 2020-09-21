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

Import-Module "$PSScriptRoot/helper.psm1" -Force

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
        Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName | Should -BeNullOrEmpty
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

        Stop-Agent $env.azcmagentPath
    }

    AfterEach {
        if ($TestMode -eq 'playback') {
            # Skip removing extensions
            return
        }

        # Extensions must be removed first before the machine is disconnected.
        Start-ExtensionRemoval -ResourceGroupName $env.ResourceGroupName -MachineName $machineName
    }

    It 'Can set an extension' {
        $extensionName = "custom1"
        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
            MachineName = $machineName
            Name = $extensionName
            Location = $env.location
            Settings = @{
                commandToExecute = "dir"
            }
        }
    
        if ($IsLinux) {
            $splat.ExtensionType = "CustomScript"
            $splat.Publisher = "Microsoft.Azure.Extensions"
            $splat.TypeHandlerVersion = "2.1"
        } elseif ($IsWindows) {
            $splat.ExtensionType = "CustomScriptExtension"
            $splat.Publisher = "Microsoft.Compute"
            $splat.TypeHandlerVersion = "1.10"
        }

        $ext = Set-AzConnectedMachineExtension @splat
        $ext.Name | Should -Be $extensionName
        $ext.Setting["commandToExecute"] | Should -Be $splat.Settings["commandToExecute"]
    }

    It 'Can set an extension via the pipeline' {
        $extensionName = "custom1"
        $extension = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineExtension]@{
            Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.HybridCompute/machines/$machineName/extensions/$extensionName"
            Type                 = "Microsoft.HybridCompute/machines/extensions"
            Name                 = $extensionName
            Location             = $env.location
            ProvisioningState    = "Succeeded"
            Setting              = @{ commandToExecute = "dir" }
            MachineExtensionType = if($IsWindows) { "CustomScriptExtension" } else { "CustomScript" }
            Publisher            = if($IsWindows) { "Microsoft.Compute"     } else { "Microsoft.Azure.Extensions" }
        }

        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
            MachineName = $machineName
            Name = $extensionName
        }

        $res = $extension | Set-AzConnectedMachineExtension @splat
        $res.Name | Should -Be $extensionName
        $res.ProvisioningState | Should -Be "Succeeded"
        $res.Setting["commandToExecute"] | Should -Be $extension.Setting["commandToExecute"]

        # Now modify the object and set it again
        $res.Setting["commandToExecute"] = "updated"
        $update = $res | Set-AzConnectedMachineExtension @splat
        $update.Name | Should -Be $extensionName
        $update.Setting["commandToExecute"] | Should -Be "updated"
    }
}
