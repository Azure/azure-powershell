$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Import-Module "$PSScriptRoot/helper.psm1" -Force

Describe 'Update-AzConnectedMachineExtension' {
    BeforeAll {
        $machineName = $env.MachineName

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
        Start-ExtensionPopulate -MachineName $machineName -Env $env
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

    It 'UpdateExpanded parameter set' {
        $newCommand = "hostname"

        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
            MachineName = $machineName
            Name = "custom1"
            Settings = @{
                commandToExecute = $newCommand
            }
        }
        $result = Update-AzConnectedMachineExtension @splat
        $result.Setting["commandToExecute"] | Should -Be $newCommand
    }

    It 'Update parameter set' {
        $currentExtension = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1
        $newCommand = "powershell.exe echo hi"
        $currentExtension.Setting["commandToExecute"] = $newCommand

        $splat = @{
            ResourceGroupName = $env.ResourceGroupName
            MachineName = $machineName
            Name = "custom1"
        }
        $result = $currentExtension | Update-AzConnectedMachineExtension @splat
        $result.Setting["commandToExecute"] | Should -Be $newCommand
    }

    It 'UpdateViaIdentityExpanded parameter set' {
        $currentExtension = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1
        $newCommand = "powershell.exe pwd"
        $currentExtension.Setting["commandToExecute"] = $newCommand

        # Tests include -SubscriptionId automatically but it causes
        # piping to fail. This temporarily removes that default value for
        # this test.
        $result = $currentExtension | Update-AzConnectedMachineExtension -Settings @{
            commandToExecute = $newCommand
        }
        $result.Setting["commandToExecute"] | Should -Be $newCommand
    }

    It 'UpdateViaIdentity parameter set' {
        $currentExtension = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1
        $newCommand = "powershell.exe man"
        $currentExtension.Setting["commandToExecute"] = $newCommand

        # Tests include -SubscriptionId automatically but it causes
        # piping to fail. This temporarily removes that default value for
        # this test.
        $result = $currentExtension | Update-AzConnectedMachineExtension -ExtensionParameter $currentExtension
        $result.Setting["commandToExecute"] | Should -Be $newCommand
    }     
}