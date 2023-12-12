if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterUserDelayDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterUserDelayDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterUserDelayDevBoxAction' {
    It 'Delay1'  {
        if ($Record -or $Live) {
            $delayActions = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName3 -ProjectName $env.projectName -DelayTime "00:05"
            $delayActions.Count | Should -Be 2
        }
    }

    It 'Delay'  {
        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName3 -ProjectName $env.projectName -Name "schedule-default"
            $delayTime = New-TimeSpan -Minutes 5
            $newScheduledTime = $action.NextScheduledTime + $delayTime
            $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName3 -ProjectName $env.projectName -Name "schedule-default" -DelayTime "00:05"
            $delayAction.NextScheduledTime | Should -Be $newScheduledTime
        }
    }

    It 'Delay1ByDevCenter'  {
        if ($Record -or $Live) {
            $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.devboxName3 -ProjectName $env.projectName -DelayTime "00:05"
            $delayAction.Count | Should -Be 2
        }
    }

    It 'DelayByDevCenter'  {
        if ($Record -or $Live) {
            $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName3 -ProjectName $env.projectName -Name "schedule-default"
            $delayTime = New-TimeSpan -Minutes 5
            $newScheduledTime = $action.NextScheduledTime + $delayTime
            $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.devboxName3 -ProjectName $env.projectName -Name "schedule-default" -DelayTime "00:05"
            $delayAction.NextScheduledTime | Should -Be $newScheduledTime
        }
    }
}
 