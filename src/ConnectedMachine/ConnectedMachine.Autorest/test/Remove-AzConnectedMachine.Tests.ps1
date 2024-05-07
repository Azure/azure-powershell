$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Import-Module "$PSScriptRoot/helper.psm1" -Force

Describe 'Remove-AzConnectedMachine' {
    BeforeAll {
        $machineName = $env.MachineName

        if ($TestMode -ne 'playback' -and $IsMacOS) {
            Write-Host "Live tests can only be run on Windows and Linux. Skipping..."
            $SkipAll = $true

            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
        }
    }

    AfterAll {
        # Reset PSDefaultParameterValues
        if ($PSDefaultParameterValues["It:Skip"]) {
            $PSDefaultParameterValues.Remove("It:Skip")
        }
    }

    BeforeEach {
        if ($SkipAll) {
            return
        }

        $Location = $env.location

        if ($TestMode -eq 'playback') {
            # Skip starting azcmagent
            return
        }

        Start-Agent -MachineName $machineName -Env $env
    }

    AfterEach {
        if ($SkipAll) {
            return
        }

        if ($TestMode -eq 'playback') {
            # Skip stopping azcmagent
            return
        }

        Stop-Agent -AgentPath $env.azcmagentPath
    }

    It 'Remove a connected machine by name' {
        Remove-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
    }

    It 'Remove a connected machine by Input Object' {
        $machine = Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        Remove-AzConnectedMachine -InputObject $machine
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
    }

    It 'Remove a connected machine using pipelines' {
        # Tests include -SubscriptionId automatically but it causes
        # piping to fail. This temporarily removes that default value for
        # this test.
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Not -Throw
        Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName | Remove-AzConnectedMachine
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw
   }
}