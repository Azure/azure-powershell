if (($null -eq $TestName) -or ($TestName -contains 'Skip-AzDevCenterDevDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Skip-AzDevCenterDevDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Skip-AzDevCenterDevDevBoxAction' {
    It 'Skip' -skip {
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName2 -ProjectName $env.projectName -ActionName "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan

        Skip-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName2 -ProjectName $env.projectName -ActionName "schedule-default"
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName2 -ProjectName $env.projectName -ActionName "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime

        
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox5" -ProjectName $env.projectName -ActionName "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan

        Skip-AzDevCenterDevDevBoxAction -DevCenter $env.devCenterName -DevBoxName "devbox5" -ProjectName $env.projectName -ActionName "schedule-default"
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox5" -ProjectName $env.projectName -ActionName "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime
    }

    It 'SkipViaIdentity' -skip {
        $actionInput = @{"ProjectName" = $env.projectName; "DevBoxName" = "devbox6"; "ActionName" = "schedule-default" }
        $actionInput2 = @{"ProjectName" = $env.projectName; "DevBoxName" = "devbox7"; "ActionName" = "schedule-default" }

        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox6" -ProjectName $env.projectName -ActionName "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan
        Skip-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -InputObject $actionInput
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox6" -ProjectName $env.projectName -ActionName "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime

        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox7" -ProjectName $env.projectName -ActionName "schedule-default"
        $skipTimeSpan = New-TimeSpan -Days 1
        $newScheduledTime = $action.NextScheduledTime + $skipTimeSpan
        Skip-AzDevCenterDevDevBoxAction -DevCenter $env.devCenterName  -InputObject $actionInput2
        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName "devbox6" -ProjectName $env.projectName -ActionName "schedule-default"
        $action.NextScheduledTime | Should -Be $newScheduledTime
    }
}
