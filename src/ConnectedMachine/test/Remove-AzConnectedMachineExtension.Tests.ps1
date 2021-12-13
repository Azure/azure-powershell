$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Import-Module "$PSScriptRoot/helper.psm1" -Force

Describe 'Remove-AzConnectedMachineExtension' {
    BeforeAll {
        $machineName = $env.MachineName
        $customExtension = "customScript"
        $dependencyExtension = "dependency"

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
        Stop-Agent -AgentPath $env.azcmagentPath
    }

    It 'Create, Set, Get and Delete an extension' {
        $customSplat = @{
            MachineName = $machineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            Name = $customExtension
        }

        $dependencySplat = @{
            MachineName = $machineName
            ResourceGroupName = $env.ResourceGroupName
            Location = $env.Location
            Name = $dependencyExtension
        }
    
        if ($IsLinux) {
            $customSplat.ExtensionType = "CustomScript"
            $customSplat.Publisher = "Microsoft.Azure.Extensions"
            $customSplat.TypeHandlerVersion = "2.1"
            $customSplat.Settings = @{
                commandToExecute = "ls"
            }
        } elseif ($IsWindows) {
            $customSplat.ExtensionType = "CustomScriptExtension"
            $customSplat.Publisher = "Microsoft.Compute"
            $customSplat.TypeHandlerVersion = "1.10.10"
            $customSplat.Settings = @{
                CommandToExecute = "dir"
            }
        }

        if ($IsLinux) {
            $dependencySplat.ExtensionType = "DependencyAgentLinux"
        } elseif ($IsWindows) {
            $dependencySplat.ExtensionType = "DependencyAgentWindows"
        }
        $dependencySplat.Publisher = "Microsoft.Azure.Monitoring.DependencyAgent"

        Write-Host "Newing a CustomScript extension..." -ForegroundColor Cyan
        New-AzConnectedMachineExtension @customSplat
    
        Write-Host "Newing a DependencyAgent extension..." -ForegroundColor Cyan
        New-AzConnectedMachineExtension @dependencySplat

        Write-Host "Getting the extension list" -ForegroundColor Cyan
        $all = @(Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName)
        $all | Should -HaveCount 2
        $all[0].Name | Should -Be $customExtension
        $all[0].Setting["CommandToExecute"] | Should -Not -BeNullOrEmpty
        $all[1].Name | Should -Be $dependencyExtension
        $all[1].MachineExtensionType | Should -BeLike "DependencyAgent*"

        if ($IsLinux) {
            $customSplat.Settings = @{
                commandToExecute = "ls"
            }
        } elseif ($IsWindows) {
            $customSplat.Settings = @{
                commandToExecute = "powershell.exe ls"
            }
        }

        Write-Host "Setting the custom extension to use a new command" -ForegroundColor Cyan        
        Set-AzConnectedMachineExtension @customSplat

        Write-Host "Upgrading the extension version" -ForegroundColor Cyan
        $target = @{"Microsoft.Compute.CustomScriptExtension" = @{"targetVersion"="1.10.12"}}
        Update-AzConnectedExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -ExtensionTarget $target

        Write-Host "Getting the specific custom extension" -ForegroundColor Cyan
        $custom = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name $customExtension
        $custom.Name | Should -Be $customExtension
        $custom.Setting["CommandToExecute"] | Should -Not -BeLike $all[0].Setting["CommandToExecute"]
        $custom.TypeHandlerVersion | Should -Not -Be "1.10.10"

        Write-Host "Deleting the extensions" -ForegroundColor Cyan
        Remove-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name $customExtension
        { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name $customExtension } | Should -Throw
        Remove-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name $dependencyExtension
        { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name $dependencyExtension } | Should -Throw
    }
}
