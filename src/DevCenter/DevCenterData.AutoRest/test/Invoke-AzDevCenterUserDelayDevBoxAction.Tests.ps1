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
    It 'Delay1' {
        $delayActions = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -DelayTime "00:10"
        $delayActions.Count | Should -Be 2
    }

    It 'Delay' {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -DevBoxName  $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentity' {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default";}

        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -Endpoint $env.endpoint -InputObject $actionInput -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'DelayViaIdentityByDevCenter' {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = $env.devboxName; "ActionName" = "schedule-default";}

        $delayAction = Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -InputObject $actionInput -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime

    }

    It 'Delay1ByDevCenter' {
        $delayAction =Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -DelayTime "00:10"
        $delayAction.Count | Should -Be 2
    }

    It 'DelayByDevCenter' {
        $action = Get-AzDevCenterUserDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        $delayTime = New-TimeSpan -Minutes 10
        $newScheduledTime = $action.NextScheduledTime + $delayTime
        $delayAction =Invoke-AzDevCenterUserDelayDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default" -DelayTime "00:10"
        $delayAction.NextScheduledTime | Should -Be $newScheduledTime
    }
}
 