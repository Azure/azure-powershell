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
    It 'Delay1' -skip {
        $delayActions = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -DelayTime "00:05"
        $delayActions.Count | Should -Be 2
    }

    It 'Delay' -skip {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 5
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:05"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentity' -skip {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 5
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default";}

        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -InputObject $actionInput -DelayTime "00:05"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentityByDevCenter' -skip {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 5
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default";}

        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -InputObject $actionInput -DelayTime "00:05"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime

    }

    It 'Delay1ByDevCenter' -skip {
        $delayAction =Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -DelayTime "00:05"
        $delayAction.Count | Should -Be 2
    }

    It 'DelayByDevCenter' -skip {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 5
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction =Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:05"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }
}
 