$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Import-Module "$PSScriptRoot/helper.psm1" -Force

Describe 'Get-AzConnectedMachineExtension' {
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
        Stop-Agent -AgentPath $env.azcmagentPath
    }

    It 'List all extensions' {
        $all = @(Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName)
        $all | Should -HaveCount 2
        $all[0].Name | Should -Be "custom1"
        $all[0].Setting["commandToExecute"] | Should -Not -BeNullOrEmpty
        $all[1].Name | Should -Be "custom2"
        $all[1].MachineExtensionType | Should -BeLike "DependencyAgent*"
    }

    It 'Get a specific extension' {
        $all = Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1
        $all.Name | Should -Be "custom1"
        $all.Setting["commandToExecute"] | Should -Not -BeNullOrEmpty
    }
}
