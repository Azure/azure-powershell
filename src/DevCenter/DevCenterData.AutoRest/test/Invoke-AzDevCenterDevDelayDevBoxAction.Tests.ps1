if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterDevDelayDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterDevDelayDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterDevDelayDevBoxAction' {
    It 'Delay1' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction = Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'Delay' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction = Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentity' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default"}

        $delayAction = Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint $env.endpoint -InputObject $actionInput -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentityByDevCenter' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default"}

        $delayAction = Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter $env.devCenterName -InputObject $actionInput -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime

    }

    It 'Delay1ByDevCenter' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction =Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayByDevCenter' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction =Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }
}
