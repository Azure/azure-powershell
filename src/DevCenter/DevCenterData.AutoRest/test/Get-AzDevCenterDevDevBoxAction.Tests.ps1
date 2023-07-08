if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevDevBoxAction' {
    It 'List' -skip {
        $listOfActions = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName
        $listOfActions.Count | Should -BeGreaterOrEqual 2

        $listOfActions = Get-AzDevCenterDevDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
        $listOfActions.Count | Should -BeGreaterOrEqual 2

    }

    It 'Get' -skip {
        $scheduledTime = [DateTime]::ParseExact("6/30/2023 1:30:00 AM", "M/d/yyyy h:mm:ss tt", $null)

        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"
        
        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"
        $action.NextScheduledTime | Should -Be $scheduledTime

        $action = Get-AzDevCenterDevDevBoxAction -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName -ActionName "schedule-default"

        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"
        $action.NextScheduledTime | Should -Be $scheduledTime
    
    }

    It 'GetViaIdentity' -skip {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName; "ActionName" = "schedule-default"}
        $scheduledTime = [DateTime]::ParseExact("6/30/2023 1:30:00 AM", "M/d/yyyy h:mm:ss tt", $null)

        $action = Get-AzDevCenterDevDevBoxAction -Endpoint $env.endpoint -InputObject $devBoxInput

        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"
        $action.NextScheduledTime | Should -Be $scheduledTime

        $action = Get-AzDevCenterDevDevBoxAction -DevCenter $env.devCenterName -InputObject $devBoxInput

        $action.Name | Should -Be "schedule-default"
        $action.ActionType | Should -Be "Stop"
        $action.NextScheduledTime | Should -Be $scheduledTime
    }
}
