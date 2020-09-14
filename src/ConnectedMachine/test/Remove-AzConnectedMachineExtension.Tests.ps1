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

    It 'Delete an extension' {
        { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1 } | Should -Not -Throw
        Remove-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1
        { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom1 } | Should -Throw
    }

    It 'Delete an extension using piping' {
        # Tests include -SubscriptionId automatically but it causes
        # piping to fail. This temporarily removes that default value for
        # this test.
        $PSDefaultParameterValues["Remove-AzConnectedMachineExtension:SubscriptionId"] = @{}
        try {
            { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom2 } | Should -Not -Throw
            Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom2 | Remove-AzConnectedMachineExtension
            { Get-AzConnectedMachineExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -Name custom2 } | Should -Throw
        } finally {
            $PSDefaultParameterValues.Remove("Remove-AzConnectedMachineExtension:SubscriptionId")
        }
    }
}
